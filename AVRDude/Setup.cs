using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework;
using MetroFramework.Forms;
using System.IO.Compression;
using System.IO;

namespace AVRDude
{
  public partial class Setup : MetroForm
  {
    public bool compilersup = false;

    public Setup ()
    {
      InitializeComponent();
    }

    private void Github_Click ( object sender, EventArgs e )
    {
      Process.Start("https://github.com/MaxPlays35/AVRHexFlasher");
    }

    private void Compilersupport_CheckedChanged ( object sender, EventArgs e )
    {
      if ( compilersupport.Checked )
      {
        DialogResult dr = MetroMessageBox.Show(this, "This feature requires to download additional 250 MB on your disk. Continue?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if ( dr == DialogResult.Yes )
          compilersup = true;
        else
          compilersupport.Checked = false;
      }
    }

    private void Done_Click ( object sender, EventArgs e )
    {
      if ( themesel.SelectedIndex == -1 )
        MetroMessageBox.Show(this, "Theme not selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else
      {
        if ( compilersup )
        {
          try
          {
            WebClient w = new WebClient();
            w.DownloadFile("https://github.com/MaxPlays35/AVRHexFlasher/releases/download/compiler/compiler.zip", "compiler.zip");
            ZipFile.ExtractToDirectory("compiler.zip", Application.StartupPath.ToString() + "\\files\\");
            File.Delete("compiler.zip");
          } catch { MetroMessageBox.Show(this, "Failed to download\\extract compiler files.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }
        }
        Common.Files.FileWriter("avr.cfg", "Arduino Nano\n" + themesel.SelectedItem.ToString() + "\n" + (compilersup ? "1" : "0"));
        Application.Restart();
      }
    }
  }
}
