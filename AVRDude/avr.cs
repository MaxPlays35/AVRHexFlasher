// Created with love <3

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    /// Defines the Languages
    /// </summary>
    public static string[] Languages = {"en-US", "ru-RU"};

    public static string LogFile = "log.txt";

    /// <summary>
    /// Defines the main form
    /// </summary>
    public static Main M;

    /// <summary>
    /// Initialize program
    /// </summary>

    public static void StartUp()
    {
      //Fatal error test
      //string a = null;
      //a.ToString();
      var s = new Setup();
      foreach ( var lang in Languages )
      {
        Cfg.langSel.Items.Add(lang);
        if ( !File.Exists(Config.CfgFile) )
          s.langsel.Items.Add(lang);
      }

      //Create folders for compiler
      var dirs = new List<string> {"custom", "custom\\libs", "custom\\hardware"};
      foreach ( var dir in dirs )
        if ( !Directory.Exists("files\\" + dir) )
          Directory.CreateDirectory("files\\" + dir);
      Cfg.themeSel.SelectedIndex = 0;

      if ( !File.Exists(Config.CfgFile) )
      {
        s.Show();
        M.Controls.Clear();
        M.DisplayHeader = false;
        s.TopMost = true;
        M.Movable = false;
        M.Activated += delegate { s.Activate(); };
        return;
      }
      s.Close();

      var boards = BoardsParser.Parse();
      foreach ( var b in boards ) Cfg.boardSel.Items.Add(b.Value.Name);
      Cfg.boardSel.SelectedIndex = 0;

      try
      {
        Cfg.boardSel.SelectedItem = Config.Read(1);
        Cfg.BoardSel_SelectedIndexChanged(null, null);
        Cfg.themeSel.SelectedIndex = Config.Read(2) == "Light" ? 0 : 1;
        Config.Theme = Config.Read(2) == "Light" ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
        if ( Directory.Exists("files\\compiler") ) Config.CompilerSupport = true;
        ThemeChanger(Config.Theme);
        Cfg.langSel.SelectedItem = Config.Read(3);
      }
      catch
      {
        MetroMessageBox.Show(M,
          "Invalid configuration file (" + Config.CfgFile + ") present. Re-save or reset settings in Configuration.",
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      foreach ( var port in M.Ports ) M.comports.Items.Add(port);
      if ( M.comports.Items.Count != 0 ) M.comports.SelectedIndex = 0;
    }

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
      Config.Theme = theme;
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
    public static bool CompilerSupport;

    /// <summary>
    /// Args count (starts from 1)
    /// </summary>
    private static readonly int args_count = 2;

    /// <summary>
    /// Gets or sets the Id
    /// </summary>
    public static string Id { get; set; }

    /// <summary>
    /// Gets or sets the Language
    /// </summary>
    public static string Language { get; set; }

    /// <summary>
    /// Gets or sets the Mcu
    /// </summary>
    public static string Mcu { get; set; }

    /// <summary>
    /// Gets or sets the Speed
    /// </summary>
    public static string Speed { get; set; }

    /// <summary>
    /// Gets or sets the Theme
    /// </summary>
    public static MetroThemeStyle Theme { get; set; }

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
      if ( !File.Exists(CfgFile) && arg == 3 )
        return "en-US";
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
      if ( !File.Exists(CfgFile) ) throw new Exception("Config file doesn't exists.");
      arg--;
      var lines = File.ReadAllLines(CfgFile).ToList();
      lines[arg] = data.ToString();
      File.WriteAllLines(CfgFile, lines.ToArray());
    }

    /// <summary>
    /// Initializes config file
    /// </summary>
    public static void Write()
    {
      var i = -1;
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
    /// Gets or sets the Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the Mcu
    /// </summary>
    public string Mcu { get; set; }

    /// <summary>
    /// Gets or sets the MdSize
    /// </summary>
    public string MdSize { get; set; }

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
    /// <param name="boardsFile">
    /// The boardsFile <see cref="string"/>
    /// </param>
    /// <returns>
    /// The <see cref="Dictionary{string, Board}"/>
    /// </returns>
    public static Dictionary<string, Board> Parse( string boardsFile = "boards.db" )
    {
      var boards = new Dictionary<string, Board>();
      string line;
      var file = new StreamReader(boardsFile);
      while ( ( line = file.ReadLine() ) != null )
      {
        var b = new Board();
        if ( line.Contains("[") && line.Contains("]") )
        {
          b.Id = file.ReadLine();
          b.Name = file.ReadLine();
          b.Mcu = file.ReadLine();
          b.Speed = file.ReadLine();
          b.MSize = file.ReadLine();
          b.MdSize = file.ReadLine();
          boards.Add(b.Name ?? throw new InvalidOperationException(), b);
        }
      }

      file.Close();
      return boards;
    }
  }
}
