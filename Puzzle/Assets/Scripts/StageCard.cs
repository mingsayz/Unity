using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCard : MonoBehaviour {

	public float delayTime,gameTime,penalty;
	public int totalCardNumber;
	public string spritePath;

	public void Select(){
		StageManager.Instance.SelectCard (this);
	}
}
