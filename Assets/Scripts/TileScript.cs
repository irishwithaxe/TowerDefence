using UnityEngine;

public class TileScript : MonoBehaviour {
   public Tile Tile { get; set; }

   public Vector3 WorldPosition { get; set; }

   // Use this for initialization
   private void Start() {
   }

   // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider
   private void OnMouseDown() {
      Tile.LeftMouseClick();
   }

   // Update is called once per frame
   private void Update() {
   }
}

//var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//if (hit.collider == null)
//   return;

//var ts = hit.collider.GetComponent<TileScript>();
//if (ts == null)
//   return;

