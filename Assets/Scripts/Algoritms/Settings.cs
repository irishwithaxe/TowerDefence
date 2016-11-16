using UnityEngine;
using System.Collections;

public class Settings : Singletone<Settings> {
	public Settings() {
	}

	public override Settings Init() {
		return this;
	}
}
