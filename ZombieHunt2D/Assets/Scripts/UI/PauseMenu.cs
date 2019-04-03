using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

	public CanvasGroup uiElement;
	public GameObject PauseUI;
//	public Image pausePanel; 

	private bool paused = false;
//	float fadeTime = 3f;
//	Color colorToFadeTo;

	void Start(){
		PauseUI.SetActive (false);
	}
	public void ActivePauseBtn(){

		paused = !paused;

		if (paused) {
			//FadeOut ();
			PauseUI.SetActive (true);
			//colorToFadeTo = new Color (1f, 1f, 1f, 0f);
			//FadeOut();
			//pausePanel.CrossFadeColor(colorToFadeTo,fadeTime,true,true);
			Time.timeScale = 0;
		}

		if (!paused) {
			//FadeOut ();
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void FadeIn(){
		StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 1));
	}

	public void FadeOut(){
		StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 0));
	}



	public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.1f){

		float _timeStartedLerping = Time.time;
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / lerpTime;

		while (true) {

			timeSinceStarted = Time.time - _timeStartedLerping;
			percentageComplete = timeSinceStarted / lerpTime;

			float currentValue = Mathf.Lerp (start, end, percentageComplete);

			cg.alpha = currentValue;
			if (percentageComplete >= 1)
				break; 
			yield return new WaitForEndOfFrame();
		}
	}

//	public IEnumerator FadeCanvasGroup(){
//		uiElement = GetComponent<CanvasGroup>
//	}
//
	public void Resume(){
		paused = false;
		PauseUI.SetActive (false);
		Time.timeScale = 1f;
	}

	public void Restart(){
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}

	public void Quit(){
		Application.Quit ();
	}
}
