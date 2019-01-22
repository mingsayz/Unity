using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float moveSpeed = 2f;
	public float JumpPower = 300f;

	public GameManager gameManager;

	// Update is called once per frame
	void Update () {
		// Update 프레임 시간 차 * Time.TimeScale = Time.deltaTime
		transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);		
	}

	public void Jump(){
		GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.name == "WinCollider") {
			gameManager.Win ();	
		} else if (col.transform.name == "LoseCollider") {
			gameManager.Lose ();
		}

	}
}
