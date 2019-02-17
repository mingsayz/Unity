using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public Transform targetTf;

	Vector3 refVelov;

	void LateUpdate(){
		Vector3 tempV = Vector3.SmoothDamp(transform.position,targetTf.position,ref refVelov,0.3f) + Vector3.back * 10;
		tempV.z = -10f;
		transform.position = tempV;
	}
}
