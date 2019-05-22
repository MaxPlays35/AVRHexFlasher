// Created with love <3

using System.IO;
using System.Linq;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Interfaces;

namespace AVRHexFlasher
{
  public static class avr
  {
    public static Configuration cfg;
    public static string giturl = "https://github.com/MaxPlays35/AVRHexFlasher";
    public static Help help;
    public static Main m;

    /// <summary>
    /// Changes theme
    /// </summary>
    /// <param name="theme">
    /// Theme type <see cref="MetroThemeStyle"/>
    /// </param>
    public static void ThemeChanger( MetroThemeStyle theme )
    {
      //Main
      m.Theme = theme;
      foreach ( var control in m.Controls.OfType<IMetroControl>() )
        control.Theme = theme;
      foreach ( var tab in m.tabs.Controls.OfType<MetroTabPage>() )
      {
        tab.Theme = theme;
        foreach ( var panel in tab.Controls.OfType<MetroPanel>() )
        {
          panel.Theme = theme;
          foreach ( var control in panel.Controls.OfType<IMetroControl>() ) control.Theme = theme;
        }
      }

      //Configuration
      cfg.Theme = theme;
      cfg.confpanel.Theme = theme;
      foreach ( var control in cfg.confpanel.Controls.OfType<IMetroControl>() )
        control.Theme = theme;

      //About
      help.Theme = theme;
      help.helpanel.Theme = theme;
      foreach ( var control in help.helpanel.Controls.OfType<IMetroControl>() )
        control.Theme = theme;
      //Works only 1 try
      config.th = theme == MetroThemeStyle.Dark ? "Dark" : "Light";
      m.Refresh();
      cfg.Refresh();
      help.Refresh();
    }
  }

  public static class config
  {
    /// <summary>
    /// Path to config
    /// </summary>
    public static string cfgfile = "avr.cfg";

    /// <summary>
    /// Compiler support
    /// </summary>
    public static bool compilersupport = false;

    /// <summary>
    /// Gets the id
    /// </summary>
    public static string id { get; set; }

    /// <summary>
    /// Gets the mcu
    /// </summary>
    public static string mcu { get; set; }

    /// <summary>
    /// Gets the speed
    /// </summary>
    public static string speed { get; set; }

    /// <summary>
    /// Gets or sets the th
    /// </summary>
    public static string th { get; set; }

    public static string Read( int arg )
    {
      var i = 0;
      using ( var f = File.OpenText(cfgfile) )
      {
        while ( !f.EndOfStream )
        {
          i++;
          var line = f.ReadLine();
          if ( i == arg )
            return line;
        }
      }

      return "error";
    }
  }
}
