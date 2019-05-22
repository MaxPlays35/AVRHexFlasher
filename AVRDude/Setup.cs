// Created with love <3

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  /// Defines the <see cref="Setup"/>
  /// </summary>
  public partial class Setup : MetroForm
  {
    /// <summary>
    /// Compiler support
    /// </summary>
    public bool compilersup;

    /// <summary>
    /// Creates <see cref="Setup"/> form.
    /// </summary>
    public Setup()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Compilersupport_CheckedChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Compilersupport_CheckedChanged( object sender, EventArgs e )
    {
      if ( compilersupport.Checked )
      {
        var dr = MetroMessageBox.Show(this,
          "This feature requires to download additional 250 MB on your disk. Continue?", "", MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);
        if ( dr == DialogResult.Yes )
          compilersup = true;
        else
          compilersupport.Checked = false;
      }
    }

    /// <summary>
    /// Done click
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Done_Click( object sender, EventArgs e )
    {
      if ( themesel.SelectedIndex != -1 )
      {
        if ( compilersup )
          try
          {
            if ( File.Exists("compiler.zip") )
              File.Delete("compiler.zip");
            if ( Directory.Exists("files\\compiler") )
              Directory.Delete("files\\compiler");
            var w = new WebClient();
            w.DownloadFile("https://github.com/MaxPlays35/AVRHexFlasher/releases/download/compiler/compiler.zip",
              "compiler.zip");
            ZipFile.ExtractToDirectory("compiler.zip", Application.StartupPath + "\\files\\");
            File.Delete("compiler.zip");
          }
          catch
          {
            MetroMessageBox.Show(this, "Failed to download\\extract compiler files.", "", MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning);
          }

        try
        {
          config.Write(1, "Arduino Nano");
          config.Write(2, themesel.SelectedItem.ToString());
        }
        catch { }

        Application.Restart();
      }
      else
      {
        MetroMessageBox.Show(this, "Theme not selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// GitHub click
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Github_Click( object sender, EventArgs e )
    {
      Process.Start(avr.giturl);
    }
  }
}
