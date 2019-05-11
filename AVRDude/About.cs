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
using MetroFramework;
using MetroFramework.Forms;

namespace AVRDude
{
  public partial class About : MetroForm
  {
    public About ()
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
  }
}
