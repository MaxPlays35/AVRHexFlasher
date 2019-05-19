using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework;
using MetroFramework.Forms;

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
      Process.Start("https://https://github.com/MaxPlays35/AVRHexFlasher");
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
        Common.Files.FileWriter("flasher.cfg", "Arduino Nano\n" + themesel.SelectedItem.ToString() + "\n" + (compilersup ? "1" : "0"));
        Application.Restart();
      }
    }
  }
}
