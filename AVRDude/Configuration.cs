using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework.Forms;

namespace AVRDude
{
  public partial class Configuration : MetroForm
  {
    public string th { get; set; }

    public bool compilersupport = false;
    public string speed { get; private set; }
    public string mcu { get; private set; }
    public string id {get; private set; }

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
      Common.Files.FileWriter("flasher.cfg", boardsel.SelectedItem.ToString() + "\n" + themesel.SelectedItem.ToString() + "\n" + ( compilersupport ? "1" : "0" ));
      Hide();
    }

    private void Boardsel_SelectedIndexChanged ( object sender, EventArgs e )
    {
      ConfUpdate();
    }
    public void ConfUpdate ()
    {
      Board b = new Board();
      BoardsParser.Parse().TryGetValue(boardsel.SelectedItem.ToString(), out b);
      this.speed = b.Speed;
      this.mcu = b.Mcu;
      this.id = b.ID;
    }

    private void Reset_Click ( object sender, EventArgs e )
    {
      try
      {
        File.Delete("flasher.cfg");
      } catch {  }
      Application.Restart();
    }
  }
}
