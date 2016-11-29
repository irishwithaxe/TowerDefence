using UnityEngine;

public class GameManager : MonoBehaviour {

   // Use this for initialization
   private void Start() {
      EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      var ldescr = gameEvent.IsLeftClicked ? " left" : "";
      var rdescr = gameEvent.IsRightClicked ? " right" : "";

      Log.Info("clicked " + gameEvent.tile.Position.ToString() + ldescr + rdescr);
   }

   // Update is called once per frame
   private void Update() {
   }
}