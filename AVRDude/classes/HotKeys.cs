﻿// Created with love <3

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AVRHexFlasher
{
  public static class HotKeys
  {
    public static void Handler( object sender, KeyEventArgs e )
    {
      if ( e.KeyCode == Keys.F1 && e.Alt )
      {
        if ( File.Exists(Avr.LogFile) )
          File.Delete(Avr.LogFile);
        if ( File.Exists("fatal_full.txt") )
          File.Delete("fatal_full.txt");
        Logger.Log("Log cleared.");
      }

      if ( e.KeyCode == Keys.F2 && e.Alt )
      {
        if ( !Avr.M.refresh.Enabled )
        {
          foreach ( Process p in Process.GetProcessesByName("avrdude") )
            p.Kill();
          Avr.M.log.AppendText(Environment.NewLine);
          Avr.M.log.AppendText(Avr.M.RM.GetString("opCanceled"));
        }

        if ( !Avr.M.opensketch.Enabled )
        {
          foreach ( Process p in Process.GetProcessesByName("arduino-builder") )
            p.Kill();
          Avr.M.log2.AppendText(Environment.NewLine);
          Avr.M.log2.AppendText(Avr.M.RM.GetString("opCanceled"));
        }
      }
    }
  }
}
