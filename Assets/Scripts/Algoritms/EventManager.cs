using UnityEngine;
using System.Collections;
using System;

public class EventManager : Singletone<EventManager> {
	public override EventManager Init() {
		return this;
	}
}
