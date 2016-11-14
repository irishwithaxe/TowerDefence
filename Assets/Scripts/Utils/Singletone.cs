using UnityEngine;
using System.Collections;
using System;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour {
	//// Awake is called when the script instance is being loaded
	//public void Awake() {
	//	_instance = this;
	//}

	//static T _instance;
	//public static T Instance {
	//	get {
	//		if (_instance == null)
	//			_instance = FindObjectOfType<T>();

	//		return _instance;
	//	}
	//}



	private Guid uid;

	public Singletone() {
		uid = Guid.NewGuid();
		var type = GetType();

		Debug.Log("Created " + type.Name + " uid is " + uid.ToString());

	}
}
