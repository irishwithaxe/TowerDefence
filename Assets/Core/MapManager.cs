using System;

public class MapManager : Singletone<MapManager> {
   public int Rows { get; private set; }
   public int Cols { get; private set; }

   public Tile[,] Map { get; private set; }

   public Tile CharacterStartPos { get { return Map[5, 11]; } }
   public Tile MonsterStartPos { get { return Map[1, 1]; } }
   public Tile MonsterGoal { get { return Map[9, 16]; } }

   public override MapManager Init() {
      return this;
   }

   public void MakeMap() {
      var mapmask = map1;
      Func<int, int, TileType> _getType = (row, col) => {
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

      Log.Info(" rows: " + Rows + " cols: " + Cols);

      for (int r = 0; r < Rows; r++)
         for (int c = 0; c < Cols; c++)
            Map[r, c] = new Tile(r, c, _getType(r, c));
   }

   private int[,] map1 = new[,] {
     //0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 0
      {0,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0}, // 1
      {0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,1,1,0}, // 2
      {0,1,0,1,1,1,1,1,1,0,1,1,1,1,1,1,0,0}, // 3
      {0,1,0,0,0,0,0,0,1,0,1,1,1,1,0,0,0,0}, // 4
      {0,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,0,0}, // 5
      {0,0,0,0,0,0,1,1,1,0,1,1,1,1,1,1,1,0}, // 6
      {0,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,0}, // 7
      {0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0}, // 8
      {0,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,0}, // 9
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 0
   };
}
