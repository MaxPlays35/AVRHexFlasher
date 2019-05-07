using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using AlexeyZavar.MainLib;
using System.IO;

namespace AVRDude
{
  public partial class Configuration : MetroForm
  {
    public string Baud { get { return baudratesel.SelectedItem.ToString(); } }
    public string Processor { get { return procsel.SelectedItem.ToString(); } }

    public Configuration()
    {
      string args = "";
      InitializeComponent();
      try
      {
        args = Common.Files.FileReader("cfg.avrd");
        try
        {
          baudratesel.SelectedItem = args.Substring(0, args.LastIndexOf(','));
          procsel.SelectedItem = args.Substring(0, args.LastIndexOf(','));
        } catch
        {
          try
          {
            File.Delete("cfg.avrd");
          }
          catch { }
        }
      }
      catch { }
    }

    private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
    {
      Hide();
    }

    private void Save_Click(object sender, EventArgs e)
    {
      Common.Files.FileWriter("cfg.avrd", baudratesel.SelectedItem.ToString() + "," + procsel.SelectedItem.ToString());
      Hide();
    }
  }
}
