using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;
		
	private float attackTimer = 0;
	private float attackCd = 1f;

	public Collider2D attackTrigger;
	public GameObject lightObj;

	private Animator anim;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;

	}

	void Update(){
		if (CrossPlatformInputManager.GetButtonDown("Attack") && !attacking) {
			attacking = true;
			attackTimer = attackCd;

			attackTrigger.enabled = true;
			anim.SetTrigger ("Attack_t");
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		anim.SetBool ("Attacking", attacking);
		if (attacking) {
			lightObj.SetActive (false);
		} else { 
			lightObj.SetActive (true);
		}
	}
}

//	void Attack(){
//		if (Input.GetButtonDown("AttackBtn") && !attacking) {
//			attacking = true;
//			attackTimer = attackCd;
//
//			attackTrigger.enabled = true;
//			anim.SetTrigger ("Attack_t");
//		}
//
//		if (attacking) {
//			if (attackTimer > 0) {
//				attackTimer -= Time.deltaTime;
//			} else {
//				attacking = false;
//				attackTrigger.enabled = false;
//			}
//		}
//
//		anim.SetBool ("Attacking", attacking);
//	}
//}
