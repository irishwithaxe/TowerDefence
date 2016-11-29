using UnityEngine;
using System.Collections;

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
   }
}
