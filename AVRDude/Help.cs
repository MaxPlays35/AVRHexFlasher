using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace AVRDude
{
  public partial class Help : MetroForm
  {
    public Help ()
    {
      Main m = Owner as Main;
      InitializeComponent();
    }

    private void Github_Click ( object sender, EventArgs e )
    {
      Process.Start("https://github.com/MaxPlays35/AVRHexFlasher");
    }

    private void About_FormClosing ( object sender, FormClosingEventArgs e )
    {
      Hide();
    }

    private void Close_Click ( object sender, EventArgs e )
    {
      Hide();
    }
  }
}
