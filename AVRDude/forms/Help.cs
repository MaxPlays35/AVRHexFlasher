// Help.cs is a part of avr
// 
// Created by AlexeyZavar

#region

using System;
using System.Diagnostics;
using MetroFramework.Forms;

#endregion

namespace AVRHexFlasher
{
  /// <summary>
  ///   Defines the <see cref="Help" />
  /// </summary>
  public partial class Help : MetroForm
  {
    /// <summary>
    ///   Creates <see cref="Help" /> form.
    /// </summary>
    public Help()
    {
      InitializeComponent();
    }

    /// <summary>
    ///   Close button
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Close_Click(object sender, EventArgs e)
    {
      Hide();
    }

    /// <summary>
    ///   Opens GitHub page
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="EventArgs" />
    /// </param>
    private void Github_Click(object sender, EventArgs e)
    {
      Process.Start( Avr.GitUrl );
    }
  }
}
