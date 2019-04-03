using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Enemy : MonoBehaviour {


	public float movePower = 1f;
	public Transform traceTarget;
	private Animator animator;

	public float chaseRadius;
	public float attackRadius;

	public int health;
	public string enemyName;
	public int baseAttack;


	void Awake(){
		animator = gameObject.GetComponent<Animator> ();
	}

	void Start(){
		traceTarget = GameObject.FindWithTag ("Player").transform;
	}

	void FixedUpdate(){
		CheckDistance ();
	}

	void CheckDistance(){
		if (Vector3.Distance (traceTarget.position, transform.position) <= chaseRadius
		   && Vector3.Distance (traceTarget.position, transform.position) > attackRadius) {
			animator.SetBool ("Move_b", true);
			Trace ();
		} else {
			animator.SetBool ("Move_b", false); //도중에 불린값 바뀜 수정 요망
			animator.SetTrigger("Attack_t");
		}
	}	
	void Turn(Vector3 turnPos){
		//Vector3 playerPos = traceTarget.transform.position;
		float rotationPos = Mathf.Atan2 (transform.position.y - turnPos.y, transform.position.x - turnPos.x) * Mathf.Rad2Deg;
		if (rotationPos == 0) {
			return;
		}
		transform.rotation = Quaternion.Euler (0f, 0f, rotationPos);
	}

	public void Trace ()
	{
		Vector3 playerPos = traceTarget.transform.position;
		Vector3 enemyPos = gameObject.transform.position;
		Vector3 tempVec = new Vector2 (playerPos.x - enemyPos.x, playerPos.y - enemyPos.y);
		tempVec.Normalize ();
		Turn (playerPos); // 플레이어 방향으로 턴
		gameObject.transform.position += tempVec * movePower * Time.deltaTime; 
	}

	void Attack(){
		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack_t")) {
			animator.SetTrigger ("Attack_t");
		}
	}

}



