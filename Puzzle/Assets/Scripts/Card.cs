using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public int type;
	public Image image;
	public Button button;

	public void Init(int type,Sprite sprite){
		this.type = type;
		image.sprite = sprite;
	}

	public void Show(){
		image.enabled = true;
	}

	public void Hide(){
		image.enabled = false;
	}

	public void Select(){
		GameManager.Instance.SelectCard (this);
	}

	public void Clear(){
		button.interactable = false;
	}

}
