using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour {
	public static ObjectPoolManager Instance {
		get {
			return instance;
		}
	}
	private static ObjectPoolManager instance;

	void Awake() {
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
	}
}
