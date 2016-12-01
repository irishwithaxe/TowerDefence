using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

   [SerializeField]
   private GameObject characterPrefab = null;

   [SerializeField]
   private GameObject[] monstersPrefab = null;

   [SerializeField]
   private GameObject[] floors = null;

   [SerializeField]
   private GameObject[] walls = null;

   [SerializeField]
   private GameObject mapParentObject = null;

   [SerializeField]
   private CameraManager camManager = null;

   private GameObject[,] map = null;
   private int rows { get { return MapManager.Instance.Rows; } }
   private int cols { get { return MapManager.Instance.Cols; } }

   private static Vector3 leftTop;
   private static float tileSize;

   // Awake is called when the script instance is being loaded
   public void Awake() {
      leftTop = CameraManager.CamToWorld(new Vector3(0f, Screen.height));
      leftTop.z = 0;

      tileSize = floors[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
   }

   private void SetCameraLimits() {
      var lt = leftTop;
      lt.x -= tileSize / 2;
      lt.y += tileSize / 2;

      var br = map[rows - 1, cols - 1].GetComponent<TileScript>().WorldPosition;
      br.x += tileSize / 2;
      br.y -= tileSize / 2;

      camManager.SetLimits(lt, br);
   }

   private void FIllMap() {
      MapManager.Instance.MakeMap();
      map = new GameObject[rows, cols];

      for (var r = 0; r < rows; r++)
         for (var c = 0; c < cols; c++) {
            var tile = MapManager.Instance.Map[r, c];
            var mapPrefab = GetMapPrefab(tile);
            var worldPos = GetWorldPosition(tile.Position);
            var gameobj = Instantiate(mapPrefab, worldPos, Quaternion.identity, mapParentObject.transform) as GameObject;

            var goTile = gameobj.GetComponent<TileScript>();
            goTile.Tile = tile;
            goTile.WorldPosition = worldPos;

            map[r, c] = gameobj;
         }
   }

   public static Vector3 GetWorldPosition(Point position) {
      var lt = leftTop;
      lt.x += position.C * tileSize + tileSize / 2;
      lt.y -= position.R * tileSize + tileSize / 2;
      return lt;
   }

   private GameObject GetMapPrefab(Tile tile) {
      switch (tile.Type) {
         case TileType.wall:
            return walls.GetRandomItem();

         case TileType.floor:
            return floors.GetRandomItem();

         default:
            throw new NotImplementedException("Неожиданный тип тайла");
      }
   }

   public void OnMenuItemClick(string menuItemName) {
      switch (menuItemName) {
         case "ghost1":
            PlaceGhost(0);
            break;
         case "ghost2":
            PlaceGhost(1);
            break;
         default:
            EventManager.Instance.MenuClicked(this, new MenuItemClicked(menuItemName));
            break;
      }
   }

   // Use this for initialization
   private void Start() {
      FIllMap();
      SetCameraLimits();
      PlaceCharacter();
   }

   private void PlaceCharacter() {
      var tile = MapManager.Instance.CharacterStartPos;
      var worldPos = GetWorldPosition(tile.Position);
      var gameobj = Instantiate(characterPrefab, worldPos, Quaternion.identity) as GameObject;

      var character = gameobj.GetComponent<CharacterScript>();
      character.Place(tile);
   }

   private void PlaceGhost(int number) {
      var tile = MapManager.Instance.MonsterStartPos;
      var worldPos = GetWorldPosition(tile.Position);
      var gameobj = Instantiate(monstersPrefab[number], worldPos, Quaternion.identity) as GameObject;

      var monster = gameobj.GetComponent<MonsterScript>();
      monster.Place(tile);
      monster.TrySetGoal(MapManager.Instance.MonsterGoal);
   }

   // Update is called once per frame
   private void Update() {
   }
}