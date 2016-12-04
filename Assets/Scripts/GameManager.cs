using UnityEngine;

public class GameManager : MonoBehaviour {

   private static GameManager _inst = null;
   public static GameManager Instance {
      get {
         if (_inst == null) {
            _inst = FindObjectOfType<GameManager>();
         }
         return _inst;
      }
   }

   public static ObjectPool Pool {
      get {
         return Instance.ObjPool;
      }
   }

   public ObjectPool ObjPool { get; private set; }

   public void Awake() {
      ObjPool = GetComponent<ObjectPool>();
   }

   // Use this for initialization
   private void Start() {
      //EventManager.Instance.OnTileClicked += EventManager_OnTileClicked;
   }

   private void EventManager_OnTileClicked(object sender, TileClickEvent gameEvent) {
      var ldescr = gameEvent.IsLeftClicked ? " left" : "";
      var rdescr = gameEvent.IsRightClicked ? " right" : "";

      Log.Info("EventManager_OnTileClicked " + gameEvent.tile.Position.ToString() + ldescr + rdescr);
   }

   // Update is called once per frame
   private void Update() {
   }
}