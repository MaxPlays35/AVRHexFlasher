// Created with love <3

using System.Collections.Generic;
using System.IO;

namespace AVRHexFlasher
{
  /// <summary>
  /// Defines the <see cref="Board"/>
  /// </summary>
  public class Board
  {
    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the Mcu
    /// </summary>
    public string Mcu { get; set; }

    /// <summary>
    /// Gets or sets the MDSize
    /// </summary>
    public string MDSize { get; set; }

    /// <summary>
    /// Gets or sets the MSize
    /// </summary>
    public string MSize { get; set; }

    /// <summary>
    /// Gets or sets the Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the Speed
    /// </summary>
    public string Speed { get; set; }
  }

  /// <summary>
  /// Defines the <see cref="BoardsParser"/>
  /// </summary>
  public class BoardsParser
  {
    /// <summary>
    /// Parse from "boards.db"
    /// </summary>
    /// <param name="boardsfile">
    /// Boardsfile <see cref="string"/>
    /// </param>
    /// <returns>
    /// <see cref="Dictionary{string, Board}"/>
    /// </returns>
    public static Dictionary<string, Board> Parse( string boardsfile = "boards.db" )
    {
      var boards = new Dictionary<string, Board>();
      string line;
      var file = new StreamReader(boardsfile);
      while ( ( line = file.ReadLine() ) != null )
      {
        var b = new Board();
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
}
