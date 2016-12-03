using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MovingObject {
   private bool _isCast = false;
   private bool _isReadyForSetGoal = false;

   // Use this for initialization
   void Start() {
      EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
      EventManager.Instance.OnMenuItemClicked += Instance_OnMenuItemClicked;
   }

   private void Instance_OnMenuItemClicked(object sender, MenuItemClicked gameEvent) {
      if (gameEvent.MenuItemName == MenuNames.movebtn)
         IsReadyForSetGoal = true;
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      if (gameEvent.tile.Type == TileType.floor && IsReadyForSetGoal) {
         TrySetGoal(gameEvent.tile, (t) => t.Type == TileType.floor ? true : false);
         IsCast = !IsCast;
         IsReadyForSetGoal = false;
      }
   }

   private bool IsCast {
      get { return _isCast; }
      set {
         myAnimator.SetBool("cast", value);
         _isCast = value;
      }
   }

   public bool IsReadyForSetGoal {
      get { return _isReadyForSetGoal; }
      set { _isReadyForSetGoal = value; }
   }

   // Update is called once per frame
   void Update() {
      Move();
   }

   public override void GoalReached() {
      Log.Info("character arrives");
   }
}
