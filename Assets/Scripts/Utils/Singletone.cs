using UnityEngine;
using System.Collections;
using System;

public abstract class Singletone<T> where T : Singletone<T>, new() {
	private static T _instance;
	public static T Instance {
		get {
			if (_instance == null)
				_instance = new T().Init();

			return _instance;
		}
	}

	public abstract T Init();
	private Guid _uid;

	public Singletone() {
		_uid = Guid.NewGuid();
		var type = GetType();

		Log.Info("Created " + type.Name + " [" + _uid.ToString() + "]");
	}
}
