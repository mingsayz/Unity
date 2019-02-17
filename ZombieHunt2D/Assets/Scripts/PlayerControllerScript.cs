using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour  {
	
	public Joystick joystick;
	public float MoveSpeed;

	public Animator playerAnim;

	private Vector3 _moveVector;
	private Transform _transform;

	//private bool isBtnDown = false;


	void Start(){
		_transform = transform;
		_moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
	}

	void Update(){
		HandleInput ();
	}

	void FixedUpdate(){
		Move ();

	}

	public void HandleInput(){
		_moveVector = PoolInput ();
	}

	public Vector3 PoolInput(){
		float h = joystick.GetHorizontalValue ();
		float v = joystick.GetVerticalValue ();
		Vector3 moveDir = new Vector3 (h, v, 0).normalized;
		return moveDir;
	}

	public void Move(){
		_transform.Translate (_moveVector * MoveSpeed * Time.deltaTime);
		//_transform.rotation = Quaternion.Euler (0, 0, lookDir*90);
		//moveAnim.SetTrigger("Move_t");

	}

	//float exitTime = 0.9f;
	//Enumerator CheckAnimatorState(){
	//	while (playerAnim.GetCurrentAnimatorStateInfo (0).normalizedTime < exitTime) {
	//		playerAnim.SetTrigger ("Attack_t");
	//		yield return null;
	//	}
	//}

	public void Attack(){
	//	StartCoroutine(CheckAnimatorState());
		playerAnim.SetTrigger ("Attack_t");
	}
}
