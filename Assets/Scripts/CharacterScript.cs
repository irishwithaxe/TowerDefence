using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MovingObject {
   private bool _isCast;

   // Use this for initialization
   void Start() {
      EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      if (gameEvent.tile.Type == TileType.floor) {
         TrySetGoal(gameEvent.tile, (t) => t.Type == TileType.floor ? true : false);
         IsCast = !IsCast;
      }
   }

   private bool IsCast {
      get { return _isCast; }
      set {
         myAnimator.SetBool("cast", value);
         _isCast = value;
      }
   }

   // Update is called once per frame
   void Update() {
      Move();
   }
}
