using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	private static StageManager instance;
	public static StageManager Instance{
		get { return instance; }
	}

	void Awake(){
		if (instance) {
			Destroy (gameObject);
			return;
		}
		instance = this;

		DontDestroyOnLoad (gameObject);
	}

	public float delayTime,gameTime,penalty;
	public int totalCardNumber;
	public string spritePath;

	public void SelectCard(StageCard card){
		this.delayTime = card.delayTime;
		this.gameTime = card.gameTime;
		this.penalty = card.penalty;
		this.totalCardNumber = card.totalCardNumber;
		this.spritePath = card.spritePath;

		SceneManager.LoadScene ("Play");
	}
}
