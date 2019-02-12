using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
	public float rotateSpeed = 1f;

	void FixedUpdate () {
		transform.Rotate (Vector3.forward * rotateSpeed);	
	}
}
