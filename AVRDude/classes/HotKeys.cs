// Created with love <3

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AVRHexFlasher
{
  /// <summary>
  ///   Defines the <see cref="HotKeys" />
  /// </summary>
  public static class HotKeys
  {
    /// <summary>
    ///   The Handler
    /// </summary>
    /// <param name="sender">
    ///   The sender <see cref="object" />
    /// </param>
    /// <param name="e">
    ///   The e <see cref="KeyEventArgs" />
    /// </param>
    public static void Handler( object sender, KeyEventArgs e )
    {
      switch ( e.KeyCode )
      {
        case Keys.F1 when e.Alt:
        {
          if ( File.Exists( Avr.LogFile ) )
            File.Delete( Avr.LogFile );

          if ( File.Exists( "fatal_full.txt" ) )
            File.Delete( "fatal_full.txt" );
          Logger.Log( "Log cleared." );

          break;
        }

        case Keys.F2 when e.Alt:
        {
          if ( !Avr.M.refresh.Enabled )
          {
            foreach ( var p in Process.GetProcessesByName( "avrdude" ) )
              p.Kill();
            Avr.M.log.AppendText( Environment.NewLine );
            Avr.M.log.AppendText( Avr.M.RM.GetString( "opCanceled" ) );
          }

          if ( !Avr.M.opensketch.Enabled )
          {
            foreach ( var p in Process.GetProcessesByName( "arduino-builder" ) )
              p.Kill();
            Avr.M.log2.AppendText( Environment.NewLine );
            Avr.M.log2.AppendText( Avr.M.RM.GetString( "opCanceled" ) );
          }

          break;
        }

        case Keys.F3 when e.Alt:
          if ( Avr.M.sketchpath.Text != "" )
            Avr.M.Compile_Click( null, null );

          if ( Avr.M.hexpath.Text != "" )
            Avr.M.Flash_Click( null, null );

          break;
      }
    }
  }
}