﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{

	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;

	public Animator playerAnim;
	//private bool isMoving = false;

	void Start(){
		bgImg = GetComponent<Image> ();	
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}


	public virtual void OnDrag(PointerEventData ped){
		//Debug.Log ("Joystick >>> OnDrag()");

//		if (isMoving) {
//			playerAnim.SetTrigger ("Move_t");// 캐릭터 움직이는 애니메이션 joystick에서 구현
//		}else{
//			playerAnim.ResetTrigger ("Move_t");
//		}
		Vector2 pos;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
		}

		inputVector = new Vector3 (pos.x * 2 , pos.y * 2 , 0);
		inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
		//Debug.Log (inputVector);

		//Move Joystick Img
		joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3 ), inputVector.y * (bgImg.rectTransform.sizeDelta.y /3));

	}

	public virtual void OnPointerDown(PointerEventData ped){
		//isMoving = true;
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		//isMoving = false;
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float GetHorizontalValue(){
		return inputVector.x;
	}
	public float GetVerticalValue(){
		return inputVector.y;
	}
	public float GetAxis(){
		float rotationDir = Mathf.Atan2 (inputVector.y, inputVector.x) * Mathf.Rad2Deg;
		return rotationDir;
	}
}
