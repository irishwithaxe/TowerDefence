using System;

public class MapManager : Singletone<MapManager> {
   public int Rows { get; private set; }
   public int Cols { get; private set; }

   public Tile[,] Map { get; private set; }

   public override MapManager Init() {
      return this;
   }

   public void MakeMap() {
      var mapmask = map1;
      Func<uint, uint, TileType> _getType = (row, col) => {
         var ttype = mapmask[row, col];
         switch (ttype) {
            case 0:
               return TileType.wall;

            case 1:
               return TileType.floor;

            default:
               throw new NotImplementedException("Неожиданный тип ячейки");
         }
      };

      Rows = mapmask.GetLength(0);
      Cols = mapmask.GetLength(1);
      Map = new Tile[Rows, Cols];

      Log.Info("cols: " + Cols + " rows: " + Rows);

      for (uint r = 0; r < Rows; r++)
         for (uint c = 0; c < Cols; c++)
            Map[r, c] = new Tile(r, c, _getType(r, c));
   }

   private int[,] map1 = new[,] {
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,1,1,1,1,0,0,0,0,0,0,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
      {0,0,1,1,1,1,0,0,0,0,0,0,1,1,1,1,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
   };
}
