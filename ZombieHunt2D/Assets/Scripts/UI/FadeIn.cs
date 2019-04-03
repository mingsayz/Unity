using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	SpriteRenderer rend;

	void Start(){
		rend = GetComponent<SpriteRenderer> ();
		Color c = rend.material.color;
		c.a = 0f;
		rend.material.color = c;

	}

	IEnumerator Fadein(){

		for (float f = 0.05f; f <= 1 ; f += 0.05f){
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void StartFading(){
		StartCoroutine ("Fadein");
	}
}
