using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using AlexeyZavar.MainLib;
using System.IO;

namespace AVRDude
{
  public partial class Configuration : MetroForm
  {
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
      try
      {
        File.Delete("cfg.avrd");
      }
      catch { }
      Common.Files.FileWriter("cfg.avrd", baudratesel.SelectedItem.ToString() + "\n" + procsel.SelectedItem.ToString());
      Hide();
    }

    private void Configuration_Load(object sender, EventArgs e)
    {
      try
      {
        int i = 0;
        using (var f = File.OpenText("cfg.avrd"))
        {
          while (!f.EndOfStream)
          {
            string line = f.ReadLine();
            if (i == 0)
              baudratesel.SelectedItem = line;
            else
              procsel.SelectedItem = line;
            i++;
          }
        }
      }
      catch
      {
        File.Delete("cfg.avrd");
      }
    }
  }
}
