// Created with love <3

using System;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  /// Defines the <see cref="Configuration"/>
  /// </summary>
  public partial class Configuration : MetroForm
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Configuration"/> class.
    /// </summary>
    public Configuration()
    {
      var m = Owner as Main;
      InitializeComponent();
    }

    /// <summary>
    /// Initialization
    /// </summary>
    public void Initialize()
    {
      try
      {
        boardsel.SelectedItem = config.Read(1);
        Boardsel_SelectedIndexChanged(null, null);
        themesel.SelectedItem = config.Read(2);
        config.th = config.Read(2);
        if ( Directory.Exists("files\\compiler") ) config.compilersupport = true;
        avr.ThemeChanger(themesel.SelectedItem.ToString() == "Dark" ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
      }
      catch
      {
        MetroMessageBox.Show(this,
          $"Invalid configuration file ({config.cfgfile}) present. Re-save or reset settings in Configuration.",
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
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
      var b = new Board();
      BoardsParser.Parse().TryGetValue(boardsel.SelectedItem.ToString(), out b);
      config.speed = b.Speed;
      config.mcu = b.Mcu;
      config.id = b.ID;
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
      if ( config.th != themesel.SelectedItem.ToString() )
        avr.ThemeChanger(themesel.SelectedItem.ToString() == "Dark" ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
      config.Write(1, boardsel.SelectedItem);
      config.Write(2, themesel.SelectedItem);

      //Common.Files.FileWriter("avr.cfg",
      //  boardsel.SelectedItem + "\n" + themesel.SelectedItem);
      if ( avr.m.hexpath.Text != "" && avr.m.comports.SelectedIndex != -1 )
        avr.m.flash.Enabled = true;
      if ( avr.m.sketchpath.Text != "" )
        avr.m.compile.Enabled = true;
      Hide();
    }
  }
}
