using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float movePower = 1f;
	public GameObject traceTarget;

	Animator enemyAnim;
	Vector3 movement;
	int movementFlag = 0; // 0 : idle , 1 : move , 2 : attack
	bool isTracing = false;


	void Start(){
		enemyAnim = gameObject.GetComponentInChildren<Animator> ();
		StartCoroutine (ChangeMovement ());
	}

	void FixedUpdate(){
		Move ();
	}

	void Move(){
		Vector3 moveVelocity = Vector3.zero;
		string dist = "";
		//Trace or Random
		if (isTracing) {
			Vector3 playerPos = traceTarget.transform.position;

			if (playerPos.x < transform.position.x)
				dist = "Left";
			else if (playerPos.x > transform.position.x)
				dist = "Right";

		} else {
			if (movementFlag == 1)
				dist = "Left";
			else if (movementFlag == 2)
				dist = "Right";
		}


		if (dist == "Left") {
			moveVelocity = Vector3.left;
			transform.localScale = new Vector3 (1, 1, 1);
		}else if(dist == "Right"){
			moveVelocity = Vector3.right;
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

	IEnumerator ChangeMovement(){
		movementFlag = Random.Range (0, 3);
		if (movementFlag == 0) {
			enemyAnim.SetBool ("isMovimg", false);
			enemyAnim.SetBool ("idle", true);
		} else {
			enemyAnim.SetBool ("idle", false);
			enemyAnim.SetBool ("isMoving", true);
		}

		yield return new WaitForSeconds (3f);

		StartCoroutine (ChangeMovement ());
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			traceTarget = other.gameObject;

			StopCoroutine (ChangeMovement());
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			isTracing = true;
			enemyAnim.SetBool ("isMoving", true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			isTracing = false;
			StartCoroutine (ChangeMovement());
		}
	}


}
