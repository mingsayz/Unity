using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour {


	public GameObject PauseUI;

	private bool paused = false;

	public void Open(){if (!gameObject.activeInHierarchy) {
			gameObject.SetActive (true);
			StartCoroutine (FadeIn (3f));
		}}

	public void Close(){if (gameObject.activeInHierarchy) {
			StartCoroutine (FadeOut (3f));
	}

	void Start(){
		PauseUI.SetActive (false);
	}
	public void ActivePauseBtn(){

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}

		paused = !paused;
	}
			
	IEnumerator FadeIn(float speed){
			
	}
	IEnumerator FadeOut(float speed){
			
	}
}
