using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform KnifeIconParentTf, knifeMakePosTf;
	public GameObject knifeIconPrefabObj, knifeObj;
	public int knifeTotalCount = 5;
	public float makeDelay = 1f;
	public Text scoreText;
	public bool isGameOver = false;
	private AudioSource audioSource;

	private List<Image> knifeIconList = new List<Image> ();
	private int score = 0;

	public int Score{
		get { return score; }
		set { 
			score = value;
			scoreText.text = score.ToString ();
		}
	}

	private static GameManager instance;
	public static GameManager Instance{
		get { return instance; }
	}

	void Awake(){
		if (instance) {
			Destroy (gameObject);
			return;
		}
		instance = this;
		audioSource = GetComponent<AudioSource> ();
	}

	void Start(){
		for (int i = 0; i < knifeTotalCount; i++) {
			knifeIconList.Add(
				Instantiate (knifeIconPrefabObj, KnifeIconParentTf).GetComponent<Image>()
			);
		}
	}


	public void Throw(){
		audioSource.Play();
		if (Knife.instance == null) {
			return;
		}
		Knife.instance.Throw ();

		if (knifeIconList.Count > 0) {
			knifeIconList [0].color = Color.black;
			knifeIconList.RemoveAt (0);
		}
		StartCoroutine (MakeKnifeCoroutine (makeDelay));
	}

	IEnumerator MakeKnifeCoroutine(float delay){
		yield return new WaitForSeconds (delay);
		if (isGameOver) {
			Debug.Log ("Game Over!");
			yield break;
		} else {
			Instantiate (knifeObj).transform.position = knifeMakePosTf.position;
		}
	}
}
