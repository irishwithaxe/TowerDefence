using UnityEngine;
using System.Collections;
using System;

public class MonsterScript : MovingObject {

   [SerializeField]
   private float startHealth = 1f;

   // This function is called when the object becomes enabled and active
   private void OnEnable() {
      health = startHealth;
   }

   private float health;

   public bool IsDead {
      get { return health <= 0f; }
   }

   public void TrySetGoal(Tile tile) {
      TrySetGoal(tile, x => x.Type == TileType.floor);
   }

   // Update is called once per frame
   void Update() {
      Move();

      if (CurrentTile == GoalTile) {
         GoalReached();
         Die();
      }
   }

   private void Die() {
      IsActive = false;
      GameManager.Pool.ReleaseGameObject(gameObject);
   }

   public void TakeDamage(float damage) {
      health -= damage;
         if (IsDead)
            Die();
   }

   public override void GoalReached() {
      //Log.Info("monster arrives");
   }
}
