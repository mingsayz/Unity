using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	Vector3[] positions = new Vector3[10];
	public GameObject smallEnemyPrefab;

	[SerializeField]
	//private bool isSpawn = true;
	public int spawnMax = 3;

	public float spawnDelay = 1.5f;
	//float spawnTimer = 0f;

	// Use this for initialization
	void Start () {
		CreatePositions ();
		StartCoroutine (SpawnEnemyCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {
		//SpawnEnemy ();
	}

	void CreatePositions(){
		//float gapX = 1.0f / 5.0f;
		for (int i = 0; i < positions.Length; i++) {
			float viewPosX = Random.Range (0f, 1f);
			float viewPosY = Random.Range (0f, 1f);
			Vector3 viewPos = new Vector3 (viewPosX, viewPosY, 0);
			Vector3 worldPos = Camera.main.ViewportToWorldPoint	(viewPos);
			worldPos.z = 0f;
			positions [i] = worldPos;
			//print (worldPos);
		}
	}

	void SpawnEnemy(){
		int rand = Random.Range (0, positions.Length);
		Instantiate (smallEnemyPrefab, positions [rand], Quaternion.identity);
					//spawnTimer = 0f;
				//}
				//spawnTimer += Time.deltaTime;
	}

	private IEnumerator SpawnEnemyCoroutine(){
		int randTime = (int)Random.Range (2, 4);
		//yield return new WaitForSeconds (randTime);
		while (true) {
			if (spawnMax > 0) {
				SpawnEnemy ();
				yield return new WaitForSeconds (randTime);
				//randTime = (int)Random.Range (2, 5);
				spawnMax--;
			} else {
				//StopCoroutine (SpawnEnemyCoroutine ());
				break;
			}
		}
	}

//		while (isSpawn) {
//			if (spawnTimer > spawnDelay) {
//				int randIndex = Random.Range (0, positions.Length);
//				Instantiate (smallEnemyPrefab, positions [randIndex], Quaternion.identity);
//				spawnTimer = 0f;
//				spawnCount++;
//			}
//			if (spawnCount >= spawnMax)
//				isSpawn = false;

//			spawnTimer += Time.deltaTime;
//			yield return new WaitForSeconds(3);
		//}
	
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

