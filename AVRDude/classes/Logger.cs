// Created with love <3

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace AVRHexFlasher
{
  /// <summary>
  ///   Defines the <see cref="Logger" />
  /// </summary>
  public static class Logger
  {
    /// <summary>
    ///   The ErrorCountReader
    /// </summary>
    /// <returns>
    ///   The <see cref="int" />
    /// </returns>
    public static int ErrorCountReader()
    {
      if ( !File.Exists( "count" ) )
        return 0;
      string s;
      Thread.Sleep( 500 );

      using ( var sr = new StreamReader( "count", Encoding.Default ) ) { s = sr.ReadToEnd(); }

      var i = s != "" ? Convert.ToInt32( s ) : 0;

      return i;
    }

    /// <summary>
    ///   The ErrorCountWriter
    /// </summary>
    public static void ErrorCountWriter()
    {
      using ( var sr = new StreamWriter( "count", false, Encoding.Default ) )
      {
        //Program.errors++;
        sr.WriteLine( Program.Errors );
      }
    }

    /// <summary>
    ///   The ErrorLog
    /// </summary>
    /// <param name="error">
    ///   The error <see cref="string" />
    /// </param>
    public static void ErrorLog( string error )
    {
      using ( var sw = new StreamWriter( "fatal_full.txt", false, Encoding.Default ) ) { sw.WriteLine( error ); }
    }

    /// <summary>
    ///   The Log
    /// </summary>
    /// <param name="msg">
    ///   The msg <see cref="object" />
    /// </param>
    /// <param name="prefix">
    ///   The prefix <see cref="string" />
    /// </param>
    /// <param name="type">
    ///   The type <see cref="LogType" />
    /// </param>
    public static void Log( object msg = null, string prefix = "AVRHexFlasher", LogType type = LogType.Info )
    {
      string tempType;

      switch ( type )
      {
        case LogType.Info:
          tempType = "Info ";

          break;

        case LogType.Warning:
          tempType = "Warn ";

          break;

        case LogType.Error:
          tempType = "Error";

          break;

        case LogType.Fatal:
          tempType = "Fatal";

          break;

        default:
          throw new InvalidDataException( "Logger error" ); //never
      }

      var s = $"[Time: {DateTime.Now.ToString( CultureInfo.InvariantCulture )} Type: {tempType}] <{prefix}> :  {msg}";

      using ( var sw = new StreamWriter( Avr.LogFile, true, Encoding.Default ) ) { sw.WriteLine( s ); }
    }
  }
}