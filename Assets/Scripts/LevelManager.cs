using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {
	[SerializeField]
	private Sprite[] floors = null;
	[SerializeField]
	private Sprite[] walls = null;

	private GameObject[,] map = null;
	private static Vector3 leftTop;
	private static Vector3 rightBottom;

	// Awake is called when the script instance is being loaded
	public void Awake() {
		//leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
		//Instantiate(leftTop, Quaternion.identity);

		//rightBottom = Camera.main.ScreenToWorldPoint(Camera.main.);
		//Log.Info("lefttop is {0} , rightbottom is {1}", leftTop.ToString(), rightBottom.ToString());

		//FIllMap();
	}

	private void FIllMap() {
		MapManager.Instance.MakeMap();
		map = new GameObject[MapManager.Instance.Rows, MapManager.Instance.Cols];

		for (var r = 0; r < MapManager.Instance.Rows; r++)
			for (var c = 0; c < MapManager.Instance.Cols; c++) {
				var tile = MapManager.Instance.Map[r, c];
				var sprite = GetSprite(tile);
				var gameobj = Instantiate(sprite, GetWorldPosition(tile.Position), Quaternion.identity) as GameObject;
				map[r, c] = gameobj;
			}
	}

	public static Vector3 GetWorldPosition(Point position) {
		throw new NotImplementedException();
	}

	private Sprite GetSprite(Tile tile) {
		switch (tile.Type) {
			case TileType.wall:
				return walls.GetRandomItem();

			case TileType.floor:
				return floors.GetRandomItem();

			default:
				throw new System.NotImplementedException("Неожиданный тип тайла");
		}
	}

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void Update() {

	}
}
