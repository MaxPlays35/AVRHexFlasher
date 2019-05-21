// Created with love <3

using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace AVRDude
{
  /// <summary>
  /// Defines the <see cref="Help"/>
  /// </summary>
  public partial class Help : MetroForm
  {
    /// <summary>
    /// Creates <see cref="Help"/> form.
    /// </summary>
    public Help()
    {
      var m = Owner as Main;
      InitializeComponent();
    }

    /// <summary>
    /// About_FormClosing
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="FormClosingEventArgs"/>
    /// </param>
    private void About_FormClosing( object sender, FormClosingEventArgs e )
    {
      Hide();
    }

    /// <summary>
    /// Close button
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Close_Click( object sender, EventArgs e )
    {
      Hide();
    }

    /// <summary>
    /// Opens GitHub page
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Github_Click( object sender, EventArgs e )
    {
      Process.Start("https://github.com/MaxPlays35/AVRHexFlasher");
    }
  }
}
