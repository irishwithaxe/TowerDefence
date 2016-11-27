using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   public class MouseClickEvent :GameCoreEvent{
      public bool IsLeftClicked { get; private set; }
      public bool IsRightClicked { get; private set; }

      public MouseClickEvent(bool left= false, bool right = false) : base() {
         IsLeftClicked = left;
         IsRightClicked = right;
      }
   }
