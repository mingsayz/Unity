using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Animator anim;
	public Text scoreText;
	public GameObject upgradeCanvasObj;

	int score = 0;
	int hitScore = 1;
	int upgradeScore = 10;

	public void TouchScreen(){
		anim.SetTrigger ("Attack_t");

		score += hitScore;
		scoreText.text = "Score :"+score.ToString ();

		//if (score < upgradeScore) {
		//	upgradeCanvasObj.SetActive (false);
		//} else {
		//	upgradeCanvasObj.SetActive (true);
		//}

		upgradeCanvasObj.SetActive (score >= upgradeScore);



	}

	public void Upgrade(){
		score = 0;
		hitScore *= 2;
		upgradeScore *= 3;
		scoreText.text = "Score :"+score.ToString ();
		upgradeCanvasObj.SetActive (false);
	}

}
