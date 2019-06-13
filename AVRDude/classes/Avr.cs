// Created with love <3

using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    /// <summary>
    /// Defines the LogFile
    /// </summary>
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
        Logger.Log($"Adding language: {lang}");
      }

      //Create folders for compiler
      var dirs = new List<string> {"custom", "custom\\libs", "custom\\hardware"};
      foreach ( var dir in dirs )
        if ( !Directory.Exists("files\\" + dir) )
        {
          Directory.CreateDirectory("files\\" + dir);
          Logger.Log($"Created folder: files\\{dir}");
        }

      Cfg.themeSel.SelectedIndex = 0;

      if ( !File.Exists(Config.CfgFile) )
      {
        Logger.Log("Config file doesn't exists. Showing setup dialog.");
        s.Show();
        M.Controls.Clear();
        M.DisplayHeader = false;
        s.TopMost = true;
        M.Movable = false;
        M.Activated += delegate { s.Activate(); };
        return;
      }

      M.TopMost = true;
      M.Activate();
      Logger.Log("Config file exists.");
      s.Close();

      Logger.Log("Parsing boards.");
      var boards = BoardsParser.Parse();

      foreach ( var b in boards ) Cfg.boardSel.Items.Add(b.Value.Name);
      Cfg.boardSel.SelectedIndex = 0;
      Logger.Log("Boards parsed.");
      try
      {
        Logger.Log("Reading config.");
        Cfg.boardSel.SelectedItem = Config.Read(1);
        Logger.Log($"Board: {Config.Read(1)}");
        Cfg.BoardSel_SelectedIndexChanged(null, null);
        Cfg.themeSel.SelectedIndex = Config.Read(2) == "Light" ? 0 : 1;
        Config.Theme = Config.Read(2) == "Light" ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
        if ( Directory.Exists("files\\compiler") ) Config.CompilerSupport = true;
        ThemeChanger(Config.Theme);
        Cfg.langSel.SelectedItem = Config.Read(3);
        Logger.Log($"Language: {Config.Read(3)}");
      }
      catch
      {
        Logger.Log("Invalid configuration file.");
        MetroMessageBox.Show(M,
          $"Invalid configuration file ({Config.CfgFile}) present. Re-save or reset settings in Configuration.",
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      foreach ( var port in M.Ports ) M.comports.Items.Add(port);
      if ( M.comports.Items.Count != 0 ) M.comports.SelectedIndex = 0;
      Logger.Log("COM-Ports updated.");
      M.TopMost = false;
    }

    /// <summary>
    /// Changes theme
    /// </summary>
    /// <param name="theme">
    /// The theme <see cref="MetroThemeStyle"/>
    /// </param>
    public static void ThemeChanger( MetroThemeStyle theme )
    {
      Logger.Log("Changing theme to " + ( theme == MetroThemeStyle.Light ? "light" : "dark" ));
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
}
