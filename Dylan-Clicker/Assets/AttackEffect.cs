using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour {

	public GameObject attackEffect;

	void OnCollisionEnter2D (Collision2D col){
		GameObject tempObj = Instantiate (attackEffect);
		Vector3 tempV = transform.position;
		tempV.z = 0f;
		tempObj.transform.position = tempV;
	}
}
