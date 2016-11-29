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

   public Tile(int row, int column, TileType tt) {
      Position = new Point() { C = column, R = row };
      Type = tt;
   }

   public void LeftMouseClick() {
      var tcea = new TileClickEvent(this, left: true);
      EventManager.Instance.TileClicked(this, tcea);
   }

   public void RightMouseClick() {
      var tcea = new TileClickEvent(this, right: true);
      EventManager.Instance.TileClicked(this, tcea);
   }

   public void EmptyValues() {
      G = 0;
      H = 0;
      F = 0;
   }

   public void SetValues(Tile parent, Tile goal, int gCost) {
      Parent = parent;

      G = gCost + Parent.G;
      H = (Math.Abs((int)Position.R - (int)goal.Position.R) + Math.Abs((int)Position.C - (int)goal.Position.C)) * 10;
      F = G + H;
   }

   public static bool operator ==(Tile t1, Tile t2) {
      return t1.Equals(t2);
   }

   public static bool operator !=(Tile t1, Tile t2) {
      return !t1.Equals(t2);
   }

   public override int GetHashCode() {
      return Position.GetHashCode();
   }

   public override bool Equals(object obj) {
      if (obj == null)
         return false;

      var t = obj as Tile;
      if (t == null)
         return false;

      return Position == t.Position;
   }

   public override string ToString() {
      return "{0}".F(Position.ToString());
   }
}
