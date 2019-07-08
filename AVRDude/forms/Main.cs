// Created with love <3

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  ///   <see cref="Main" /> form
  /// </summary>
  public partial class Main : MetroForm
  {
    /// <summary>
    ///   Defines the Filename, Com
    /// </summary>
    public string Filename, Com;

    /// <summary>
    ///   COM-Ports
    /// </summary>
    public string[] Ports = SerialPort.GetPortNames();

    public ResourceManager RM = new ResourceManager( "AVRHexFlasher.Main",
                                                     Assembly.GetExecutingAssembly() );

    /// <summary>
    ///   Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
      InitializeComponent();
      KeyPreview = true;
      var help = new Help();
      var cfg  = new Configuration();
      Avr.Cfg  = cfg;
      Avr.Help = help;
      Avr.M    = this;
      Avr.StartUp();
    }

    /// <summary>
    ///   Compiles sketch
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    public void Compile_Click( object sender, EventArgs e )
    {
      Logger.Log( "Compiling started.", "Compiler     " );
      log2.Clear();
      foreach ( Control control in compilerpanel.Controls ) control.Enabled = false;
      log2.Enabled    = true;
      spinner.Visible = true;

      Task.Factory.StartNew( () => DoAction( true ) ).ContinueWith( result => End( true ) );
    }

    /// <summary>
    ///   Flash click
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    public void Flash_Click( object sender, EventArgs e )
    {
      Logger.Log( "Flashing started.", "Flasher      " );
      log.Clear();
      foreach ( Control control in flasherpanel.Controls ) control.Enabled = false;
      log.Enabled = true;

      Task.Factory.StartNew( () => DoAction() ).ContinueWith( result => End() );
    }

    /// <summary>
    ///   The Button_updater_Tick
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Button_updater_Tick( object sender, EventArgs e )
    {
      if ( !refresh.Enabled ||
           !opensketch.Enabled ) return;

      if ( hexpath.Text          == "" ||
           comports.SelectedItem == null )
        flash.Enabled = false;
      else
        flash.Enabled = true;
    }

    /*
    /// <summary>
    ///   Compiler
    /// </summary>
    private void Compiler()
    {
      var files          = Application.StartupPath + "\\Files\\compiler\\";
      var customlibs     = Application.StartupPath + "\\Files\\custom\\libs";
      var customhardware = Application.StartupPath + "\\Files\\custom\\hardware";
      var libs           = files                   + "libs";
      var cache          = files                   + "cache";
      var build          = files                   + "build";
      var toolsavr       = files                   + "hardware\\tools\\avr";
      var hardware       = files                   + "hardware";
      var toolsbuilder   = files                   + "tools-builder";

      var command =
        $"/c {Path.GetPathRoot( files ).Remove( 2, 1 )} && cd \"{files}\" && arduino-builder.exe -compile -fqbn arduino:avr:{Config.Id}:cpu={Config.Mcu} -logger=machine -hardware \"{hardware}\" -hardware \"{customhardware}\" -tools \"{toolsbuilder}\" -tools \"{toolsavr}\" -built-in-libraries \"{libs}\" -libraries \"{customlibs}\" -warnings=all -build-cache \"{cache}\" -build-path \"{build}\" -verbose \"{sketchpath.Text}\"";

      log2.BeginInvoke( ( Action ) ( () => { log2.AppendText( "cmd " + command ); } ) );
      Logger.Log( command, "Compiler     " );

      var info = new ProcessStartInfo( "cmd", command )
      {
        WorkingDirectory       = files,
        UseShellExecute        = false,
        RedirectStandardInput  = true,
        RedirectStandardOutput = true,
        RedirectStandardError  = true,
        CreateNoWindow         = true
      };

      var process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += SortOutputHandler2;
      process.ErrorDataReceived  += SortOutputHandler2;
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      Logger.Log( $"Log of compiler:\n{log2.Text}" );
    }
*/
    /// <summary>
    ///   Comports_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Comports_SelectedIndexChanged( object sender, EventArgs e )
    {
      Com = comports.SelectedItem.ToString();
      Logger.Log( $"Selected COM-Port: {Com}" );
    }

    /// <summary>
    ///   Opens config form
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Config_Click( object sender, EventArgs e )
    {
      flash.Enabled   = false;
      compile.Enabled = false;
      Avr.Cfg.Show();
    }

    /// <summary>
    ///   Enable controls on the form
    /// </summary>
    private void EnableAll()
    {
      foreach ( Control control in compilerpanel.Controls )
        control.BeginInvoke( ( Action ) ( () => { control.Enabled = true; } ) );

      foreach ( Control control in flasherpanel.Controls )
        control.BeginInvoke( ( Action ) ( () => { control.Enabled = true; } ) );
      spinner.BeginInvoke( ( Action ) ( () => { spinner.Visible = false; } ) );
    }

    /// <summary>
    ///   End of flashing\compiling
    /// </summary>
    /// <param name="compiler">
    ///   The compiler <see cref="bool" />
    /// </param>
    private void End( bool compiler = false )
    {
      EnableAll();

      if ( !compiler )
      {
        var t = log.Text;
        int error;

        if ( t.Contains( "bytes of flash verified" ) )
          error = 0;
        else if ( t.Contains( "programmer is not responding" ) )
          error = 1;
        else if ( t.Contains( "can't open device" ) )
          error = 2;
        else if ( t.Contains( "getsync()" ) )
          error = 3;
        else if ( t.Contains( "Expected signature for" ) )
          error = 4;
        else
          error = 5;

        switch ( error )
        {
          case 0:
            MetroMessageBox.Show( this, RM.GetString( "flash.done" ), RM.GetString( "done" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information );

            break;

          case 1:
            MetroMessageBox.Show( this, RM.GetString( "responding" ), RM.GetString( "flashing.Text1" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          case 2:
            MetroMessageBox.Show( this, RM.GetString( "com.port" ), RM.GetString( "flashing.Text1" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          case 3:
            MetroMessageBox.Show( this, RM.GetString( "board.db" ), RM.GetString( "flashing.Text1" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          case 4:
            MetroMessageBox.Show( this, RM.GetString( "check.avr" ), RM.GetString( "flashing.Text1" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          case 5:
            MetroMessageBox.Show( this, RM.GetString( "unexpected" ), RM.GetString( "flashing.Text1" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          default:
            throw new Exception( "Something bad happened" );
        }
      }
      else
      {
        var t = log2.Text;
        int error;

        if ( t.Contains( "Sketch uses" ) &&
             t.Contains( "Global variables use" ) )
          error = 0;
        else if ( t.Contains( "error: expected" ) &&
                  t.Contains( "^" ) )
          error = 1;
        else
          error = 2;

        switch ( error )
        {
          case 0:
            var startup = Application.StartupPath + "\\";
            var file    = Path.GetFileName( sketchpath.Text );

            if ( !Directory.Exists( $"{startup}compiled" ) )
              Directory.CreateDirectory( $"{startup}compiled" );

            if ( File.Exists( $"{startup}compiled\\{file}.hex" ) )
              File.Delete( $"{startup}compiled\\{file}.hex" );

            File.Move( $"{startup}Files\\compiler\\build\\{file}.hex", $"{startup}compiled\\{file}.hex" );
            hexpath.BeginInvoke( ( Action ) ( () => { hexpath.Text = $"{startup}compiled\\{file}.hex"; } ) );

            MetroMessageBox.Show( this, $"{RM.GetString( "compiled" )}: {startup}compiled\\{file}.hex",
                                  RM.GetString( "done" ),
                                  MessageBoxButtons.OK, MessageBoxIcon.Information );

            break;

          case 1:
            MetroMessageBox.Show( this,
                                  RM.GetString( "syntax.Text" ), RM.GetString( "compiling.Text" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          case 2:
            MetroMessageBox.Show( this, RM.GetString( "unexpected" ), RM.GetString( "compiling.Text" ),
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error );

            break;

          default:
            throw new Exception( "Something bad happened" );
        }
      }
    }

    /*
    /// <summary>
    ///   Flasher
    /// </summary>
    private void Flasher()
    {
      var command =
        $"/c {Application.StartupPath}\\Files\\avrdude\\avrdude.exe -C {Application.StartupPath}\\Files\\avrdude\\avr.cfg -v -p{Config.Mcu} -c arduino -P {Com} -b{Config.Speed} -D -Uflash:w:\"{Filename}\":i";

      log.BeginInvoke( ( Action ) ( () => { log.AppendText( "cmd " + command ); } ) );
      Logger.Log( command, "Flasher      " );

      var info = new ProcessStartInfo( "cmd", command )
      {
        WorkingDirectory = files,
        UseShellExecute        = false,
        RedirectStandardInput  = true,
        RedirectStandardOutput = true,
        RedirectStandardError  = true,
        CreateNoWindow         = true
      };

      var process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += SortOutputHandler1;
      process.ErrorDataReceived  += SortOutputHandler1;

      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      Logger.Log( $"Log of flasher:\n{log.Text}" );
    }
*/
    private void DoAction( bool Compile = false )
    {
      var          command = "";
      var          files   = Application.StartupPath + "\\Files\\compiler\\";
      MetroTextBox m;

      if ( Compile )
      {
        var customlibs     = Application.StartupPath + "\\Files\\custom\\libs";
        var customhardware = Application.StartupPath + "\\Files\\custom\\hardware";
        var libs           = files                   + "libs";
        var cache          = files                   + "cache";
        var build          = files                   + "build";
        var hardware       = files                   + "hardware";
        var toolsbuilder   = files                   + "tools-builder";
        var toolsavr       = hardware                + "\\tools\\avr";

        command =
          $"/c {Path.GetPathRoot( files ).Remove( 2, 1 )} && cd \"{files}\" && arduino-builder.exe -compile -fqbn arduino:avr:{Config.Id}:cpu={Config.Mcu} -logger=machine -hardware \"{hardware}\" -hardware \"{customhardware}\" -tools \"{toolsbuilder}\" -tools \"{toolsavr}\" -built-in-libraries \"{libs}\" -libraries \"{customlibs}\" -warnings=all -build-cache \"{cache}\" -build-path \"{build}\" -verbose \"{sketchpath.Text}\"";
        m = log2;
      }
      else
      {
        command =
          $"/c {Application.StartupPath}\\Files\\avrdude\\avrdude.exe -C {Application.StartupPath}\\Files\\avrdude\\avr.cfg -v -p{Config.Mcu} -c arduino -P {Com} -b{Config.Speed} -D -Uflash:w:\"{Filename}\":i";
        m = log;
      }

      var info = new ProcessStartInfo( "cmd", command )
      {
        UseShellExecute        = false,
        RedirectStandardInput  = true,
        RedirectStandardOutput = true,
        RedirectStandardError  = true,
        CreateNoWindow         = true
      };

      if ( Compile ) info.WorkingDirectory = files;

      var process = new Process
      {
        StartInfo = info
      };
      
      m.BeginInvoke( ( Action ) ( () => { m.AppendText( "cmd " + command ); } ) );
      Logger.Log( command, Compile ? "Flasher      " : "Compiler     " );

      void Log( object sendingProcess, DataReceivedEventArgs outLine )
      {
        var sortOutput = new StringBuilder( "" );

        if ( m.InvokeRequired )
        {
          m.BeginInvoke( new DataReceivedEventHandler( Log ), sendingProcess, outLine );

          return;
        }

        sortOutput.Append( Environment.NewLine + outLine.Data );
        m.AppendText( sortOutput.ToString() );
      }

      process.OutputDataReceived += Log;
      process.ErrorDataReceived  += Log;

      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      Logger.Log( $"Log of {( Compile ? "compiler" : "flasher" )}:\n{m.Text}" );
    }


    /// <summary>
    ///   Help Click
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Help_Click( object sender, EventArgs e ) { Avr.Help.Show(); }

    //private void Main_KeyDown( object sender, KeyEventArgs e ) { HotKeys.Handler( sender, e ); }

    /// <summary>
    ///   Open hex file
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void OpenHex_Click( object sender, EventArgs e )
    {
      ofile.Filter   = "Compiled sketch|*.hex";
      ofile.Title    = RM.GetString( "selectCSF" );
      ofile.FileName = "";

      if ( ofile.ShowDialog() == DialogResult.Cancel ) return;
      Filename      = ofile.FileName;
      hexpath.Text  = Filename;
      flash.Enabled = true;
      Logger.Log( $"Selected compiled sketch file: {ofile.FileName} .", "Flasher      " );
    }

    /// <summary>
    ///   Open sketch file
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void OpenSketch_Click( object sender, EventArgs e )
    {
      ofile.Filter   = "Arduino sketch|*.ino";
      ofile.Title    = RM.GetString( "selectSF" );
      ofile.FileName = "";

      if ( ofile.ShowDialog() == DialogResult.Cancel ) return;
      sketchpath.Text = ofile.FileName;
      compile.Enabled = true;
      Logger.Log( $"Selected sketch file: {ofile.FileName} .", "Compiler     " );
    }

    /// <summary>
    ///   Refreshes COM-Ports
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Refresh_Click( object sender, EventArgs e )
    {
      Ports = SerialPort.GetPortNames();
      comports.Items.Clear();
      foreach ( var port in Ports ) comports.Items.Add( port );

      if ( comports.Items.Count   == 0 ||
           comports.SelectedIndex != -1 ) return;
      comports.SelectedIndex = 0;
      Logger.Log( "COM-Ports updated." );
    }

    /// <summary>
    ///   Write console's output in TextBox (log)
    /// </summary>
    /// <param name="sendingProcess">
    ///   The sendingProcess <see cref="object" />
    /// </param>
    /// <param name="outLine">
    ///   The outLine <see cref="DataReceivedEventArgs" />
    /// </param>
    private void SortOutputHandler1( object sendingProcess, DataReceivedEventArgs outLine )
    {
      var sortOutput = new StringBuilder( "" );

      if ( log.InvokeRequired )
      {
        log.BeginInvoke( new DataReceivedEventHandler( SortOutputHandler1 ), sendingProcess, outLine );

        return;
      }

      sortOutput.Append( Environment.NewLine + outLine.Data );
      log.AppendText( sortOutput.ToString() );
    }

    /// <summary>
    ///   Write console's output in TextBox (log2)
    /// </summary>
    /// <param name="sendingProcess">
    ///   The sendingProcess <see cref="object" />
    /// </param>
    /// <param name="outLine">
    ///   The outLine <see cref="DataReceivedEventArgs" />
    /// </param>
    private void SortOutputHandler2( object sendingProcess, DataReceivedEventArgs outLine )
    {
      var sortOutput = new StringBuilder( "" );

      if ( log2.InvokeRequired )
      {
        log2.BeginInvoke( new DataReceivedEventHandler( SortOutputHandler2 ), sendingProcess, outLine );

        return;
      }

      sortOutput.Append( Environment.NewLine + outLine.Data );
      log2.AppendText( sortOutput.ToString() );
    }

    /// <summary>
    ///   Tabs_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Tabs_SelectedIndexChanged( object sender, EventArgs e )
    {
      if ( tabs.SelectedIndex != 1 ||
           Config.CompilerSupport ) return;
      tabs.SelectedIndex = 0;

      MetroMessageBox.Show( this,
                            RM.GetString( "noCompilerText" ),
                            RM.GetString( "noCompilerHeader" ), MessageBoxButtons.OK, MessageBoxIcon.Warning );
    }
  }
}