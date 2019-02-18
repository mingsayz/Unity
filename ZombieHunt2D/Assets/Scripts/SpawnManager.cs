using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	//private static SpawnManager instance;
	//public static SpawnManager Instance{
	//	get { return instance; }
	//}

	Vector3[] positions = new Vector3[10];
	public GameObject smallEnemyPrefab;

	[SerializeField]
	private bool isSpawn = false;

	public float spawnDelay = 1.5f;
	float spawnTimer = 0f;

	// Use this for initialization
	void Start () {
		CreatePositions ();
	}
	
	// Update is called once per frame
	void Update () {
		SpwanEnemy ();
	}

	void CreatePositions(){
		//float gapX = 1.0f / 5.0f;
		for (int i = 0; i < positions.Length; i++) {
			float viewPosX = Random.Range (0f, 1f);
			float viewPosY = Random.Range (0f, 1f);
			//viewPosX = gapX + gapX * i;
			Vector3 viewPos = new Vector3 (viewPosX, viewPosY, 0);
			Vector3 worldPos = Camera.main.ViewportToWorldPoint	(viewPos);
			worldPos.z = 0f;
			positions [i] = worldPos;
			//print (worldPos);
		}
	}

	void SpwanEnemy(){
		if (isSpawn == true) {
			if (spawnTimer > spawnDelay) {
				int rand = Random.Range (0, positions.Length);
				Instantiate (smallEnemyPrefab, positions [rand], Quaternion.identity);
				spawnTimer = 0f;
			}
			spawnTimer += Time.deltaTime;
		}
	}
}
//
//	void Awake(){
//		instance = this;
//	}
//
//	void Start(){
//		InvokeRepeating("CreateEnemy",1f,3f*(Random.Range(7,10) / 10f));
//	}
//
//	void CreateEnemy(){
//		Instantiate (enemy);
//	}
//
//	public static void Cancel(){
//		instance.CancelInvoke ();
//	}
//}

