using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {
   public Tile Tile { get; set; }

   public Vector3 WorldPosition { get; set; }

   // Use this for initialization
   void Start() {
      EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      TrySetGoal(gameEvent.tile);
   }

   private void TrySetGoal(Tile tile) {
      
   }

   // Update is called once per frame
   void Update() {

   }
}
