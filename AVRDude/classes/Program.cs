// Created with love <3

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using MetroFramework;

namespace AVRHexFlasher
{
  /// <summary>
  ///   Defines the <see cref="Program" />
  /// </summary>
  internal static class Program
  {
    /// <summary>
    ///   Defines the errors
    /// </summary>
    public static int errors = Logger.ErrorCountReader();

    /// <summary>
    ///   Main
    /// </summary>
    [STAThread]
    private static void Main()
    {
      var mutexobj = new Mutex( true, "AVRHexFlasher", out var notExists );

      try
      {
        Config.Language                       = Config.Read( ConfigArg.Language );
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( Config.Language );
        Thread.CurrentThread.CurrentCulture   = CultureInfo.GetCultureInfo( Config.Language );
        Logger.Log( @"./\." );
        Logger.Log( "Initializing..." );
        Logger.Log( $"Error counter: {errors}" );

        if ( errors >= 3 )
        {
          Logger.Log(
            $"Something bad happened. Try to delete '{Config.CfgFile}' or create new issue on GitHub ({Avr.GitUrl}).",
            type: LogType.Warning );
          File.Delete( "count" );
          Logger.Log( @".\/." );
          Environment.Exit( 1 );
        }

        if ( !notExists )
        {
          MessageBox.Show( "One copy of the program is already running." );

          Logger.Log(
            "One copy of the program is already running.",
            type: LogType.Warning );
          Environment.Exit( 1 );
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );
        Application.Run( new Main() );

        if ( File.Exists( "count" ) )
          File.Delete( "count" );

        if ( File.Exists( "fatal_full.txt" ) )
          File.Delete( "fatal_full.txt" );
        mutexobj.Dispose();
        Logger.Log( @".\/." );
      }
      catch ( Exception e )
      {
        Logger.Log( "!!! FATAL ERROR !!!",                  type: LogType.Fatal );
        Logger.Log( $"Message: {e.Message}",                type: LogType.Fatal );
        Logger.Log( $"Method: {e.TargetSite}",              type: LogType.Fatal );
        Logger.Log( "More information in 'fatal_full.txt'", type: LogType.Fatal );
        Logger.ErrorLog( e.ToString() );
        Logger.Log( "Your config will be deleted", type: LogType.Warning );

        if ( File.Exists( Config.CfgFile ) )
          File.Delete( Config.CfgFile );
        Logger.Log( "!!! FATAL ERROR !!!", type: LogType.Fatal );
        Logger.ErrorCountWriter();
        Logger.Log( @".\/." );

        MetroMessageBox.Show( Avr.M, "Fatal error. Check log for more details.", "Fatal error", MessageBoxButtons.OK,
                              MessageBoxIcon.Error );
        mutexobj.Dispose();
        Application.Restart();
      }
    }
  }
}