// Created with love <3

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  /// <see cref="Main"/> form
  /// </summary>
  public partial class Main : MetroForm
  {
    /// <summary>
    /// Speed
    /// </summary>
    public string baudrate = "0";

    /// <summary> Filename & COM-port </summary>
    public string filename, com;

    /// <summary>
    /// COM-Ports
    /// </summary>
    public string[] ports = SerialPort.GetPortNames();

    /// <summary>
    /// Processor
    /// </summary>
    public string processor = "";

    /// <summary>
    /// Creates <see cref="Main"/> form.
    /// </summary>
    public Main()
    {
      InitializeComponent();
      StartUp();
    }

    /// <summary>
    /// Initialize program
    /// </summary>
    public void StartUp()
    {
      //Forms initialization
      Help help = new Help();
      Configuration cfg = new Configuration();
      avr.cfg = cfg;
      avr.help = help;
      avr.m = this;
      //Create folders for compiler
      List<string> dirs = new List<string>() {"custom", "custom\\libs", "custom\\hardware"};
      foreach ( string dir in dirs )
      {
        if ( !Directory.Exists("files\\" + dir) )
          Directory.CreateDirectory("files\\" + dir);
      }
      cfg.Owner = this;
      cfg.themesel.SelectedIndex = 0;

      if ( !File.Exists(config.cfgfile) )
      {
        var s = new Setup();
        s.Show();
        TopMost = false;
        Enabled = false;
      }
      var boards = BoardsParser.Parse();
      foreach ( var b in boards ) cfg.boardsel.Items.Add(b.Value.Name);
      cfg.boardsel.SelectedIndex = 0;

      cfg.Initialize();

      foreach ( var port in ports ) comports.Items.Add(port);
      if ( comports.Items.Count != 0 ) comports.SelectedIndex = 0;
    }

    /// <summary>
    /// Opens Help form
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void About_Click( object sender, EventArgs e )
    {
      avr.help.Show();
    }

    private void Button_updater_Tick( object sender, EventArgs e )
    {
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
      spinner.Visible = true;
      foreach ( var t in compilerpanel.Controls.OfType<MetroButton>() ) t.Enabled = false;
      sketchpath.Enabled = false;
      log2.Clear();

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
      var tools = files + "tools";
      var cache = files + "cache";
      var build = files + "build";
      var toolsavr = files + "hardware\\tools\\avr";
      var hardware = files + "hardware";
      var toolsbuilder = files + "tools-builder";
      var command = "/c " + Path.GetPathRoot(files).Remove(2, 1) + " && cd \"" + files +
                    "\" && arduino-builder.exe -compile -fqbn arduino:avr:" + config.id + ":cpu=" + config.mcu +
                    " -logger=machine -hardware \"" + hardware + "\" -tools \"" + toolsbuilder + "\" -tools \"" +
                    toolsavr + "\" -built-in-libraries \"" + libs + "\" -libraries \"" + customlibs +
                    "\" -warnings=all -build-cache \"" + cache + "\" -build-path \"" + build + "\" -verbose \"" +
                    sketchpath.Text + "\"";

      log2.BeginInvoke((Action)( () => { log2.AppendText("cmd " + command); } ));

      var info = new ProcessStartInfo("cmd", command)
      {
        WorkingDirectory = files,
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      var outputBuilder = new StringBuilder();
      var errorBuilder = new StringBuilder();

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
      avr.cfg.Show();
    }

    /// <summary>
    /// End of flashing\compiling
    /// </summary>
    /// <param name="compiler">
    /// The compiler <see cref="bool"/>
    /// </param>
    private void End( bool compiler = false )
    {
      onAll();
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
            MetroMessageBox.Show(this, "Programmer is not responding!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 2:
            MetroMessageBox.Show(this, "Check COM-Port connection!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 3:
            MetroMessageBox.Show(this, "Check baudrate!", "Error while flashing!", MessageBoxButtons.OK,
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
            try
            {
              Directory.CreateDirectory(startup + "compiled");
            }
            catch
            {
            }

            try
            {
              File.Delete(startup + "compiled\\" + file + ".hex");
            }
            catch
            {
            }

            File.Move(startup + "files\\compiler\\build\\" + file + ".hex", startup + "compiled\\" + file + ".hex");
            hexpath.BeginInvoke((Action)( () => { hexpath.Text = startup + "compiled\\" + file + ".hex"; } ));
            MetroMessageBox.Show(this, "Compiled! Hex file path: " + startup + "compiled\\" + file + ".hex", "Done!",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 1:
            MetroMessageBox.Show(this, "Check your syntax!", "Error while compiling!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          case 2:
            MetroMessageBox.Show(this, "Unexpected error! Check log!", "Error while flashing!", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;

          default:
            throw new Exception("Something bad happened");
        }
      }
    }

    /// <summary>
    /// Flash
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Flash_Click( object sender, EventArgs e )
    {
      log.Clear();
      comports.Enabled = false;
      refresh.Enabled = false;
      openhex.Enabled = false;
      flash.Enabled = false;
      config_button.Enabled = false;
      button_updater.Enabled = false;
      avr_kill.Enabled = true;

      Task.Factory.StartNew(Flasher).ContinueWith(result => End());
    }

    /// <summary>
    /// Flasher
    /// </summary>
    private void Flasher()
    {
      com = com.ToUpper();

      var command = "/c " + Application.StartupPath + "\\files\\avrdude\\avrdude.exe -C " + Application.StartupPath + "\\files\\avrdude\\avr.cfg -v -p" + config.mcu +
                    " -c arduino -P " + com + " -b" + config.speed + " -D -Uflash:w:\"" + filename + "\":i";

      log.BeginInvoke((Action)( () => { log.AppendText("cmd " + command); } ));

      var info = new ProcessStartInfo("cmd", command)
      {
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      var outputBuilder = new StringBuilder();
      var errorBuilder = new StringBuilder();

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
    }

    /// <summary>
    /// When Main form loads
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Main_Load( object sender, EventArgs e )
    {
    }

    /// <summary>
    /// Enable controls on the form
    /// </summary>
    private void onAll()
    {
      SetEnabled(comports);
      SetEnabled(config_button);
      SetEnabled(hexpath);
      SetEnabled(openhex);
      SetEnabled(refresh);
      SetEnabled(flash);
      foreach ( var b in compilerpanel.Controls.OfType<MetroButton>() ) SetEnabled(b);
      spinner.BeginInvoke((Action)( () => { spinner.Visible = false; } ));
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
      if ( ofile.ShowDialog() == DialogResult.Cancel )
        return;
      filename = ofile.FileName;
      hexpath.Text = filename;
      flash.Enabled = true;
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
      if ( ofile.ShowDialog() == DialogResult.Cancel )
        return;
      sketchpath.Text = ofile.FileName;
      compile.Enabled = true;
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
      ports = SerialPort.GetPortNames();
      comports.Items.Clear();
      foreach ( var port in ports ) comports.Items.Add(port);
      if ( comports.Items.Count != 0 && comports.SelectedIndex == -1 )
        comports.SelectedIndex = 0;
    }

    /// <summary>
    /// Sets property "Enabled" on true
    /// </summary>
    /// <param name="b">
    /// The b <see cref="Button"/>
    /// </param>
    private void SetEnabled( Button b )
    {
      b.BeginInvoke((Action)( () => { b.Enabled = true; } ));
    }

    /// <summary>
    /// Sets property "Enabled" on true
    /// </summary>
    /// <param name="b">
    /// The b <see cref="ComboBox"/>
    /// </param>
    private void SetEnabled( ComboBox b )
    {
      b.BeginInvoke((Action)( () => { b.Enabled = true; } ));
    }

    /// <summary>
    /// Sets property "Enabled" on true
    /// </summary>
    /// <param name="b">
    /// The b <see cref="MetroTextBox"/>
    /// </param>
    private void SetEnabled( MetroTextBox b )
    {
      b.BeginInvoke((Action)( () => { b.Enabled = true; } ));
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
      if ( tabs.SelectedIndex == 1 && !config.compilersupport )
      {
        tabs.SelectedIndex = 0;
        MetroMessageBox.Show(this,
          "To use compiler, you need to download its files. Reset settings in \"Configuration\".",
          "No compiler's files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
  }
}
