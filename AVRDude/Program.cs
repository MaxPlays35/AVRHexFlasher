using System;
using System.Windows.Forms;

namespace AVRDude
{
  static class Program
  {
    public static Main m;

    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Main());
    }
  }
}
