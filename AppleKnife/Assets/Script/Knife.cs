using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public float throwPower = 400f;
	private Rigidbody2D rb2d;
	private bool isOver = false;
	const string appleTag = "Apple";

	public static Knife instance;

	public virtual void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
		instance = this;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Throw ();
		}
	}

	public virtual void Throw(){
		instance = null;
		rb2d.AddForce (Vector3.up * throwPower);
	}// 많은 객체들이 상속받기위해 virtual 로 선언

	public virtual void OnTriggerEnter2D(Collider2D col){
		if (isOver) {
			return;
		}
		isOver = true;

		if (col.transform.tag.Equals (appleTag)) {
			Destroy (rb2d);
			transform.SetParent (col.transform);
			GameManager.Instance.Score++;
			Apple.instance.Hit ();
		} else {
			GameManager.Instance.isGameOver = true;
			rb2d.gravityScale = 3f;
			rb2d.AddTorque (400f);
		}
	}
}
