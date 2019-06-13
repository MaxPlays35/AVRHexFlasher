// Created with love <3

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  /// <see cref="Main"/> form
  /// </summary>
  public partial class Main : MetroForm
  {
    /// <summary>
    /// Defines the Filename, Com
    /// </summary>
    public string Filename, Com;

    /// <summary>
    /// COM-Ports
    /// </summary>
    public string[] Ports = SerialPort.GetPortNames();

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    public Main()
    {
      InitializeComponent();
      var help = new Help();
      var cfg = new Configuration();
      Avr.Cfg = cfg;
      Avr.Help = help;
      Avr.M = this;
      Avr.StartUp();
    }

    /// <summary>
    /// The Button_updater_Tick
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Button_updater_Tick( object sender, EventArgs e )
    {
      if ( !refresh.Enabled || !opensketch.Enabled ) return;
      if ( hexpath.Text == "" || comports.SelectedItem == null )
        flash.Enabled = false;
      else
        flash.Enabled = true;
    }

    /// <summary>
    /// Compiles sketch
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Compile_Click( object sender, EventArgs e )
    {
      Logger.Log("Compiling started.", "Compiler     ");
      log2.Clear();
      foreach ( Control control in compilerpanel.Controls ) control.Enabled = false;
      log2.Enabled = true;
      spinner.Visible = true;

      Task.Factory.StartNew(Compiler).ContinueWith(result => End(true));
    }

    /// <summary>
    /// Compiler
    /// </summary>
    private void Compiler()
    {
      var files = Application.StartupPath + "\\files\\compiler\\";
      var customlibs = Application.StartupPath + "\\files\\custom\\libs";
      var customhardware = Application.StartupPath + "\\files\\custom\\hardware";
      var libs = files + "libs";
      var cache = files + "cache";
      var build = files + "build";
      var toolsavr = files + "hardware\\tools\\avr";
      var hardware = files + "hardware";
      var toolsbuilder = files + "tools-builder";
      var command =
        $"/c {Path.GetPathRoot(files).Remove(2, 1)} && cd \"{files}\" && arduino-builder.exe -compile -fqbn arduino:avr:{Config.Id}:cpu={Config.Mcu} -logger=machine -hardware \"{hardware}\" -hardware \"{customhardware}\" -tools \"{toolsbuilder}\" -tools \"{toolsavr}\" -built-in-libraries \"{libs}\" -libraries \"{customlibs}\" -warnings=all -build-cache \"{cache}\" -build-path \"{build}\" -verbose \"{sketchpath.Text}\"";

      log2.BeginInvoke((Action)( () => { log2.AppendText("cmd " + command); } ));
      Logger.Log(command, "Compiler     ");

      var info = new ProcessStartInfo("cmd", command)
      {
        WorkingDirectory = files,
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      var process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += SortOutputHandler2;
      process.ErrorDataReceived += SortOutputHandler2;
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      Logger.Log($"Log of compiler:\n{log2.Text}");
    }

    /// <summary>
    /// Comports_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Comports_SelectedIndexChanged( object sender, EventArgs e )
    {
      Com = comports.SelectedItem.ToString();
      Logger.Log($"Selected COM-Port: {Com}");
    }

    /// <summary>
    /// Opens config form
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Config_Click( object sender, EventArgs e )
    {
      flash.Enabled = false;
      compile.Enabled = false;
      Avr.Cfg.Show();
    }

    /// <summary>
    /// Enable controls on the form
    /// </summary>
    private void EnableAll()
    {
      foreach ( Control control in compilerpanel.Controls )
        control.BeginInvoke((Action)( () => { control.Enabled = true; } ));
      foreach ( Control control in flasherpanel.Controls )
        control.BeginInvoke((Action)( () => { control.Enabled = true; } ));
      spinner.BeginInvoke((Action)( () => { spinner.Visible = false; } ));
    }

    /// <summary>
    /// End of flashing\compiling
    /// </summary>
    /// <param name="compiler">
    /// The compiler <see cref="bool"/>
    /// </param>
    private void End( bool compiler = false )
    {
      EnableAll();
      if ( !compiler )
      {
        var t = log.Text;
        int error;
        if ( t.Contains("bytes of flash verified") )
          error = 0;
        else if ( t.Contains("programmer is not responding") )
          error = 1;
        else if ( t.Contains("can't open device") )
          error = 2;
        else if ( t.Contains("getsync()") )
          error = 3;
        else if ( t.Contains("Expected signature for") )
          error = 4;
        else
          error = 5;

        switch ( error )
        {
          case 0:
            MetroMessageBox.Show(this, "Flash done!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 1:
            MetroMessageBox.Show(this, "Programmer isn't responding!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 2:
            MetroMessageBox.Show(this, "Check COM-Port connection!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 3:
            MetroMessageBox.Show(this, "Check boards.db!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 4:
            MetroMessageBox.Show(this, "Check your avr device!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 5:
            MetroMessageBox.Show(this, "Unexpected error! Check log!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          default:
            throw new Exception("Something bad happened");
        }
      }
      else
      {
        var t = log2.Text;
        int error;
        if ( t.Contains("Sketch uses") && t.Contains("Global variables use") )
          error = 0;
        else if ( t.Contains("error: expected") && t.Contains("^") )
          error = 1;
        else
          error = 2;

        switch ( error )
        {
          case 0:
            var startup = Application.StartupPath + "\\";
            var file = Path.GetFileName(sketchpath.Text);
            if ( !Directory.Exists($"{startup}compiled") )
              Directory.CreateDirectory($"{startup}compiled");
            if ( File.Exists($"{startup}compiled\\{file}.hex") )
              File.Delete($"{startup}compiled\\{file}.hex");

            File.Move($"{startup}files\\compiler\\build\\{file}.hex", $"{startup}compiled\\{file}.hex");
            hexpath.BeginInvoke((Action)( () => { hexpath.Text = $"{startup}compiled\\{file}.hex"; } ));
            MetroMessageBox.Show(this, $"Compiled! Hex file path: {startup}compiled\\{file}.hex", "Done!",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 1:
            MetroMessageBox.Show(this, "Check your syntax!", "Error while compiling!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 2:
            MetroMessageBox.Show(this, "Unexpected error! Check log!", "Error while compiling!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          default:
            throw new Exception("Something bad happened");
        }
      }
    }

    /// <summary>
    /// Flash click
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Flash_Click( object sender, EventArgs e )
    {
      Logger.Log("Flashing started.", "Flasher      ");
      log.Clear();
      foreach ( Control control in flasherpanel.Controls ) control.Enabled = false;
      log.Enabled = true;

      Task.Factory.StartNew(Flasher).ContinueWith(result => End());
    }

    /// <summary>
    /// Flasher
    /// </summary>
    private void Flasher()
    {
      var command =
        $"/c {Application.StartupPath}\\files\\avrdude\\avrdude.exe -C {Application.StartupPath}\\files\\avrdude\\avr.cfg -v -p{Config.Mcu} -c arduino -P {Com} -b{Config.Speed} -D -Uflash:w:\"{Filename}\":i";

      log.BeginInvoke((Action)( () => { log.AppendText("cmd " + command); } ));
      Logger.Log(command, "Flasher      ");

      var info = new ProcessStartInfo("cmd", command)
      {
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      var process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += SortOutputHandler1;
      process.ErrorDataReceived += SortOutputHandler1;

      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      Logger.Log($"Log of flasher:\n{log.Text}");
    }

    /// <summary>
    /// Help Click
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Help_Click( object sender, EventArgs e )
    {
      Avr.Help.Show();
    }

    /// <summary>
    /// Open hex file
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void OpenHex_Click( object sender, EventArgs e )
    {
      ofile.Filter = "Compiled sketch|*.hex";
      ofile.Title = "Select compiled sketch file";
      ofile.FileName = "";
      if ( ofile.ShowDialog() == DialogResult.Cancel ) return;
      Filename = ofile.FileName;
      hexpath.Text = Filename;
      flash.Enabled = true;
      Logger.Log($"Selected compiled sketch file: {ofile.FileName} .", "Flasher      ");
    }

    /// <summary>
    /// Open sketch file
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void OpenSketch_Click( object sender, EventArgs e )
    {
      ofile.Filter = "Arduino sketch|*.ino";
      ofile.Title = "Select sketch file";
      ofile.FileName = "";
      if ( ofile.ShowDialog() == DialogResult.Cancel ) return;
      sketchpath.Text = ofile.FileName;
      compile.Enabled = true;
      Logger.Log($"Selected sketch file: {ofile.FileName} .", "Compiler     ");
    }

    /// <summary>
    /// Refreshes COM-Ports
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Refresh_Click( object sender, EventArgs e )
    {
      Ports = SerialPort.GetPortNames();
      comports.Items.Clear();
      foreach ( var port in Ports ) comports.Items.Add(port);
      if ( comports.Items.Count == 0 || comports.SelectedIndex != -1 ) return;
      comports.SelectedIndex = 0;
      Logger.Log("COM-Ports updated.");
    }

    /// <summary>
    /// Write console's output in TextBox (log)
    /// </summary>
    /// <param name="sendingProcess">
    /// The sendingProcess <see cref="object"/>
    /// </param>
    /// <param name="outLine">
    /// The outLine <see cref="DataReceivedEventArgs"/>
    /// </param>
    private void SortOutputHandler1( object sendingProcess, DataReceivedEventArgs outLine )
    {
      var sortOutput = new StringBuilder("");
      if ( log.InvokeRequired )
      {
        log.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler1), sendingProcess, outLine);
      }
      else
      {
        sortOutput.Append(Environment.NewLine + outLine.Data);
        log.AppendText(sortOutput.ToString());
      }
    }

    /// <summary>
    /// Write console's output in TextBox (log2)
    /// </summary>
    /// <param name="sendingProcess">
    /// The sendingProcess <see cref="object"/>
    /// </param>
    /// <param name="outLine">
    /// The outLine <see cref="DataReceivedEventArgs"/>
    /// </param>
    private void SortOutputHandler2( object sendingProcess, DataReceivedEventArgs outLine )
    {
      var sortOutput = new StringBuilder("");
      if ( log2.InvokeRequired )
      {
        log2.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler2), sendingProcess, outLine);
      }
      else
      {
        sortOutput.Append(Environment.NewLine + outLine.Data);
        log2.AppendText(sortOutput.ToString());
      }
    }

    /// <summary>
    /// Tabs_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Tabs_SelectedIndexChanged( object sender, EventArgs e )
    {
      if ( tabs.SelectedIndex != 1 || Config.CompilerSupport ) return;
      tabs.SelectedIndex = 0;
      MetroMessageBox.Show(this,
        "To use compiler, you need to download its files. Reset settings in \"Configuration\".",
        "No compiler's files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }
}
