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

      switch (gameEvent.MenuItemName) {
         case MenuNames.movebtn:
            IsReadyForSetGoal = true;
            break;

         case MenuNames.runefire:
            RuneForSet = PrefabNames.RuneFire;
            break;

         default:
            break;
      }
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      if (gameEvent.tile.Type == TileType.floor && IsReadyForSetGoal) {
         TrySetGoal(gameEvent.tile, (t) => t.Type == TileType.floor ? true : false);
         IsCast = !IsCast;
         IsReadyForSetGoal = false;
      }

      if (gameEvent.tile.Type == TileType.floor && RuneForSet.HasValue()) {
         var rune = GameManager.Pool.GetObject(RuneForSet);
         var runescript = rune.GetComponent<RuneScript>();
         runescript.Place(gameEvent.tile, LevelManager.GetWorldPosition(gameEvent.tile.Position), 10);
         RuneForSet = null;
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

   public string RuneForSet { get; private set; }

   // Update is called once per frame
   void Update() {
      Move();
   }

   public override void GoalReached() {
      Log.Info("character arrives");
   }
}
