using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MenuItemClicked : MouseClickEvent {
   public string MenuItemName { get; private set; }

   public MenuItemClicked(string itemName) : base(left: true) {
      MenuItemName = itemName;
   }
}
