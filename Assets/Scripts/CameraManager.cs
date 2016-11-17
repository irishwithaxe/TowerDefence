using UnityEngine;

public class CameraManager : MonoBehaviour {

   [SerializeField]
   private float cameraSpeed = 4f;

   public static Vector3 CamToWorld(Vector3 mod) {
      return Camera.main.ScreenToWorldPoint(mod);
   }

   public static Vector3 WorldToCam(Vector3 mod) {
      return Camera.main.WorldToViewportPoint(mod);
   }

   public void Awake() {
      _topLeftLimit = Vector3.zero;
      _bottomRightLimit = Vector3.zero;
   }

   private Vector3 _topLeftLimit;
   private Vector3 _bottomRightLimit;

   // Use this for initialization
   private void Start() {
   }

   public void SetLimits(Vector3 topLeft, Vector3 bottomRight) {
      _topLeftLimit = WorldToCam(topLeft);
      _bottomRightLimit = WorldToCam(bottomRight);
      Log.Info(" topLeft     : " + topLeft + "  bottomRight     : " + bottomRight);
      Log.Info("_topLeftLimit: " + _topLeftLimit + " _bottomRightLimit: " + _bottomRightLimit);
   }

   // Update is called once per frame
   private void Update() {
      if (Input.GetKey(KeyCode.RightArrow)) {
         transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
      }
      else if (Input.GetKey(KeyCode.LeftArrow)) {
         transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
      }
      else if (Input.GetKey(KeyCode.UpArrow)) {
         transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
      }
      else if (Input.GetKey(KeyCode.DownArrow)) {
         transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
      }
   }
}