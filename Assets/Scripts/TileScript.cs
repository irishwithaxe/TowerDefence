using GameCore;
using UnityEngine;

public class TileScript : MonoBehaviour {
   public Tile Tile { get; set; }

   public Vector3 WorldPosition { get; set; }

   private bool clickProcessing = false;

   // Use this for initialization
   private void Start() {
   }

   // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider
   private void OnMouseDown() {
      ClickTile();
   }

   // Update is called once per frame
   private void Update() {
   }
   private void ClickTile() {
      if (Input.GetMouseButtonDown(0) && !clickProcessing) try {
            clickProcessing = true;
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null)
               return;

            var ts = hit.collider.GetComponent<TileScript>();
            if (ts == null)
               return;

            ts.Tile.LeftMouseClick();
         }
         finally {
            clickProcessing = false;
         }
   }
}