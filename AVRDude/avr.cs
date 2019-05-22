// Created with love <3

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Interfaces;

namespace AVRHexFlasher
{
  /// <summary>
  /// Defines the <see cref="Avr"/>
  /// </summary>
  public static class Avr
  {
    /// <summary>
    /// Defines the cfg form
    /// </summary>
    public static Configuration Cfg;

    /// <summary>
    /// Defines the GitHub URL
    /// </summary>
    public static string GitUrl = "https://github.com/MaxPlays35/AVRHexFlasher";

    /// <summary>
    /// Defines the help form
    /// </summary>
    public static Help Help;

    /// <summary>
    /// Defines the main form
    /// </summary>
    public static Main M;

    /// <summary>
    /// Changes theme
    /// </summary>
    /// <param name="theme">
    /// The theme <see cref="MetroThemeStyle"/>
    /// </param>
    public static void ThemeChanger( MetroThemeStyle theme )
    {
      //Main
      M.Theme = theme;
      foreach ( var control in M.Controls.OfType<IMetroControl>() )
        control.Theme = theme;
      foreach ( var tab in M.tabs.Controls.OfType<MetroTabPage>() )
      {
        tab.Theme = theme;
        foreach ( var panel in tab.Controls.OfType<MetroPanel>() )
        {
          panel.Theme = theme;
          foreach ( var control in panel.Controls.OfType<IMetroControl>() ) control.Theme = theme;
        }
      }

      //Configuration
      Cfg.Theme = theme;
      Cfg.confpanel.Theme = theme;
      foreach ( var control in Cfg.confpanel.Controls.OfType<IMetroControl>() )
        control.Theme = theme;

      //About
      Help.Theme = theme;
      Help.helpanel.Theme = theme;
      foreach ( var control in Help.helpanel.Controls.OfType<IMetroControl>() )
        control.Theme = theme;
      Config.CurrentTheme = theme == MetroThemeStyle.Dark ? "Dark" : "Light";
      M.Refresh();
      Cfg.Refresh();
      Help.Refresh();
    }
  }

  /// <summary>
  /// Defines the <see cref="Config"/>
  /// </summary>
  public static class Config
  {
    /// <summary>
    /// Path to config
    /// </summary>
    public static string CfgFile = "avr.cfg";

    /// <summary>
    /// Compiler support
    /// </summary>
    public static bool CompilerSupport = false;

    /// <summary>
    /// Args count (starts from 1)
    /// </summary>
    private static readonly int args_count = 2;

    /// <summary>
    /// Gets or sets the CurrentTheme
    /// </summary>
    public static string CurrentTheme { get; set; }

    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    public static string ID { get; set; }

    /// <summary>
    /// Gets or sets the Mcu
    /// </summary>
    public static string Mcu { get; set; }

    /// <summary>
    /// Gets or sets the Speed
    /// </summary>
    public static string Speed { get; set; }

    /// <summary>
    /// Read from config
    /// </summary>
    /// <param name="arg">
    /// The arg <see cref="int"/>
    /// </param>
    /// <returns>
    /// The <see cref="string"/>
    /// </returns>
    public static string Read( int arg )
    {
      var i = 0;
      using ( var f = File.OpenText(CfgFile) )
      {
        while ( !f.EndOfStream )
        {
          i++;
          var line = f.ReadLine();
          if ( i == arg )
            return line;
        }
      }

      throw new Exception("Argument not found.");
    }

    /// <summary>
    /// Changes arg
    /// </summary>
    /// <param name="arg">
    /// The arg <see cref="int"/>
    /// </param>
    /// <param name="data">
    /// The data <see cref="object"/>
    /// </param>
    public static void Write( int arg, object data )
    {
      if ( File.Exists(CfgFile) )
      {
        arg--;
        var lines = File.ReadAllLines(CfgFile).ToList();
        lines[arg] = data.ToString();
        File.WriteAllLines(CfgFile, lines.ToArray());
      }
      else
      {
        throw new Exception("Config file doesn't exists.");
      }
    }

    /// <summary>
    /// Initializes config file
    /// </summary>
    public static void Write()
    {
      var i = 0;
      while ( i != args_count )
      {
        i++;
        File.AppendAllText(CfgFile, i + Environment.NewLine);
      }
    }
  }

  /// <summary>
  /// Defines the <see cref="Board"/>
  /// </summary>
  public class Board
  {
    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the Mcu
    /// </summary>
    public string Mcu { get; set; }

    /// <summary>
    /// Gets or sets the MDSize
    /// </summary>
    public string MDSize { get; set; }

    /// <summary>
    /// Gets or sets the MSize
    /// </summary>
    public string MSize { get; set; }

    /// <summary>
    /// Gets or sets the Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the Speed
    /// </summary>
    public string Speed { get; set; }
  }

  /// <summary>
  /// Defines the <see cref="BoardsParser"/>
  /// </summary>
  public class BoardsParser
  {
    /// <summary>
    /// Parse from "boards.db"
    /// </summary>
    /// <param name="boards_file">
    /// The boards_file <see cref="string"/>
    /// </param>
    /// <returns>
    /// The <see cref="Dictionary{string, Board}"/>
    /// </returns>
    public static Dictionary<string, Board> Parse( string boards_file = "boards.db" )
    {
      var boards = new Dictionary<string, Board>();
      string line;
      var file = new StreamReader(boards_file);
      while ( ( line = file.ReadLine() ) != null )
      {
        var b = new Board();
        if ( line.Contains("[") && line.Contains("]") )
        {
          b.ID = file.ReadLine();
          b.Name = file.ReadLine();
          b.Mcu = file.ReadLine();
          b.Speed = file.ReadLine();
          b.MSize = file.ReadLine();
          b.MDSize = file.ReadLine();
          boards.Add(b.Name ?? throw new InvalidOperationException(), b);
        }
      }

      file.Close();
      return boards;
    }
  }
}
