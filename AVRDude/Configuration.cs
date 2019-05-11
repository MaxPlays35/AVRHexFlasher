using System;
using System.IO;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework.Forms;

namespace AVRDude
{
  public partial class Configuration : MetroForm
  {
    public string th { get; set; }
    public Configuration ()
    {
      Main m = Owner as Main;
      InitializeComponent();
    }

    private void Configuration_FormClosing ( object sender, FormClosingEventArgs e )
    {
      Hide();
    }

    private void Save_Click ( object sender, EventArgs e )
    {
      if ( th != themesel.SelectedItem.ToString() )
      {
        Application.Restart();
      }
      try
      {
        File.Delete("flasher.cfg");
      }
      catch { }
      Common.Files.FileWriter("flasher.cfg", baudratesel.SelectedItem.ToString() + "\n" + procsel.SelectedItem.ToString() + "\n" + themesel.SelectedItem.ToString());
      Hide();
    }
  }
}
