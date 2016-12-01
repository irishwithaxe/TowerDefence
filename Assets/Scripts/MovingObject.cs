using UnityEngine;
using System.Collections;
using System;

public class MovingObject : MonoBehaviour {
   public Tile GoalTile { get; set; }
   public Tile CurrentTile { get; set; }
   public Vector3 CurrentTilePosition { get; set; }

   public Tile[] Path { get; protected set; }
   private int pathPos;

   public Vector3 GoalPosition { get; set; }

   public bool IsActive = false;

   protected Animator myAnimator;

   [SerializeField]
   protected float Speed = 1f;

   [SerializeField]
   protected int movingType;

   private void Awake() {
      myAnimator = GetComponent<Animator>();
   }

   public void Place(Tile tile) {
      var worldPos = LevelManager.GetWorldPosition(tile.Position);

      CurrentTile = tile;
      CurrentTilePosition = worldPos;

      GoalTile = tile;
      GoalPosition = worldPos;

      transform.eulerAngles = new Vector3(0, 0, 0);

      IsActive = true;
   }

   protected bool TrySetGoal(Tile tile, Func<Tile, bool> walkable) {
      if (CurrentTile == tile)
         return false;

      var path = AStar.GetPath(CurrentTile, tile, walkable);
      if (path == null)
         return false;

      pathPos = 0;
      Path = path;

      var goalpos = LevelManager.GetWorldPosition(Path[pathPos].Position);
      var tilegoal = Distance2D(CurrentTilePosition, goalpos);
      var currgoal = Distance2D(transform.position, goalpos);
      if (tilegoal < currgoal)
         NextStep(CurrentTile);
      else
         NextStep(Path[pathPos]);
      return true;
   }

   private double Distance2D(Vector2 v1, Vector2 v2) {
      var x = Math.Abs(v1.x - v2.x);
      var y = Math.Abs(v1.y - v2.y);
      return Math.Pow(x * x + y * y, 0.5);
   }

   protected void Move() {
      if (!IsActive || Path == null || Path.Length == 0)
         return;

      transform.position = Vector2.MoveTowards(transform.position, GoalPosition, Speed * Time.deltaTime);

      if (CurrentTile != GoalTile) {
         var tilecur = Distance2D(CurrentTilePosition, transform.position);
         var goalcur = Distance2D(GoalPosition, transform.position);
         if (tilecur > goalcur) {
            CurrentTile = GoalTile;
            CurrentTilePosition = GoalPosition;
            //Log.Info("tilecur " + tilecur + " goalcur " + goalcur);
         }
      }

      if (transform.position.x == GoalPosition.x && transform.position.y == GoalPosition.y) {
         if (pathPos < Path.Length && GoalTile == Path[pathPos])
            pathPos++;
         if (pathPos < Path.Length)
            NextStep(Path[pathPos]);
      }
   }

   private void NextStep(Tile newPos) {
      GoalTile = newPos;
      if (movingType == 0)
         Animate(CurrentTile.Position, GoalTile.Position);
      if (movingType == 1)
         Rotate(CurrentTile.Position, GoalTile.Position);

      GoalPosition = LevelManager.GetWorldPosition(GoalTile.Position);
   }

   private void Rotate(Point oldPosition, Point newPosition) {
      var direction = newPosition - oldPosition;

      if (direction == new Point(1, 1)) // goal at down right
         transform.eulerAngles = new Vector3(0, 0, -135);
      else if (direction == new Point(-1, -1)) // goal at top left
         transform.eulerAngles = new Vector3(0, 0, 45);
      else if (direction == new Point(-1, 1)) // goal at top right
         transform.eulerAngles = new Vector3(0, 0, -45);
      else if (direction == new Point(1, -1)) // goal at down left
         transform.eulerAngles = new Vector3(0, 0, 135);
      else if (direction == new Point(0, 1)) // goal at right
         transform.eulerAngles = new Vector3(0, 0, -90);
      else if (direction == new Point(0, -1)) // goal at left
         transform.eulerAngles = new Vector3(0, 0, 90);
      else if (direction == new Point(1, 0)) // goal at down
         transform.eulerAngles = new Vector3(0, 0, 180);
      else if (direction == new Point(-1, 0)) // goal at up
         transform.eulerAngles = new Vector3(0, 0, 0);
   }

   private void Animate(Point oldPosition, Point newPosition) {

      Action<bool, bool, bool, bool> _setDirection = (left, up, down, right) => {
         myAnimator.SetBool("up", up);
         myAnimator.SetBool("left", left);
         myAnimator.SetBool("down", down);
         myAnimator.SetBool("right", right);
      };

      var direction = newPosition - oldPosition;
      if (direction.C < 0) // left
         _setDirection(true, false, false, false);
      else if (direction.C > 0) // right
         _setDirection(false, false, false, true);
      if (direction.R < 0) // up
         _setDirection(false, true, false, false);
      else if (direction.R > 0) // down
         _setDirection(false, false, true, false);
   }
}
