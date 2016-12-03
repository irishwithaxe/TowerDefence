using UnityEngine;
using System.Collections;
using System;

public class MonsterScript : MovingObject {

   // Use this for initialization
   void Start() {

   }

   public void TrySetGoal(Tile tile) {
      TrySetGoal(tile, x => x.Type == TileType.floor);
   }

   // Update is called once per frame
   void Update() {
      Move();

      if(CurrentTile == GoalTile) {
         GoalReached();
         IsActive = false;
         GameManager.Instance.Pool.ReleaseGameObject(gameObject);
      }
   }

   public override void GoalReached() {
      Log.Info("monster arrives");
   }
}
