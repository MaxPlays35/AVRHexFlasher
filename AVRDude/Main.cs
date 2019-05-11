using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
    About ab = new About();

    public Main ()
    {
      InitializeComponent();
      cfg.Owner = this;
      cfg.baudratesel.SelectedIndex = 0;
      cfg.procsel.SelectedIndex = 0;
      cfg.themesel.SelectedIndex = 0;

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
      directory.Filter = "firmware|*.hex";
      directory.Title = "Select firmware hexed file";
      directory.FileName = "";
    }

    private void Open_Click ( object sender, EventArgs e )
    {
      if ( directory.ShowDialog() == DialogResult.Cancel )
        return;
      filename = directory.FileName;
      path.Text = filename;
      flash.Enabled = true;
    }

    private void Comports_SelectedIndexChanged ( object sender, EventArgs e )
    {
      com = comports.SelectedItem.ToString();
      File.Delete("log.txt");
      Common.Files.FileWriter("log.txt", "Selected COM port: " + com.ToUpper());
    }

    private void Log_updater_Tick ( object sender, EventArgs e )
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
      if ( path.Text == "" || comports.SelectedItem == null )
        flash.Enabled = false;
      else
        flash.Enabled = true;
    }

    private void Refresh_Click ( object sender, EventArgs e )
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

    private void Config_Click ( object sender, EventArgs e )
    {
      cfg.Show();
    }

    private void About_Click ( object sender, EventArgs e )
    {
      ab.Show();
    }

    private void Flash_Click ( object sender, EventArgs e )
    {
      log.Clear();
      comports.Enabled = false;
      refresh.Enabled = false;
      open.Enabled = false;
      flash.Enabled = false;
      config.Enabled = false;
      log_updater.Enabled = false;
      avr_kill.Enabled = true;

      Task.Factory.StartNew(Flasher).ContinueWith(result => End());
    }

    private void Flasher ()
    {
      try
      {
        int i = 0;
        using ( var f = File.OpenText("flasher.cfg") )
        {
          while ( !f.EndOfStream )
          {
            string line = f.ReadLine();
            if ( i == 0 )
              baudrate = line;
            else if ( i == 1 )
              processor = line;
            i++;
          }
        }
      }
      catch
      {
        MetroMessageBox.Show(this, "Check your configuration!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        onAll();
        Thread.CurrentThread.Abort();
      }
      com = com.ToUpper();

      log.BeginInvoke((Action) ( () =>
        {
          log.AppendText("avrdude.exe -C avr.cfg -v -p" + processor + " -carduino -P " + com + " -b" + baudrate + " -D -Uflash:w:\"" + filename + "\":i" + "\r\n");
        } ));

      ProcessStartInfo info = new ProcessStartInfo("cmd", "/c avrdude.exe -C avr.cfg -v -p" + processor + " -c arduino -P " + com + " -b" + baudrate + " -D -Uflash:w:\"" + filename + "\":i")
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
      process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
      process.ErrorDataReceived += new DataReceivedEventHandler(SortOutputHandler);

      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
    }

    private bool Contain ( string text, string find )
    {
      if ( text.Contains(find) )
        return true;
      else
        return false;
    }

    private void End ()
    {
      onAll();
      string t = log.Text;
      int error;
      if ( Contain(t, " bytes of flash verified") )
        error = 0;
      else if ( Contain(t, "programmer is not responding") )
        error = 1;
      else if ( Contain(t, "can't open device") )
        error = 2;
      else if ( Contain(t, "getsync()") )
        error = 3;
      else if ( Contain(t, "Expected signature for") )
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
          MetroMessageBox.Show(this, "Programmer is not responding", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          MetroMessageBox.Show(this, "Unexpected error!", "Error while flashing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;
        default:
          throw new Exception("Something bad happened");
      }
    }
    private void onAll ()
    {
      SetEnabled(comports);
      SetEnabled(config);
      SetEnabled(path);
      SetEnabled(open);
      SetEnabled(refresh);
      SetEnabled(flash);
    }

    private void SetEnabled ( Button b )
    {
      b.BeginInvoke((Action) ( () =>
      {
        b.Enabled = true;
      } ));
    }
    private void SetEnabled ( ComboBox b )
    {
      b.BeginInvoke((Action) ( () =>
      {
        b.Enabled = true;
      } ));
    }
    private void SetEnabled ( MetroTextBox b )
    {
      b.BeginInvoke((Action) ( () =>
      {
        b.Enabled = true;
      } ));
    }

    private void Avr_kill_Tick ( object sender, EventArgs e )
    {
      foreach ( Process proc in Process.GetProcessesByName("avrdude") )
      {
        proc.Kill();
      }
      avr_kill.Enabled = false;
    }

    private void Main_Load ( object sender, EventArgs e )
    {
      try
      {
        int i = 0;
        using ( var f = File.OpenText("flasher.cfg") )
        {
          while ( !f.EndOfStream )
          {
            string item = f.ReadLine();
            if ( i == 0 )
              cfg.baudratesel.SelectedItem = item;
            else if ( i == 1 )
              cfg.procsel.SelectedItem = item;
            else if ( i == 2 )
            {
              cfg.themesel.SelectedItem = item;
              cfg.th = item;
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

    public void ThemeChange ( MetroThemeStyle Themes )
    {
      //Main
      Theme = Themes;
      mainpanel.Theme = Themes;
      log.Theme = Themes;
      about.Theme = Themes;
      path.Theme = Themes;
      foreach ( MetroComboBox c in mainpanel.Controls.OfType<MetroComboBox>() )
      {
        c.Theme = Themes;
      }
      foreach ( MetroButton b in mainpanel.Controls.OfType<MetroButton>() )
      {
        b.Theme = Themes;
      }
      //Configuration
      cfg.Theme = Themes;
      cfg.confpanel.Theme = Themes;
      cfg.save.Theme = Themes;
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
      foreach ( MetroLabel l in ab.aboutpanel.Controls.OfType<MetroLabel>() )
      {
        l.Theme = Themes;
      }
    }

    private void SortOutputHandler ( object sendingProcess, DataReceivedEventArgs outLine )
    {
      StringBuilder sortOutput = new StringBuilder("");
      if ( log.InvokeRequired )
      { log.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler), new [ ] { sendingProcess, outLine }); }
      else
      {
        sortOutput.Append(Environment.NewLine + outLine.Data);
        log.AppendText(sortOutput.ToString());
      }
    }
  }
}
