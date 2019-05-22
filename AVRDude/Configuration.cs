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
      InitializeComponent();
    }

    /// <summary>
    /// Initialization
    /// </summary>
    public void Initialize()
    {
      try
      {
        boardsel.SelectedItem = Config.Read(1);
        Boardsel_SelectedIndexChanged(null, null);
        themesel.SelectedItem = Config.Read(2);
        Config.CurrentTheme = Config.Read(2);
        if ( Directory.Exists("files\\compiler") ) Config.CompilerSupport = true;
        Avr.ThemeChanger(themesel.SelectedItem.ToString() == "Dark" ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
      }
      catch
      {
        MetroMessageBox.Show(this,
          "Invalid configuration file (" + Config.CfgFile + ") present. Re-save or reset settings in Configuration.",
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
      Board b;
      BoardsParser.Parse().TryGetValue(boardsel.SelectedItem.ToString(), out b);
      if ( b != null )
      {
        Config.Speed = b.Speed;
        Config.Mcu = b.Mcu;
        Config.ID = b.ID;
      }
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
      if ( File.Exists(Config.CfgFile) )
        File.Delete(Config.CfgFile);

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
      if ( Config.CurrentTheme != themesel.SelectedItem.ToString() )
        Avr.ThemeChanger(themesel.SelectedItem.ToString() == "Dark" ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
      Config.Write(1, boardsel.SelectedItem);
      Config.Write(2, themesel.SelectedItem);
      if ( Avr.M.hexpath.Text != "" && Avr.M.comports.SelectedIndex != -1 )
        Avr.M.flash.Enabled = true;
      if ( Avr.M.sketchpath.Text != "" )
        Avr.M.compile.Enabled = true;
      Hide();
    }
  }
}
