using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRDude
{
  public class BoardsParser
  {
    public static Dictionary<string, Board> Parse ( string boardsfile = "boards.db" )
    {
      Dictionary<string, Board> boards = new Dictionary<string, Board>();
      string line;
      StreamReader file = new StreamReader(boardsfile);
      while ( ( line = file.ReadLine() ) != null )
      {
        Board b = new Board();
        if ( line.Contains("[") && line.Contains("]") )
        {
          b.ID = file.ReadLine();
          b.Name = file.ReadLine();
          b.Mcu = file.ReadLine();
          b.Speed = file.ReadLine();
          b.MSize = file.ReadLine();
          b.MDSize = file.ReadLine();
          boards.Add(b.Name, b);
        }
      }
      file.Close();
      return boards;
    }
  }
  public class Board
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Mcu { get; set; }
    public string MSize { get; set; }
    public string MDSize { get; set; }
    public string Speed { get; set; }

  }
}
