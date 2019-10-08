// Created with love <3

using System;
using System.IO;
using System.Linq;

using MetroFramework;

namespace AVRHexFlasher
{
  public enum ConfigArg
  {
    Board,
    Theme,
    Language
  }

  /// <summary>
  ///   Defines the <see cref="Config" />
  /// </summary>
  public static class Config
  {
    /// <summary>
    ///   Args count (starts from 1)
    /// </summary>
    private const int ArgsCount = 2;

    /// <summary>
    ///   Path to config
    /// </summary>
    public static string CfgFile = "avr.cfg";

    /// <summary>
    ///   Compiler support
    /// </summary>
    public static bool CompilerSupport;

    /// <summary>
    ///   Gets or sets the Id
    /// </summary>
    public static string Id { get; set; }

    /// <summary>
    ///   Gets or sets the Language
    /// </summary>
    public static string Language { get; set; }

    /// <summary>
    ///   Gets or sets the Mcu
    /// </summary>
    public static string Mcu { get; set; }

    /// <summary>
    ///   Gets or sets the Speed
    /// </summary>
    public static string Speed { get; set; }

    /// <summary>
    ///   Gets or sets the Theme
    /// </summary>
    public static MetroThemeStyle Theme { get; set; }

    /// <summary>
    ///   Initializes config file
    /// </summary>
    public static void Init()
    {
      var i = -1;

      while ( i != ArgsCount )
      {
        i++;
        File.AppendAllText( CfgFile, i + Environment.NewLine );
      }
    }

    /// <summary>
    ///   Read from config
    /// </summary>
    /// <param name="Arg">
    ///   The arg <see cref="int" />
    /// </param>
    /// <returns>
    ///   The <see cref="string" />
    /// </returns>
    public static string Read( ConfigArg Arg )
    {
      var arg = ( int ) Arg + 1;

      if ( !File.Exists( CfgFile ) &&
           arg == 3 )
        return "en-US";
      var i = 0;

      using ( var f = File.OpenText( CfgFile ) )
      {
        while ( !f.EndOfStream )
        {
          i++;
          var line = f.ReadLine();

          if ( i == arg )
            return line;
        }
      }

      throw new Exception( "Argument not found." );
    }

    /// <summary>
    ///   Changes arg
    /// </summary>
    /// <param name="arg">
    ///   The arg <see cref="int" />
    /// </param>
    /// <param name="data">
    ///   The data <see cref="object" />
    /// </param>
    public static void Write( int arg, object data )
    {
      if ( !File.Exists( CfgFile ) ) throw new FileNotFoundException("Can\'t find config file");
      arg--;
      var lines = File.ReadAllLines( CfgFile ).ToList();
      lines[ arg ] = data.ToString();
      File.WriteAllLines( CfgFile, lines.ToArray() );
    }
  }
}