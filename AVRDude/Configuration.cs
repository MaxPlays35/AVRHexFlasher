// Created with love <3

using System;
using System.IO;
using System.Windows.Forms;
using AlexeyZavar.MainLib;
using MetroFramework.Forms;

namespace AVRDude
{
  /// <summary>
  /// Defines the <see cref="Configuration"/>
  /// </summary>
  public partial class Configuration : MetroForm
  {
    /// <summary>
    /// Compiler support
    /// </summary>
    public bool compilersupport = false;

    /// <summary>
    /// Creates <see cref="Configuration"/> form.
    /// </summary>
    public Configuration()
    {
      var m = Owner as Main;
      InitializeComponent();
    }

    /// <summary>
    /// Gets the id
    /// </summary>
    public string id { get; private set; }

    /// <summary>
    /// Gets the mcu
    /// </summary>
    public string mcu { get; private set; }

    /// <summary>
    /// Gets the speed
    /// </summary>
    public string speed { get; private set; }

    /// <summary>
    /// Gets or sets the th
    /// </summary>
    public string th { get; set; }

    /// <summary>
    /// Config updater
    /// </summary>
    public void ConfUpdate()
    {
      var b = new Board();
      BoardsParser.Parse().TryGetValue(boardsel.SelectedItem.ToString(), out b);
      speed = b.Speed;
      mcu = b.Mcu;
      id = b.ID;
    }

    /// <summary>
    /// Boardsel_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Boardsel_SelectedIndexChanged( object sender, EventArgs e )
    {
      ConfUpdate();
    }

    /// <summary>
    /// Configuration_FormClosing
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="FormClosingEventArgs"/>
    /// </param>
    private void Configuration_FormClosing( object sender, FormClosingEventArgs e )
    {
      Hide();
    }

    /// <summary>
    /// Reset button
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Reset_Click( object sender, EventArgs e )
    {
      try
      {
        File.Delete("avr.cfg");
      }
      catch
      {
      }

      Application.Restart();
    }

    /// <summary>
    /// Saves config
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Save_Click( object sender, EventArgs e )
    {
      if ( th != themesel.SelectedItem.ToString() ) Application.Restart();
      try
      {
        File.Delete("avr.cfg");
      }
      catch
      {
      }

      Common.Files.FileWriter("avr.cfg",
        boardsel.SelectedItem + "\n" + themesel.SelectedItem + "\n" + ( compilersupport ? "1" : "0" ));
      Program.m.flash.Enabled = true;
      Program.m.compile.Enabled = true;
      Hide();
    }
  }
}
