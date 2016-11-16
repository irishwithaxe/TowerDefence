using UnityEngine;
using System.Collections;

public class Tile  {
	public readonly Point Position;
	public readonly TileType Type;

	public Tile(uint row, uint col, TileType tt) {
		Position = new Point() { C = col, R = row };
		Type = tt;
	}
}
