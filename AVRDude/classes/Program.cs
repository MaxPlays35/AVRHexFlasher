// Created with love <3

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AVRHexFlasher
{
  internal static class Program
  {
    public static int errors = Logger.ErrorCountReader();

    /// <summary>
    /// Main
    /// </summary>
    [STAThread]
    private static void Main()
    {
      try
      {
        Config.Language = Config.Read(3);
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.Language);
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Config.Language);
        Logger.Log(@"./\.");
        Logger.Log("Initializing...");
        Logger.Log($"Error counter: {errors}");
        if ( errors >= 3 )
        {
          Logger.Log(
            $"Something bad happened. Try to delete '{Config.CfgFile}' or create new issue on GitHub ({Avr.GitUrl}).",
            type: Logger.LogType.Warning);
          File.Delete("count");
          Logger.Log(@".\/.");
          Environment.Exit(1);
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Main());
        Logger.Log(@".\/.");
      }
      catch ( Exception e )
      {
        Logger.Log("!!! FATAL ERROR !!!", type: Logger.LogType.Fatal);
        Logger.Log($"Message: {e.Message}", type: Logger.LogType.Fatal);
        Logger.Log($"Method: {e.TargetSite}", type: Logger.LogType.Fatal);
        Logger.Log("More information in 'fatal_full.txt'", type: Logger.LogType.Fatal);
        Logger.ErrorLog(e.ToString());
        Logger.Log("Your config will be deleted", type: Logger.LogType.Warning);
        if ( File.Exists(Config.CfgFile) )
          File.Delete(Config.CfgFile);
        Logger.Log("!!! FATAL ERROR !!!", type: Logger.LogType.Fatal);
        Logger.ErrorCountWriter();
        Logger.Log(@".\/.");
        Application.Restart();
      }
    }
  }
}
