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

namespace AVRDude
{
  public partial class Main : MetroForm
  {
    private string filename, com;
    private string[] ports = SerialPort.GetPortNames();
    public string baudrate = "0";
    public string processor = "";
    Configuration cfg = new Configuration ();
    Help ab = new Help();

    public Main()
    {
      InitializeComponent();
      Program.m = this;
      if ( !File.Exists("avr.cfg") )
      {
        Setup s = new Setup();
        s.Show();
        TopMost = false;
        Enabled = false;
      }
      cfg.Owner = this;
      cfg.themesel.SelectedIndex = 0;

      Dictionary<string, Board> boards = BoardsParser.Parse();
      foreach ( KeyValuePair<string, Board> b in boards )
      {
        cfg.boardsel.Items.Add(b.Value.Name);
      }
      cfg.boardsel.SelectedIndex = 0;
      try
      {
        File.Delete("log.txt");
      }
      catch { }
      foreach ( string port in ports )
      {
        comports.Items.Add(port);
      }
      if ( comports.Items.Count != 0 )
        comports.SelectedIndex = 0;
      ofile.Filter = "firmware|*.hex";
      ofile.Title = "Select firmware hexed file";
      ofile.FileName = "";
    }

    private void Comports_SelectedIndexChanged( object sender, EventArgs e )
    {
      com = comports.SelectedItem.ToString();
      File.Delete("log.txt");
      Common.Files.FileWriter("log.txt", "Selected COM port: " + com.ToUpper());
    }

    private void Log_updater_Tick( object sender, EventArgs e )
    {
      string filelog;
      if ( File.Exists("log.txt") )
      {
        try
        {
          filelog = Common.Files.FileReader("log.txt");
          log.Text = filelog;
        }
        catch { }
      }
      if ( hexpath.Text == "" || comports.SelectedItem == null )
        flash.Enabled = false;
      else
        flash.Enabled = true;
    }

    private void Refresh_Click( object sender, EventArgs e )
    {
      ports = SerialPort.GetPortNames();
      comports.Items.Clear();
      foreach ( string port in ports )
      {
        comports.Items.Add(port);
      }
      if ( comports.Items.Count != 0 && comports.SelectedIndex == -1 )
        comports.SelectedIndex = 0;
    }

    private void Config_Click( object sender, EventArgs e )
    {
      flash.Enabled = false;
      compile.Enabled = false;
      cfg.Show();
    }

    private void About_Click( object sender, EventArgs e )
    {
      ab.Show();
    }

    private void Flash_Click( object sender, EventArgs e )
    {
      log.Clear();
      comports.Enabled = false;
      refresh.Enabled = false;
      openhex.Enabled = false;
      flash.Enabled = false;
      config.Enabled = false;
      log_updater.Enabled = false;
      avr_kill.Enabled = true;

      Task.Factory.StartNew(Flasher).ContinueWith(result => End());
    }

    private void Flasher()
    {
      com = com.ToUpper();

      string command = "/c "+ Application.StartupPath.ToString()+"\\files\\avrdude\\avrdude.exe -C avr.cfg -v -p" + cfg.mcu + " -c arduino -P " + com + " -b" + cfg.speed + " -D -Uflash:w:\"" + filename + "\":i";

      log.BeginInvoke((Action)( () =>
       {
         log.AppendText("cmd " + command);
       } ));

      ProcessStartInfo info = new ProcessStartInfo("cmd", command)
      {
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      StringBuilder outputBuilder = new StringBuilder();
      StringBuilder errorBuilder = new StringBuilder();

      Process process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler1);
      process.ErrorDataReceived += new DataReceivedEventHandler(SortOutputHandler1);

      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
    }

    private bool Contains( string text, string find )
    {
      if ( text.Contains(find) )
        return true;
      else
        return false;
    }

    private void End( bool compiler = false )
    {
      onAll();
      if ( !compiler )
      {
        string t = log.Text;
        int error;
        if ( Contains(t, " bytes of flash verified") )
          error = 0;
        else if ( Contains(t, "programmer is not responding") )
          error = 1;
        else if ( Contains(t, "can't open device") )
          error = 2;
        else if ( Contains(t, "getsync()") )
          error = 3;
        else if ( Contains(t, "Expected signature for") )
          error = 4;
        else
          error = 5;
        try
        {
          Common.Files.FileWriter("log.txt", log.Text);
        }
        catch { }
        switch ( error )
        {
          case 0:
            MetroMessageBox.Show(this, "Flash done!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;
          case 1:
            MetroMessageBox.Show(this, "Programmer is not responding!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case 2:
            MetroMessageBox.Show(this, "Check COM-Port connection!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case 3:
            MetroMessageBox.Show(this, "Check baudrate!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case 4:
            MetroMessageBox.Show(this, "Check your avr device!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case 5:
            MetroMessageBox.Show(this, "Unexpected error! Check log!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          default:
            throw new Exception("Something bad happened");
        }
      }
      else
      {
        string t = log2.Text;
        int error;
        if ( Contains(t, "Sketch uses") && Contains(t, "Global variables use") )
          error = 0;
        else if ( Contains(t, "error: expected") && Contains(t, "^") )
          error = 1;
        else
          error = 2;
        try
        {
          Common.Files.FileWriter("compiler-log.txt", log2.Text);
        }
        catch { }
        switch ( error )
        {
          case 0:
            string startup = Application.StartupPath.ToString() + "\\";
            string file = Path.GetFileName(sketchpath.Text);
            try
            {
              Directory.CreateDirectory(startup + "compiled");
            }
            catch { }
            try
            {
              File.Delete(startup + "compiled\\" + file + ".hex");
            }
            catch { }
            File.Move(startup + "files\\compiler\\build\\" + file + ".hex", startup + "compiled\\" + file + ".hex");
            hexpath.BeginInvoke((Action)( () =>
           {
             hexpath.Text = startup + "compiled\\" + file + ".hex";
           } ));
            MetroMessageBox.Show(this, "Compiled! Hex file path: " + startup + "compiled\\" + file + ".hex", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;
          case 1:
            MetroMessageBox.Show(this, "Check your syntax!", "Error while compiling!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case 2:
            MetroMessageBox.Show(this, "Unexpected error! Check log!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          default:
            throw new Exception("Something bad happened");
        }
      }
    }
    private void onAll()
    {
      SetEnabled(comports);
      SetEnabled(config);
      SetEnabled(hexpath);
      SetEnabled(openhex);
      SetEnabled(refresh);
      SetEnabled(flash);
      foreach ( MetroButton b in compilerpanel.Controls.OfType<MetroButton>() )
      {
        SetEnabled(b);
      }
      spinner.BeginInvoke((Action)( () =>
     {
       spinner.Visible = false;
     } ));
    }

    private void Avr_kill_Tick( object sender, EventArgs e )
    {
      foreach ( Process proc in Process.GetProcessesByName("avrdude") )
      {
        proc.Kill();
      }
      avr_kill.Enabled = false;
    }

    private void Main_Load( object sender, EventArgs e )
    {
      try
      {
        int i = 0;
        using ( var f = File.OpenText("avr.cfg") )
        {
          while ( !f.EndOfStream )
          {
            string item = f.ReadLine();
            if ( i == 0 )
            {
              cfg.boardsel.SelectedItem = item;
              cfg.ConfUpdate();
            }
            else if ( i == 1 )
            {
              cfg.themesel.SelectedItem = item;
              cfg.th = item;
            }
            else if ( i == 2 )
            {
              if ( item == "1" && Directory.Exists(Application.StartupPath.ToString() + "\\files\\compiler") )
                cfg.compilersupport = true;
              else
                cfg.compilersupport = false;
            }
            else
            {
              try
              {
                File.Delete("cfg.avrd");
              }
              catch { }
            }
            i++;
          }
        }
        if ( cfg.themesel.SelectedItem.ToString() == "Dark" )
          ThemeChange(MetroThemeStyle.Dark);
        else
          ThemeChange(MetroThemeStyle.Light);
      }
      catch
      {
        File.Delete("cfg.avrd");
      }
    }

    public void ThemeChange( MetroThemeStyle Themes )
    {
      //Main
      tabs.Theme = Themes;
      flasher_tab.Theme = Themes;
      compiler_tab.Theme = Themes;
      Theme = Themes;
      flasherpanel.Theme = Themes;
      compilerpanel.Theme = Themes;
      log.Theme = Themes;
      about.Theme = Themes;
      hexpath.Theme = Themes;

      //Flasher
      foreach ( MetroComboBox c in flasherpanel.Controls.OfType<MetroComboBox>() )
      {
        c.Theme = Themes;
      }
      foreach ( MetroButton b in flasherpanel.Controls.OfType<MetroButton>() )
      {
        b.Theme = Themes;
      }
      //Compiler
      spinner.Theme = Themes;
      foreach ( MetroTextBox c in compilerpanel.Controls.OfType<MetroTextBox>() )
      {
        c.Theme = Themes;
      }
      foreach ( MetroButton b in compilerpanel.Controls.OfType<MetroButton>() )
      {
        b.Theme = Themes;
      }
      //Configuration
      cfg.Theme = Themes;
      cfg.confpanel.Theme = Themes;
      cfg.save.Theme = Themes;
      cfg.reset.Theme = Themes;
      foreach ( MetroComboBox c in cfg.confpanel.Controls.OfType<MetroComboBox>() )
      {
        c.Theme = Themes;
      }
      foreach ( MetroLabel l in cfg.confpanel.Controls.OfType<MetroLabel>() )
      {
        l.Theme = Themes;
      }
      //About
      ab.github.Theme = Themes;
      ab.aboutpanel.Theme = Themes;
      ab.Theme = Themes;
      ab.close.Theme = Themes;
      foreach ( MetroLabel l in ab.aboutpanel.Controls.OfType<MetroLabel>() )
      {
        l.Theme = Themes;
      }
    }

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

    private void Compiler()
    {
      string files = Application.StartupPath.ToString() + "\\files\\compiler\\";
      string customlibs = Application.StartupPath.ToString() + "\\files\\custom\\libs";
      string customhardware = Application.StartupPath.ToString() + "\\files\\custom\\hardware";
      string libs = files + "libs";
      string tools = files + "tools";
      string cache = files + "cache";
      string build = files + "build";
      string toolsavr = files + "hardware\\tools\\avr";
      string hardware = files + "hardware";
      string toolsbuilder = files + "tools-builder";
      string command = "/c " + Path.GetPathRoot(files).Remove(2,1) + " && cd \"" + files + "\" && arduino-builder.exe -compile -fqbn arduino:avr:" + cfg.id + ":cpu=" + cfg.mcu + " -logger=machine -hardware \"" + hardware + "\" -tools \"" + toolsbuilder + "\" -tools \"" + toolsavr + "\" -built-in-libraries \"" + libs + "\" -libraries \"" + customlibs + "\" -warnings=all -build-cache \"" + cache + "\" -build-path \"" + build + "\" -verbose \"" + sketchpath.Text + "\"";

      log2.BeginInvoke((Action)( () =>
     {
       log2.AppendText("cmd " + command);
     } ));

      ProcessStartInfo info = new ProcessStartInfo("cmd", command)
      {
        WorkingDirectory = files,
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      StringBuilder outputBuilder = new StringBuilder();
      StringBuilder errorBuilder = new StringBuilder();

      Process process = new Process
      {
        StartInfo = info
      };
      process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler2);
      process.ErrorDataReceived += new DataReceivedEventHandler(SortOutputHandler2);
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
    }

    private void Compile_Click( object sender, EventArgs e )
    {
      spinner.Visible = true;
      foreach ( MetroButton t in compilerpanel.Controls.OfType<MetroButton>() )
      {
        t.Enabled = false;
      }
      sketchpath.Enabled = false;
      log2.Clear();

      Task.Factory.StartNew(Compiler).ContinueWith(result => End(true));
    }

    private void Tabs_SelectedIndexChanged( object sender, EventArgs e )
    {
      if ( tabs.SelectedIndex == 1 && !cfg.compilersupport )
      {
        tabs.SelectedIndex = 0;
        MetroMessageBox.Show(this, "To use compiler, you need to download its files. Reset settings in \"Configuration\".", "No compiler's files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    // // // // HELP FUNCTIONS \\ \\ \\ \\

    private void SortOutputHandler1( object sendingProcess, DataReceivedEventArgs outLine )
    {
      StringBuilder sortOutput = new StringBuilder("");
      if ( log.InvokeRequired )
      { log.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler1), new[] { sendingProcess, outLine }); }
      else
      {
        sortOutput.Append(Environment.NewLine + outLine.Data);
        log.AppendText(sortOutput.ToString());
      }
    }

    private void SortOutputHandler2( object sendingProcess, DataReceivedEventArgs outLine )
    {
      StringBuilder sortOutput = new StringBuilder("");
      if ( log2.InvokeRequired )
      { log2.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler2), new[] { sendingProcess, outLine }); }
      else
      {
        sortOutput.Append(Environment.NewLine + outLine.Data);
        log2.AppendText(sortOutput.ToString());
      }
    }

    private void SetEnabled( Button b )
    {
      b.BeginInvoke((Action)( () =>
       {
         b.Enabled = true;
       } ));
    }
    private void SetEnabled( ComboBox b )
    {
      b.BeginInvoke((Action)( () =>
       {
         b.Enabled = true;
       } ));
    }
    private void SetEnabled( MetroTextBox b )
    {
      b.BeginInvoke((Action)( () =>
       {
         b.Enabled = true;
       } ));
    }
  }
}
