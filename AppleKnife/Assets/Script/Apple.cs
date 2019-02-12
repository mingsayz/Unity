using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

	public static Apple instance;
	public float shakePower = 1f;
	public SpriteRenderer sr;

	void Awake(){
		instance = this;
		sr = GetComponent<SpriteRenderer> ();
	}

	public void Hit(){
		StartCoroutine (ShakeCoroutine ());
		StartCoroutine (WhiteEffectCoroutine ());
	}

	IEnumerator ShakeCoroutine(){
		float t = 1f;
		Vector3 originV = transform.position;
		while (t > 0f) {
			t -= 0.15f;
			transform.position = originV + (Vector3)Random.insideUnitCircle * shakePower * t ;
			yield return null;
		}
		transform.position = originV;
	}

	IEnumerator WhiteEffectCoroutine(){
		float t = 0f;
		while (t < 1f) {
			t += 0.15f;
			sr.material.SetFloat ("_FlashAmount", t);
			yield return null;
		}
		while (t > 0f) {
			t -= 0.15f;
			sr.material.SetFloat ("_FlashAmount", t);
			yield return null;
		}
		sr.material.SetFloat ("_FlashAmount", 0f);
	}
}
