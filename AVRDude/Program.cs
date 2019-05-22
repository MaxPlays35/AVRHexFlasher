// Created with love <3

using System;
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
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Main());
    }
  }
}
