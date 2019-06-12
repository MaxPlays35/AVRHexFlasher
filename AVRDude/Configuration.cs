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
    /// The BoardSel_SelectedIndexChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    public void BoardSel_SelectedIndexChanged( object sender, EventArgs e )
    {
      BoardsParser.Parse().TryGetValue(boardSel.SelectedItem.ToString(), out var b);
      if ( b != null )
      {
        Config.Speed = b.Speed;
        Config.Mcu = b.Mcu;
        Config.Id = b.Id;
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
      var theme = themeSel.SelectedIndex == 0 ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
      if ( Config.Theme != theme )
        Avr.ThemeChanger(theme);
      Config.Write(1, boardSel.SelectedItem);
      Config.Write(2, themeSel.SelectedItem);
      if ( Config.Language != langSel.SelectedItem.ToString() )
      {
        Config.Write(3, langSel.SelectedItem);
        Application.Restart();
      }

      Config.Write(3, langSel.SelectedItem);
      if ( Avr.M.hexpath.Text != "" && Avr.M.comports.SelectedIndex != -1 )
        Avr.M.flash.Enabled = true;
      if ( Avr.M.sketchpath.Text != "" )
        Avr.M.compile.Enabled = true;
      Hide();
    }
  }
}
