using UnityEngine;
using System.Collections;

public class RuneScript : MonoBehaviour {
   protected Animator myAnimator;

   [SerializeField]
   protected string ChildRuneName;

   [SerializeField]
   private float damage = 1f;
   
   [SerializeField]
   private float manaCost = 1f;

   public Tile Tile { get; private set; }
   public float Mana { get; private set; }
   public float MaxMana { get; private set; }

   public bool IsEnoughMana {
      get { return Mana > manaCost; }
   }

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

   public void Place(Tile tile, Vector3 worldPos, float mana) {
      Tile = tile;
      transform.position = worldPos;

      Mana = mana;
      MaxMana = mana;
   }

   public void AfterActivated() {
      if (IsEnoughMana)
         return;

      if (ChildRuneName.HasValue()) {
         var chpos = transform.position;
         float delta = LevelManager.TileSize / 2f;
         float startmana = MaxMana / 2;

         var chrune_lu = GameManager.Pool.GetObject(ChildRuneName); // left up
         var chscript_lu = chrune_lu.GetComponent<RuneScript>();
         chpos.x -= delta / 2;
         chpos.y += delta / 2;
         chscript_lu.Place(Tile, chpos, startmana);

         var chrune_ru = GameManager.Pool.GetObject(ChildRuneName); // right up
         var chscript_ru = chrune_ru.GetComponent<RuneScript>();
         chpos.x += delta;
         chscript_ru.Place(Tile, chpos, startmana);

         var chrune_rd = GameManager.Pool.GetObject(ChildRuneName); // tight down
         var chscript_rd = chrune_rd.GetComponent<RuneScript>();
         chpos.y -= delta;
         chscript_rd.Place(Tile, chpos, startmana);

         var chrune_ld = GameManager.Pool.GetObject(ChildRuneName); // left down
         var chscript_ld = chrune_ld.GetComponent<RuneScript>();
         chpos.x -= delta;
         chscript_ld.Place(Tile, chpos, startmana);
      }

      GameManager.Pool.ReleaseGameObject(gameObject);
   }

   private void OnTriggerEnter2D(Collider2D other) {
      if (!IsEnoughMana)
         return;

      switch (other.tag) {
         case "Monster":
            var monster = other.GetComponent<MonsterScript>();
            if (monster.IsDead)
               break;

            Mana -= manaCost;
            Activate();
            monster.TakeDamage(damage);
            break;
         default:
            break;
      }
   }

}
