using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Card card;
	public int totalCardNumber = 18;

	public Transform parentTf;

	public Sprite[] sprites;
	public string spritePath;

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

		LoadData ();

		sprites = Resources.LoadAll<Sprite> (spritePath);
	}


	void LoadData(){
		this.delayTime = StageManager.Instance.delayTime;
		this.gameTime = StageManager.Instance.gameTime;
		this.penalty = StageManager.Instance.penalty;
		this.totalCardNumber = StageManager.Instance.totalCardNumber;
		this.spritePath = StageManager.Instance.spritePath;
	}

	List<int> cardTypeList = new List<int>();
	List<Card> cardList = new List<Card>();



	void Start ()
	{
		while (cardTypeList.Count < totalCardNumber) {
			int randTypeNumber = Random.Range (0, sprites.Length);
			cardTypeList.Add (randTypeNumber);
			cardTypeList.Add (randTypeNumber); //카드는 짝이 맞아야 하므로
		}

		while (cardTypeList.Count > 0) {
			int randIndex = Random.Range (0, cardTypeList.Count);
			int tempType = cardTypeList [randIndex];
			cardTypeList.RemoveAt (randIndex);
		
			Card tempCard = Instantiate (card, parentTf);
			tempCard.Init (tempType, sprites [tempType]);
			cardList.Add (tempCard);
		}

		StartCoroutine (IeStartGame());
	}
		
	public Text timeText;

	public float delayTime = 3f;
	public float DelayTime{
		get { return delayTime; }
		set { 
			delayTime = Mathf.Clamp (value, 0f, float.MaxValue);
			timeText.text = delayTime.ToString ("00.00");
		}
	}

	public float gameTime = 30f;
	public float GameTime{
		get { return gameTime; }
		set { 
			gameTime = Mathf.Clamp (value, 0f, float.MaxValue);
			timeText.text = gameTime.ToString ("00.00");
		}
	}



	public GameObject blockPanel,winPanel,losePanel;
	IEnumerator IeStartGame(){
		ShowAll ();
		blockPanel.SetActive (true);
		while (delayTime > 0f) {
			DelayTime -= Time.deltaTime;
			yield return null;
		}
		HideAll();
		blockPanel.SetActive (false);
	
		while (gameTime > 0f) {
			if (cardList.Count == clearNumber) {
				break;
			}
			GameTime -= Time.deltaTime;
			yield return null;
		}

		if (cardList.Count == clearNumber) {
			winPanel.SetActive (true);
		} else {
			losePanel.SetActive (true);
		}
	}//플레이 기능 코루틴


	public void ShowAll(){
		for (int i = 0; i < cardList.Count; i++) {
			cardList [i].Show ();
		}
	}// 모든 카드를 보여주는 함수

	public void HideAll(){
		for (int i = 0; i < cardList.Count; i++) {
			cardList [i].Hide ();
		}
	}

	Card selectedCard = null;
	int clearNumber = 0;
	public float penalty = 3f;
	public void SelectCard(Card selectCard){
		selectCard.Show ();

		if (selectedCard == null) {
			selectedCard = selectCard; //선택된 카드가 없을때
		} else if(selectedCard == selectCard){ // 똑같은 카드를 두번 눌렀을때
			selectedCard.Hide ();
			selectedCard = null;
		}
		else { // 선택해놓은 카드가 있을때
			if (selectedCard.type == selectCard.type) {
				selectedCard.Clear ();
				selectCard.Clear ();
				clearNumber += 2;
				selectedCard = null;
			} else {
				selectedCard.Hide ();
				selectCard.Hide ();
				GameTime -= penalty;
				selectedCard = null;
			}
		}
	}
}
