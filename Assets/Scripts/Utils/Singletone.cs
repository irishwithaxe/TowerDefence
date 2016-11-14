using UnityEngine;
using System.Collections;

public class Singletone<T> where T:new() {
	T _instance;
	public T Instance {
		get {
			if (_instance == null)
				_instance = new T();

			return _instance;
		}
	}
}
