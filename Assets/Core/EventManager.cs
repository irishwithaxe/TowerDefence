using System;

public class EventManager : Singletone<EventManager> {

   public override EventManager Init() {
      return this;
   }

   public delegate void EvArgs<T>(object sender, T gameEvent) where T : GameCoreEvent;

   public event EvArgs<TileClickEvent> OnTileClicked = (s, ge) => { };

   public void TileClicked(object sender, TileClickEvent tce) { OnTileClicked(sender, tce); }

   public event EvArgs<MenuItemClicked> OnMenuItemClicked = (s, ea) => { };

   public void MenuClicked(object sender, MenuItemClicked mic) { OnMenuItemClicked(sender, mic); }
}
