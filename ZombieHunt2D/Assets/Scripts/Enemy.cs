using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int healthPoint;
	public int damage;


	public float movePower = 1f;
	public GameObject traceTarget;
	private GameObject currentWaypoint;
	private Animator animator;


	bool isTracing = false;
	private float moveFloat;

	void Awake(){
		traceTarget = GameObject.Find ("Player");
		animator = gameObject.GetComponent<Animator> ();
		healthPoint = 5;
		damage = 1;
	}

	void Start(){

	}


	void FixedUpdate(){
		float distance = Vector3.Distance (traceTarget.transform.position, gameObject.transform.position);
		//Debug.Log (distance);
		if (isTracing) {
			Trace ();
			if (distance < 2.5f) {
				Attack ();
			} else {
				animator.SetBool ("Attack_b", false);
			}
			float latestDirection = gameObject.transform.rotation.z;
		} else {
			//StartCoroutine ("MoveAroundCoroutine");
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

	void Trace ()
	{
		Vector3 playerPos = traceTarget.transform.position;
		Vector3 enemyPos = gameObject.transform.position;
		Vector3 tempVec = new Vector2 (playerPos.x - enemyPos.x, playerPos.y - enemyPos.y);
		tempVec.Normalize ();
		Turn (playerPos); // 플레이어 방향으로 턴
		gameObject.transform.position += tempVec * movePower * Time.deltaTime; 
	}
	void MoveAround(){
		Vector3 movementDirection = new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f)).normalized;
		Turn (movementDirection);
		gameObject.transform.position += movementDirection * movePower * Time.deltaTime;
		//this.transform.localRotation * Vector3.forward;
	}
//
	IEnumerator MoveAroundCoroutine(){
		while (!isTracing) {
			Vector3 movementDirection = new Vector2 (Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f)).normalized;
			//Vector2 objDestination = new Vector2 (movementDirection.x * 10f, movementDirection.y * 10f);
			Vector2 objDestination = Vector2.MoveTowards(transform.position,movementDirection,movePower);
			GetComponent<Rigidbody2D> ().MovePosition (objDestination);
//			moveFloat += Time.deltaTime * 2.5f;
			Turn (movementDirection);
//			this.transform.position = Vector2.Lerp (this.transform.position, objDestination, moveFloat);
			//gameObject.transform.position += movementDirection * Time.deltaTime * movePower;
			yield return new WaitForSeconds(5f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) { // player의 박스콜라이더와 충돌시
			if (other is BoxCollider2D) {
				StopCoroutine (MoveAroundCoroutine());	
				isTracing = true;
				animator.SetBool ("Move_b", true);

			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag("Player")) { // player의 박스콜라이더와 충돌시
			if (other is BoxCollider2D) {
				isTracing = true;
				animator.SetBool ("Move_b", true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag("Player")) {
			if (other is BoxCollider2D) { // player의 박스콜라이더와 충돌시
				StartCoroutine (MoveAroundCoroutine());
				isTracing = false;
				animator.SetBool ("Move_b", false);

			}

		}
	}

	void Attack(){
		animator.SetBool ("Attack_b",true);
	}


}
