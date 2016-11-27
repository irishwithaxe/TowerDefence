using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TileClickEvent : MouseClickEvent {
   public Tile tile { get; private set; }
   public TileClickEvent(Tile t, bool left = false, bool right = false) : base(left, right) {
      tile = t;
   }
}
