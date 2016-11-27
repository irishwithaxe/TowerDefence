using UnityEngine;
using GameCore;

public class GameManager : MonoBehaviour {

   // Use this for initialization
   private void Start() {
      EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
   }

   private void EventManager_OnTileClicked(object sender, GameCore.Events.TileClickEvent gameEvent) {
      Log.Info("clicked " + gameEvent.tile.Position.ToString());
   }

   // Update is called once per frame
   private void Update() {
   }
}