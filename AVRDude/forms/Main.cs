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
      Error error;

      if ( !compiler )
      {
        var t = log.Text;

        if ( t.Contains( "bytes of flash verified" ) )
          error = Error.None;
        else if ( t.Contains( "programmer is not responding" ) )
          error = Error.ProgrammerIsNotResponsing;
        else if ( t.Contains( "can't open device" ) )
          error = Error.ComPort;
        else if ( t.Contains( "getsync()" ) )
          error = Error.WrongBoard;
        else if ( t.Contains( "Expected signature for" ) )
          error = Error.WrongBoardsFile;
        else
          error = Error.Unexcepted;

        var text  = RM.GetString( "unexpected" );
        var title = RM.GetString( "flashing.Text1" );
        var type  = MessageBoxIcon.Error;

        switch ( error )
        {
          case Error.None:
            text  = RM.GetString( "flash.done" );
            title = RM.GetString( "done" );
            type  = MessageBoxIcon.Information;

            break;

          case Error.ProgrammerIsNotResponsing:
            text = RM.GetString( "responding" );

            break;

          case Error.ComPort:
            text = RM.GetString( "com.port" );

            break;

          case Error.WrongBoardsFile:
            text = RM.GetString( "board.db" );

            break;

          case Error.WrongBoard:
            text = RM.GetString( "check.avr" );

            break;

          case Error.Unexcepted:
            break;

          case Error.Syntax:
            break;

          default:
            throw new Exception( "Something bad happened" );
        }

        MetroMessageBox.Show( this, text, title,
                              MessageBoxButtons.OK,
                              type );
      }
      else
      {
        var t = log2.Text;

        if ( t.Contains( "Sketch uses" ) &&
             t.Contains( "Global variables use" ) )
          error = Error.None;
        else if ( t.Contains( "error: expected" ) &&
                  t.Contains( "^" ) )
          error = Error.Syntax;
        else
          error = Error.Unexcepted;


        var text  = RM.GetString( "unexpected" );
        var title = RM.GetString( "compiling.Text" );
        var type  = MessageBoxIcon.Error;


        switch ( error )
        {
          case Error.None:
            var startup = Application.StartupPath + "\\";
            var file    = Path.GetFileName( sketchpath.Text );

            if ( !Directory.Exists( $"{startup}compiled" ) )
              Directory.CreateDirectory( $"{startup}compiled" );

            if ( File.Exists( $"{startup}compiled\\{file}.hex" ) )
              File.Delete( $"{startup}compiled\\{file}.hex" );

            File.Move( $"{startup}Files\\compiler\\build\\{file}.hex", $"{startup}compiled\\{file}.hex" );
            hexpath.BeginInvoke( ( Action ) ( () => { hexpath.Text = $"{startup}compiled\\{file}.hex"; Filename = $"{startup}compiled\\{file}.hex"; } ) );

            text  = $"{RM.GetString( "compiled" )}: {startup}compiled\\{file}.hex";
            title = RM.GetString( "done" );
            type  = MessageBoxIcon.Information;

            break;

          case Error.Syntax:
            text = RM.GetString( "syntax.Text" );

            break;

          case Error.Unexcepted:
            break;
        }

        MetroMessageBox.Show( this, text,
                              title,
                              MessageBoxButtons.OK, type );
      }
    }

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

    private enum Error
    {
      None,
      ProgrammerIsNotResponsing,
      ComPort,
      WrongBoardsFile,
      WrongBoard,
      Syntax,
      Unexcepted
    }
  }
}