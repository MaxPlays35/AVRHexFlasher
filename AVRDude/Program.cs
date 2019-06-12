// Created with love <3

using System;
using System.IO;
using System.Windows.Forms;

namespace AVRHexFlasher
{
  internal static class Program
  {
    /// <summary>
    /// Main
    /// </summary>
    [STAThread]
    private static void Main()
    {
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Main());
      }
      catch ( Exception e )
      {
        Console.WriteLine(e);
        File.Delete(Config.CfgFile);
        Application.Restart();
      }
    }
  }
}
