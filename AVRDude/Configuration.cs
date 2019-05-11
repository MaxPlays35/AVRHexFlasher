using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using AlexeyZavar.MainLib;
using System.IO;

namespace AVRDude
{
  public partial class Configuration : MetroForm
  {
    public string th { get; set; }
    public Configuration()
    {
      Main m = Owner as Main;
      InitializeComponent();
    }

    private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
    {
      Hide();
    }

    private void Save_Click(object sender, EventArgs e)
    {
      if (th != themesel.SelectedItem.ToString() )
      {
        Application.Restart();
      }
      try
      {
        File.Delete("cfg.avrd");
      }
      catch { }
      Common.Files.FileWriter("cfg.avrd", baudratesel.SelectedItem.ToString() + "\n" + procsel.SelectedItem.ToString() + "\n" + themesel.SelectedItem.ToString());
      Hide();
    }
  }
}
