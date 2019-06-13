// Created with love <3

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AVRHexFlasher
{
  public class Logger
  {
    public enum LogType
    {
      Info,
      Warning,
      Error,
      Fatal
    }

    public static int ErrorCountReader()
    {
      if ( !File.Exists("count") )
        return 0;
      var s = "";
      Thread.Sleep(500);
      using ( var sr = new StreamReader("count", Encoding.Default) )
      {
        s = sr.ReadToEnd();
      }

      var i = s != "" ? Convert.ToInt32(s) : 0;
      return i;
    }

    public static void ErrorCountWriter()
    {
      //if ( !File.Exists("count") )
      //  File.Create("count");
      using ( var sr = new StreamWriter("count", false, Encoding.Default) )
      {
        Program.errors++;
        sr.WriteLine(Program.errors);
      }
    }

    public static void ErrorLog( string error )
    {
      using ( var sw = new StreamWriter("fatal_full.txt", false, Encoding.Default) )
      {
        sw.WriteLine(error);
      }
    }

    public static void Log( object msg = null, string prefix = "AVRHexFlasher", LogType type = LogType.Info )
    {
      string _type;
      switch ( type )
      {
        case LogType.Info:
          _type = "Info ";
          break;

        case LogType.Warning:
          _type = "Warn ";
          break;

        case LogType.Error:
          _type = "Error";
          break;

        case LogType.Fatal:
          _type = "Fatal";
          break;

        default:
          throw new InvalidDataException("Logger error"); //never
      }

      object s = $"[Time: {DateTime.Now.ToString()} Type: {_type}] <{prefix}> :  {msg}";
      using ( var sw = new StreamWriter(Avr.LogFile, true, Encoding.Default) )
      {
        sw.WriteLine(s);
      }
    }
  }
}
