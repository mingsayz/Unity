using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Transform attackPosition;
	public float attackRadius;
	public int maxObjectsHit = 5;
	public Collider2D[] objectsHit;
	public LayerMask selectObjectsToHit;

	void Start(){
		objectsHit = new Collider2D[maxObjectsHit];
	}


}
