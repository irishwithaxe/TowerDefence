public struct Point {
   public int R;
   public int C;

   public Point(int row, int column) {
      R = row;
      C = column;
   }

   public override string ToString() {
      return "r {0} c {1}".F(R, C);
   }

   public static Point operator -(Point p1, Point p2) {
      return new Point(p1.R - p2.R, p1.C - p2.C);
   }

   public static bool operator ==(Point p1, Point p2) {
      return p1.R == p2.R && p1.C == p2.C;
   }

   public static bool operator !=(Point p1, Point p2) {
      return p1.R != p2.R || p1.C != p2.C;
   }

   public override bool Equals(object obj) {
      if (obj == null || !(obj is Point))
         return false;

      Point p = (Point)obj;
      return this == p;
   }

   public override int GetHashCode() {
      return (R + C).GetHashCode();
   }
}
