using System;

   public class Tile {
      public readonly Point Position;
      public readonly TileType Type;

      /// <summary>
      /// Стоимость движения от стартовой позиции (сквозь родителей)
      /// </summary>
      public int G { get; set; }

      /// <summary>
      /// Расстояние до цели
      /// </summary>
      public int H { get; set; }

      /// <summary>
      /// Сумма расстояния до цели и стоимости движения от стартовой позиции
      /// </summary>
      public int F { get; set; }

      public Tile Parent { get; private set; }

      public Tile(uint row, uint col, TileType tt) {
         Position = new Point() { C = col, R = row };
         Type = tt;
      }

      public void LeftMouseClick() {
         var tcea = new TileClickEvent(this, left: true);
         EventManager.Instance.TileClicked(this, tcea);
      }

      public void EmptyValues() {
         G = 0;
         H = 0;
         F = 0;
      }

      public void SetValues(Tile paren, Tile goal, int gCost) {
         G = gCost + Parent.G;
         H = (Math.Abs((int)Position.R - (int)goal.Position.R) + Math.Abs((int)Position.C - (int)goal.Position.C)) * 10;
         F = G + H;
      }
   }
