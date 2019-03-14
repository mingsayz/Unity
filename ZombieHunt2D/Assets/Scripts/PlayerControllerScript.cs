using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour  {
	
	public Joystick joystick;
	public float MoveSpeed;
	public int maxHealth = 3;

	Rigidbody2D rigid;
	Animator animator;
	bool isDie = false;

	int health = 3;

	public Animator playerAnim;

	private Vector3 _moveVector;
	private Transform _transform;

	float exitTime = 1.0f;


	void Start(){
		_transform = transform;
		_moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
		rigid = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponentInChildren<Animator> ();

		health = maxHealth;
	}

	void Update(){
		if (health == 0) {
			if (!isDie) {
				Die ();
			}
			return;
		}
		HandleInput ();
	}

	void FixedUpdate(){
		if (health == 0) {
			return;
		}
		Move ();
		Turn ();
	}

	void Die(){
		isDie = true;
		Vector2 dieVelocity = new Vector2 (0, 10f);
		rigid.AddForce (dieVelocity, ForceMode2D.Impulse);
		Invoke ("RestartStage", 2f);
	}

//	void RestartStage(){
//		GameManager.RestartStage ();
//	}

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
		gameObject.transform.position += tempPosition * MoveSpeed * Time.deltaTime;
		//_transform.Translate (_moveVector * MoveSpeed * Time.deltaTime ); // 이코드는 z값에 의해 포지션값이 계속 변경되어 이상한 움직임을 보임
//		float rot_z = Mathf.Atan2 (_moveVector.y,_moveVector.x) * Mathf.Rad2Deg; 
//		_transform.rotation = Quaternion.Euler (0f,0f,rot_z);
	}
	public void Turn(){
		float rotationDir = joystick.GetAxis();
		if (rotationDir == 0) {
			return; // 조이스틱 입력값이 없을 때 현재 방향 바라보도록 설정
		}
		_transform.rotation = Quaternion.Euler (0f, 0f, rotationDir);
	}
//		
//	IEnumerator CheckAnimatorState(){
//		while(!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("flashlight_Attack")){
//			playerAnim.SetTrigger ("Attack_t");
//			yield return null;
//		}
//		while (playerAnim.GetCurrentAnimatorStateInfo (0).normalizedTime < exitTime) {
//			//playerAnim.SetTrigger ("Attack_t");
//			yield return null;
//		}
//	}

	public void Attack(){
		
		//StartCoroutine(CheckAnimatorState());
		playerAnim.SetTrigger ("Attack_t");
	}




}
