using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using AlexeyZavar.MainLib;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace AVRDude
{
  public partial class Main : MetroForm
  {
    private string filename, com;
    private string[] ports = SerialPort.GetPortNames();
    public string baudrate = "0";
    public string processor = "";
    readonly Configuration cfg = new Configuration();

    public Main ()
    {
      InitializeComponent();
      cfg.baudratesel.SelectedIndex = 0;
      cfg.procsel.SelectedIndex = 0;
      //_writer = new TextBoxStreamWriter(log);
      //Console.SetOut(_writer);

      try
      {
        File.Delete("log.txt");
      }
      catch { }
      foreach ( string port in ports )
      {
        comports.Items.Add(port);
      }
      if (comports.Items.Count != 0)
        comports.SelectedIndex = 0;
      directory.Filter = "firmware|*.hex";
      directory.Title = "Select firmware hexed file";
      directory.FileName = "";
      flash.Enabled = false;
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
      baudrate = cfg.Baud;
      processor = cfg.Processor;
      if ( File.Exists("log.txt") )
      {
        try
        {
          filelog = Common.Files.FileReader("log.txt");
          log.Text = filelog;
        } catch { }
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

    private void About_Click(object sender, EventArgs e)
    {
      MetroMessageBox.Show(this, "Created by AlexeyZabar and MrMaxP", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      //Thread thread = new Thread(new ThreadStart(Flasher));
      //thread.Start();

      Task.Factory.StartNew(Flasher).ContinueWith(result => End());
      //log_updater.Enabled = true;
    }

    private void Flasher ()
    {
      com = com.ToUpper();

      //Console.WriteLine("avrdude.exe -Ccfg.cfg -v -patmega328p -carduino -P " + com + " -b115200 -D -Uflash:w:\"" + filename + "\":i");
      ProcessStartInfo info = new ProcessStartInfo("cmd", "/c avrdude.exe -Ccfg.cfg -v -p" + processor +" -carduino -P " + com + " -b" + baudrate +" -D -Uflash:w:\"" + filename + "\":i")
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
      process.BeginErrorReadLine(); // do this after process.Start()
      process.BeginOutputReadLine();

      process.WaitForExit();
    }

    private void End ()
    {
      string t = log.Text;
      int error;
      switch (t)
      {
        case " bytes of flash verified":
          error = 0;
          break;
        case "programmer is not responding":
          error = 1;
          break;
        case "can't open device":
          error = 2;
          break;
        case "getsync()":
          error = 3;
          break;
        case "Expected signature for":
          error = 4;
          break;
        default:
          error = 5;
          break;
      }
      SetEnabled(comports);
      SetEnabled(config);
      SetEnabled(path);
      SetEnabled(open);
      SetEnabled(refresh);
      SetEnabled(flash);
      try
      {
        Common.Files.FileWriter("log.txt", log.Text);
      } catch { }
      //log_updater.Enabled = true;
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
