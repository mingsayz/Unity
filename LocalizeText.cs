using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour {
	public int index;
	void Start() {
		GetComponent<Text> ().text = LocalizeManager.GetText (index);
	}
}
