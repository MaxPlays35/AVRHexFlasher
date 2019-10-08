// BoardsParser.cs is a part of avr
// 
// Created by AlexeyZavar

#region

using System.Collections.Generic;
using System.IO;

#endregion

namespace AVRHexFlasher
{
  /// <summary>
  ///   Defines the <see cref="Board" />
  /// </summary>
  public class Board
  {
    /// <summary>
    ///   Gets or sets the Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the Mcu
    /// </summary>
    public string Mcu { get; set; }

    /// <summary>
    ///   Gets or sets the Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the Speed
    /// </summary>
    public string Speed { get; set; }
  }

  /// <summary>
  ///   Defines the <see cref="BoardsParser" />
  /// </summary>
  public static class BoardsParser
  {
    /// <summary>
    ///   Parse from "boards.db"
    /// </summary>
    /// <param name="boardsFile">
    ///   The boardsFile <see cref="string" />
    /// </param>
    public static Dictionary<string, Board> Parse(string boardsFile = "files/boards.db")
    {
      var boards = new Dictionary<string, Board>();
      string line;
      var file = new StreamReader( boardsFile );

      var i = 0;
      while ( (line = file.ReadLine()) != null )
      {
        var b = new Board();

        if ( !line.Contains( "[" ) ||
             !line.Contains( "]" ) ) continue;
        b.Id = file.ReadLine();
        b.Name = file.ReadLine();
        b.Mcu = file.ReadLine();
        b.Speed = file.ReadLine();
        boards.Add( b.Name ?? "NoName #" + ++i, b );
      }

      file.Close();

      return boards;
    }
  }
}
