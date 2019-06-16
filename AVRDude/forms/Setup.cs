// Created with love <3

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
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
    /// Defines the _compilersup
    /// </summary>
    private bool _compilersup;

    /// <summary>
    /// Initializes a new instance of the <see cref="Setup"/> class.
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
      if ( !compilersupport.Checked ) return;
      if ( MetroMessageBox.Show(this,
            "This feature requires to download additional 250 MB on your disk. Continue?", "", MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes )
        _compilersup = true;
      else
        compilersupport.Checked = false;
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
      if ( themesel.SelectedItem.ToString() == "" )
      {
        MetroMessageBox.Show(this, "Theme not selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if ( langsel.SelectedItem.ToString() == "" )
      {
        MetroMessageBox.Show(this, "Language not selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if ( _compilersup )
        Task.Factory.StartNew(Download);
      else
        End();
    }

    /// <summary>
    /// The Download
    /// </summary>
    private void Download()
    {
      try
      {
        if ( File.Exists("compiler.zip") )
          File.Delete("compiler.zip");
        if ( Directory.Exists("files\\compiler") )
          Directory.Delete("files\\compiler", true);
        download_progress.Invoke(
          (MethodInvoker)delegate { download_progress.Visible = true; });
        var w = new WebClient();
        // Download with progress callback
        w.DownloadFileAsync(
          new Uri("https://github.com/MaxPlays35/AVRHexFlasher/releases/download/compiler/compiler.zip"),
          "compiler.zip");
        w.DownloadProgressChanged += DownloadProgressChanged;
        w.DownloadFileCompleted += Extract;
      }
      catch
      {
        MetroMessageBox.Show(this, "Failed to download\\extract compiler's files.", "", MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
      }
    }

    /// <summary>
    /// The DownloadProgressChanged
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="DownloadProgressChangedEventArgs"/>
    /// </param>
    private void DownloadProgressChanged( object sender, DownloadProgressChangedEventArgs e )
    {
      download_progress.Invoke((MethodInvoker)delegate { download_progress.Maximum = (int)e.TotalBytesToReceive; });
      download_progress.Invoke((MethodInvoker)delegate { download_progress.Value = (int)e.BytesReceived; });
    }

    /// <summary>
    /// The End
    /// </summary>
    private void End()
    {
      Config.Write();
      Config.Write(1, "Arduino Nano");
      Config.Write(2, themesel.SelectedItem.ToString());
      Config.Write(3, langsel.SelectedItem.ToString());

      Application.Restart();
      Environment.Exit(0);
    }

    /// <summary>
    /// The Extract
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="AsyncCompletedEventArgs"/>
    /// </param>
    private void Extract( object sender, AsyncCompletedEventArgs e )
    {
      ZipFile.ExtractToDirectory("compiler.zip", $"{Application.StartupPath}\\files\\");
      File.Delete("compiler.zip");
      End();
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
      Process.Start(Avr.GitUrl);
    }

    /// <summary>
    /// The Setup_Shown
    /// </summary>
    /// <param name="sender">
    /// The sender <see cref="object"/>
    /// </param>
    /// <param name="e">
    /// The e <see cref="EventArgs"/>
    /// </param>
    private void Setup_Shown( object sender, EventArgs e )
    {
      Avr.M.Hide();
    }
  }
}
