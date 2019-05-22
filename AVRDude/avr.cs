// Created with love <3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Controls;

namespace AVRHexFlasher
{
  public static class avr
  {
    public static Configuration cfg;
    public static Help help;
    public static Main m;

    /// <summary>
    /// Changes theme
    /// </summary>
    /// <param name="Themes">
    /// Theme type <see cref="MetroThemeStyle"/>
    /// </param>
    public static void ThemeChange( MetroThemeStyle Themes )
    {
      //Main
      m.tabs.Theme = Themes;
      m.flasher_tab.Theme = Themes;
      m.compiler_tab.Theme = Themes;
      m.Theme = Themes;
      m.flasherpanel.Theme = Themes;
      m.compilerpanel.Theme = Themes;
      m.log.Theme = Themes;
      m.about.Theme = Themes;
      m.hexpath.Theme = Themes;

      //Flasher
      foreach ( var c in m.flasherpanel.Controls.OfType<MetroComboBox>() ) c.Theme = Themes;
      foreach ( var b in m.flasherpanel.Controls.OfType<MetroButton>() ) b.Theme = Themes;
      //Compiler
      m.spinner.Theme = Themes;
      foreach ( var c in m.compilerpanel.Controls.OfType<MetroTextBox>() ) c.Theme = Themes;
      foreach ( var b in m.compilerpanel.Controls.OfType<MetroButton>() ) b.Theme = Themes;
      //Configuration
      cfg.Theme = Themes;
      cfg.confpanel.Theme = Themes;
      cfg.save.Theme = Themes;
      cfg.reset.Theme = Themes;
      foreach ( var c in cfg.confpanel.Controls.OfType<MetroComboBox>() ) c.Theme = Themes;
      foreach ( var l in cfg.confpanel.Controls.OfType<MetroLabel>() ) l.Theme = Themes;
      //About
      help.github.Theme = Themes;
      help.aboutpanel.Theme = Themes;
      help.Theme = Themes;
      help.close.Theme = Themes;
      foreach ( var l in help.aboutpanel.Controls.OfType<MetroLabel>() ) l.Theme = Themes;
    }
  }
}
