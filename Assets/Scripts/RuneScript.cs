using UnityEngine;
using System.Collections;

public class RuneScript : MonoBehaviour {
   protected Animator myAnimator;

   private void Activate() {
      //Log.Info("activated");
      myAnimator.SetTrigger("activated");
   }

   private void Awake() {
      myAnimator = GetComponent<Animator>();
   }

   // Use this for initialization
   void Start() {

   }

   // Update is called once per frame
   void Update() {

   }

   private void OnTriggerEnter2D(Collider2D other) {
      switch (other.tag) {
         case "Monster":
            Activate();
            var monster = other.GetComponent<MonsterScript>();
            if (monster != null)
               monster.TakeDamage(3f);
            break;
         default:
            break;
      }
   }

}
