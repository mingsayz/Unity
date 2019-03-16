using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour  {
	
	public Joystick joystick;
	public float MoveSpeed;

	Rigidbody2D rigid;
	Animator animator;
	private Vector3 _moveVector;
	private Transform _transform;




	void Start(){
		_transform = transform;
		_moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
		rigid = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponentInChildren<Animator> ();
	}

	void Update(){

		HandleInput ();
	}

	void FixedUpdate(){
		Move ();
		Turn ();
	}
		

	public void HandleInput(){
		_moveVector = PoolInput ();
	}

	public Vector3 PoolInput(){
		float horizontalMove = joystick.GetHorizontalValue ();
		float verticalMove = joystick.GetVerticalValue ();
		Vector3 moveDir = new Vector3 (horizontalMove, verticalMove, 0).normalized;

		return moveDir; //조이스틱 움직임에 따른 벡터값 반환
	}

	public void Move(){
		Vector3 tempPosition = new Vector2 (_moveVector.x, _moveVector.y);
		if (tempPosition.x != 0 && tempPosition.y != 0 && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack_t")) {
			animator.SetBool ("Move", true);
		} else {
			animator.SetBool ("Move", false);
		}
		gameObject.transform.position += tempPosition * MoveSpeed * Time.deltaTime;
	}
	public void Turn(){
		float rotationDir = joystick.GetAxis();
		if (rotationDir == 0) {
			return; // 조이스틱 입력값이 없을 때 현재 방향 바라보도록 설정
		}
		_transform.rotation = Quaternion.Euler (0f, 0f, rotationDir);
	}

//	void Attack(){
//		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack_t")) {
//			animator.SetTrigger ("Attack_t");
//		}
//	}
//



}
