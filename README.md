# Unity
---
## 기초 뷰
  * 프로젝트 뷰
  * 하이어라키 뷰
  * 인스펙터 뷰
  * 씬 뷰
  * 게임 뷰
---
## 프로젝트 뷰
  * 게임에 사용되는 애셋들을 관리하는 창
  * 윈도우의 탐색기, 맥의 파인더와 비슷한 역할
  * 다양한 검색 기능
  * 폴더 생성 및 그림 파일 불러오기

---
## 하이어라키 뷰
  * 현재 씬에 사용되는 게임 오브젝트를 관리하는 뷰
  * 새로운 게임 오브젝트를 생성/삭제
  * 계층 구조 설정

---
## 인스펙터 뷰
  * 현재 선택한 게임 오브젝트 혹은 애셋의 정보를 보여주는 뷰
  * 컴포넌트 추가 / 삭제 / 변경
  * 게임 오브젝트 이름,태그,레이어 변경

---
## 씬 뷰
  * 우리가 실질적으로 게임을 제작하는 공간
  * 게임 오브젝트를 배치
  * 씬뷰 툴바

---
## 게임 뷰
  * 현재 씬이 실제로 작동하는 모습을 보여주는 뷰
  * 다양한 해상도 테스트
  * 게임 뷰 툴바

---
## 충돌
  * 충돌의 정의
  * Collision 충돌
  * Trigger 충돌
---
## Collsion 충돌 (물리 연산을 하는 충돌)
  * 1. 두 물체 모두 Collider(2D)를 가지고 있다. (Collider : 충돌 영역,범위)
  * 2. 둘 중 적어도 하나는 Rigidbody(2D)를 가지고 있다. (Rigidbody(2D) : 물리 엔진 2D)
  * 3. Rigidbody(2D)를 가진 오브젝트가 움직인다. (1,2번을 만족했는데 Collsion 충돌이 일어나지 않을 때 고려해봐야함)

---
## Trigger 충돌 (물리 연산을 하지않는 충돌)
  * 1. 두 물체 모두 Collider(2D)를 가지고 있다.
  * 2. 둘 중 적어도 하나는 Rigidbody(2D)를 가지고 있다.
  * 3. 둘 중 적어도 하나는 IsTrigger 옵션이 체크되어 있다.
  * 4. Rigidbody(2D)를 가진 오브젝트가 움직인다.
    - 두 가지 물체가 Collider가 겹쳤다는 여부만 알려줌.
    - ex ) 던전이 있을 때 캐릭터가 던전에 들어왔다 라는 여부만 알려줌

---
## 프리팹
  * 프리팹이란? 게임 오브젝트를 애셋으로 만들어 놓는 것
    - java의 class와 비슷함
  * 여러개의 동일한 게임 오브젝트를 관리할 때 편리

---
## 스크립팅
  * 우리가 원하는 컴포넌트를 만들기 위해서 (Move 컴포넌트: 좌,우 키로 움직이는 기능 등)
  * 따로 선언하지 않아도 사용가능한 변수들
    - gameObject : 현재 스크립트가 사용되고 있는 게임 오브젝트를 지칭하는 변수
      + ex) Debug.Log(gameObject.name);
    - transform : 현재 스크립트가 사용되고 있는 게임 오브젝트의 Transform 컴포넌트를 지칭하는 변수
      + ex) Debug.Log(transform.position);
---
## 정의되어 있는 함수들
  * Debug.Log
    - usage : Debug.Log ("Hello world!");
  * Destroy : 괄호안의 오브젝트를 몇초 뒤에 없앤다.
    - usage : Destroy (gameObject,3f); (3초뒤에 오브젝트를 없앤다.)
  * Translate : 게임오브젝트를 괄호 안의 좌표만큼 이동시킴
    - usage : transform.Translate(1f,0f,0f); ((1,0,0) 만큼 이동) (Update()함수 안에 넣으면 매 프레임마다 이동)
    - transform.Translate(Vector3.right); (Vector3는 x,y,z 좌표를 모두 가지고 있는 자료형) : (1,0,0)만큼 이동
    - transform은 모든 오브젝트들이 기본적으로 가지고 있으므로 이 변수를 Unity 자체에서 미리 선언해둠.
      + Vector3.right : (1,0,0)
      + Vector3.left : (-1,0,0)
      + Vector3.up : (0,1,0)
      + Vector3.down : (0,-1,0)
      + Vector3.forward : (0,0,1)
      + Vector3.back : (0,0,-1)
      + Vector3.zero : (0,0,0)
      + Vector3.one : (1,1,1)
      + 다른 값을 쓰고 싶다면, New Vector3 (3,2,0) 으로 지정 가능
  * Rotate : 게임오브젝트를 괄호 안의 좌표만큼 회전시킴
    - usage : transform.Rotate(1f,0f,0f); (1,0,0 만큼씩 회전)(Update()함수 안에 넣으면 매 프레임마다 회전)
  * GetKeyDown : 특정 키가 눌리는 순간 true를 반환
    - usage : Input.GetKeyDown (KeyCode.Space)
    ```csharp
      if(Input.GetKeyDown (KeyCode.LeftArrow)){
        transform.Translate(Vector3.left * 0.1f);
      }
    ```
    - GetKeyUp 도 존재 : 키를 뗄때 true 반환
    ```csharp
      if(Input.GetKeyUp (KeyCode.RightArrow)){
        transform.Rotate(Vector3.right * 0.1f)
      }
    ```
    - GetKey도 존재 : 눌리고 있을 때는 계속 true 반환
    ```csharp
      if(Input.GetKey (KeyCode.Space)){
        transform.Translate(Vector3.up * 0.1f);
      }
    ```

  * Instantiate : 괄호안의 게임오브젝트를 복제
    - usage :
    ```csharp
    if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate (gameObject);
		}
    ```
  * GetComponent : 현재 게임 오브젝트의 다른 컴포넌트를 가져오는 함수
  - usage :
  ```csharp
    GetComponent<SpriteRenderer>().color = Color.red; // SpriteRenderer에 color 탭에서 색깔을 변경
    GetComponent<Rigidbody2D> ().gravityScale = 0f; // Rigidbody2D에 gravityScale 을 0으로 변경
  ```
  * .....
---
## 이벤트 함수
  * 실행되는 시점이 미리 정해져 있는 함수들
    - Reset() : 에디터에서 처음 연결될때, Reset() 명령을 실행했을때 호출
    - Awake() : 항상 Start 함수 이전, 혹은 활성화 직후에 호출
      + 씬이 시작할 때, 비활성화 상태인 경우, 활성화 되기 전까지 호출되지 않는다.
      + Start()함수보다 먼저 실행시키고 싶은 코드가 있다면 다음과 같이 코드 작성
      ```csharp
        void Awake(){
          Debug.Log("Awake!");
        }
        void Start(){
          Debug.Log("Start!");
        }
      ```
    - OnEnable / OnDisable : 활성화 / 비활성화 직후에 호출
      + OnEnable 함수는 Awake, Start 함수와는 다르게 활성화 될 때마다 호출
      ```csharp
        void OnEnable(){
          // 해당 함수가 들어있는 스크립트를 가지고 있는 오브젝트가 켜질때마다 호출
        }
        void OnDisable(){
          // 해당 함수가 들어있는 스크립트를 가지고 있는 오브젝트가 꺼질때마다 호출
        }
      ```
    - Start() : 시작할때 실행되는 함수
    - Update() : 매 프레임 마다 호출
    - OnCollisionXXX2D() (매개변수 : Collider2D) : 물리적 연산 O
      + Collision 충돌 순간 : OnCollisionEnter2D
      + Collision 충돌 중 : OnCollisionStay2D
      + Collision 충돌 끝 : OnCollisionExit2D
      ```csharp
      void OnCollisionEnter2D (Collision2D col){
        Debug.Log (col.gameObject.name);
        GetComponent<SpriteRenderer> ().color = Color.red;
      }
      ```
    - OnTriggerXXX2D() (매개변수 : Collider2D) : 물리적 연산 X
      + OnTriggerEnter2D : 트리거 충돌이 일어나는 순간 호출
      + OnTriggerStay2D : 트리거 충돌 중 호출
      + OnTriggerExit2D : 트리거 충돌이 끝나는 순간 호출
      + IsTrigger을 체크

    - OnMouseXXX
      + OnMouseDown : 클릭하는 순간 호출
      + OnMouseDrag : 누르는 중 호출
      + OnMouseUp : 눌렀다 떼는 순간 호출
        ```csharp
          void OnMouseDown(){
            Debug.Log("mouse down!");
          }

        ```
      > Collider가 있어야 호출 가능, 터치도 작동

    - FixedUpdate : 일정 시간마다 호출 (기본적으로 0.02초마다, 수정 가능)
      + 시간에 따라 동일한 결과를 보고 싶을때 사용
    - LateUpdate : Update 후 매 프레임 마다 호출 (카메라 이동에 빈번하게 사용됨)
    - OnBecameVisible / OnBecameInvisible (카메라에 보일때 Visible 함수 호출 / 안보일때 Invisible 함수 호출)
      ```csharp
      void OnBecameVisible(){
		      Debug.Log ("visible");
        }
	    void OnBecameInvisible(){
		      Debug.Log ("Invisible!");
	      }
	    void Update(){
		      transform.Translate ((Vector3.right) * 0.1f);
	      }
      ```
---
## 접근 한정자
  * public : 모든 곳
    - public으로 선언된 변수는 엔진에서 수정 가능! (Rigidbody2D는 엔진에서 사용자가 Mass, gravityScale등을 바꿀수 있으므로 내부적으로 public으로 선언되어있음을 알 수 있다.)
    - public은 엔진 내에서 보이고 수정 가능하므로, 초기화 과정이 필요가 없다.
      + public int a;
      + public GameObject testObj; (자료형이 GameObject등이라면 testObj라는 변수에 게임오브젝트를 넣을 수 있게됨)
      + public Transform testTf; (어떤 함수의 Transform 컴포넌트를 넣을 수 있음)
      + 외에도 많은 자료형이 존재
      + public string Myname; (문자)
      + public bool checkbox; (체크박스)
      + public KeyCode jumpKey; (keycode)
      + [HideInInspector]를 붙이면 public 이라도 유니티 엔진내에서 안보이게 숨길 수 있음
  * private : 클래스 내부
    - private으로 선언된 변수는 Unity 내에서 보이지 않는다. (접근 한정자를 생략하면 자동으로 private으로 들어간다)
    - private은 초기화를 무조건 해주어야한다 (엔진내에서 수정할 수 없으므로 무조건 어떠한 값을 할당해주어야함.)
    - [SerializeField] 를 붙이면 아무리 private 이라도 유니티 엔진내에서 보이게 할 수 있음
  * internal : 어셈블리 내부
  * protected : 파생 클래스
  * protected internal : 같은 어셈블리 내부 & 파생 클래스

---
## 프로퍼티
  ```csharp
  public int Score(){
    get {
      return score; // Score를 가져올때 score를 리턴한다.
    } //스코어 값을 가져올 때
    set {
      score = value; // Score의 값을 변경하면 score의 값이 변경된다.
    } // 스코어에 값을 집어넣을 때
  }
  ```

  ```csharp
  public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public int Score{
		get {
			return PlayerPrefs.GetInt ("Score", 0);
		}
		set {
			value = Mathf.Clamp (value, 0, 100);
			PlayerPrefs.SetInt ("Score", value);
			scoreText.text = value.ToString ();
		}
	}
	private int score = 0;
}
  ```
---
## 싱글톤 오브젝트
  * 게임 매니저, 오디오 매니저, 데이터 매니저 등 게임 내에 유일한 독립체로 존재하는 오브젝트
  * 특징
    - 클래스의 인스턴스가 하나만 생성됨을 보장
    - 어디서든지 그 인스턴스에 접근 가능
    - 많은 싱글턴 오브젝트는 여러씬에 걸쳐 유지됨
    - static 을 이용해 구현
    ```csharp

    //GameManager script
    public class GameManager : MonoBehaviour {
    	public static GameManager instance;

    	void Awake(){
    		if (instance) {
    			Destroy (gameObject);
    			return;
    		}
    		instance = this;
    	}

    	public Text scoreText;
    	public int Score{
    		get
    		{
    			return score;
    		}

    		set
    		{
    			score = value;
    			scoreText.text = value.ToString("N0");
    		}
    	}
    	private int score;


    }

    ```

```csharp
// ScoreUp 기능을 가진 스크립트가 싱글톤 오브젝트에 접근하는 것
public class ScoreUp : MonoBehaviour {
  public void scoreUp(){
    GameManager.instance.Score += 100;
  }
}

```
---
## singleton 안전하게 보호하기
  * 싱글톤 인스턴스를 여러 곳에서 가져다 쓰면서 그 안의 내용물을 지운다거나 바꿀 수 있음. 그것을 방지하기위해 다음과 같이 '읽기' 만 가능하도록 설정
  ```csharp
  public class GameManager : MonoBehaviour {
	private static GameManager instance; //싱글톤은 private 으로 유지
	public static GameManager Instance{
		get { return instance; } // 가져가는것만 가능하도록 프로퍼티 설정
	}
	public int score;
	void Awake(){
		if (instance) {
			Destroy (gameObject);
			return;
		}
		instance = this;
    DontDestroyOnLoad (gameObject); //다른 씬에서 사용해야하면 여러씬에 거쳐서 파괴되지 않음
	}
}
  ```
---
## script 순서
  * script순서 때문에 GM이 생성되기 전에 다른 스크립트에서 싱글톤 오브젝트에 접근하면 오류가 발생할 수있음.
  * 그래서 다음과 같이 GM 싱글톤을 작성한다면 , 오류 발생 여지가 없음
  ```csharp
  public class GameManager : MonoBehaviour {
  private static GameManager instance;
  public static GameManager Instance{
    get {
      if (instance == null) {
        GameObject tempGM = new GameObject ("GameManager");
        instance =tempGM.AddComponent<GameManager> ();
        DontDestroyOnLoad (tempGM);
      }
      return instance; }
  }
  public int score = 0;
  }
  ```
---
## 컬렉션
  * 데이터의 모음, 자료구조
  * System.Collections , System.Collections.Generic 라이브러리에 존재
  * LIST
    - 배열과 비슷한 컬렉션
    - 배열처럼 대괄호[] 로 요소에 접근이 가능하며, 특정 요소를 바로 읽고 쓸 수 있다.
    - 배열과는 다르게 크기 지정 없이 요소의 추가, 삭제에 따라 자동으로 크기를 늘였다, 줄였다 하기 때문에 메모리 소모가 적다
    - 보통 인벤토리에 많이 사용
    - 단점 : 특정 요소에 접근하는 속도가 조금 느리다.
    ```csharp
    public class CollectionTest : MonoBehaviour {

  	public List<int> intList; // List안에 들어가는 형과 이름을 정의

  	void Start(){
  		intList = new List<int> ();

  		intList.Add (1);
  		intList.Add (2);

  		Debug.Log (intList [0]);
  		Debug.Log (intList.Count); // 총 원소 개수 출력

  		intList.Remove (1); // 1이란 값을 지움
  		intList.RemoveAt(1); // 인덱스 1 에 있는 값을 지움

  		intList.Insert (1, 50); // 첫번째 인덱스에 50이란 값을 집어넣음
  	}

  }

    ```
  * Stack
    - 한 쪽 끝에서만 자료를 넣거나 뺄 수 있는 컬렉션
    - LIFO (Last In First Out)
    - 되돌리기 기능 (Ctrl + Z) 에 많이 사용된다.
    - 오브젝트 풀링 : 오브젝트를 대기시켜놓고 요청할때마다 꺼내주는 역할 구현에 많이 사용한다.
    ```csharp
    public class CollectionTest : MonoBehaviour {

  	Stack<float> testStack = new Stack<float>();

  	void Start(){
  		testStack.Push (1.0f);
  		testStack.Push (2.0f);
  		testStack.Push (-5.3f);

  		Debug.Log(testStack.Pop());
      Debug.Log(testStack.Count);
      testStack.Clear();
  	}
  }


    ```
  * Dictionary
    - 키(Key)와 값(Value)을 가진 컬렉션
    - List가 인덱스(int 형)로 요소에 접근한다면, Dictionary는 키(어떤 형태든 가능)로 요소에 접근이 가능하다.
    - 스킬 정보 가져오기, 텍스트 파일 읽기 등에 사용된다.
    ```csharp
  public class CollectionTest : MonoBehaviour {

  	Dictionary <string,int> testDic = new Dictionary<string,int> (); //key, value에는 어떠한 자료형이든 올 수 있음

  	void Start(){
  		testDic.Add ("High Score", 10000);
  		testDic.Add ("key", 200);

  		Debug.Log (testDic ["key"]); // 200 반환
  	}
  }
    ```
  * 파일로부터 읽어와서 Dictionary에 저장하는 법
  ```csharp
public class CollectionTest : MonoBehaviour {

	Dictionary<int,StatData> dataDic = new Dictionary<int,StatData>();

	void Start(){
		TextAsset textAsset = Resources.Load<TextAsset> ("Datas"); // Resources 파일에 있는 TextAsset 형식의 'Datas' 파일을 받아와서 textAsset 변수에 저장
		string[] lines = textAsset.text.Split ('\n');

		foreach (string line in lines) {
			string[] words = line.Split ('\t');
			// words[0] : level, words[1] : hp, words[2] : mp
			dataDic.Add(int.Parse(words[0]),new StatData(int.Parse(words[1]),int.Parse(words[2])));
		}
    Debug.Log("1 lv.hp : " + dataDic[1].hp);
	}

}


public class StatData{
	public int hp, mp;
	public StatData(int hp, int mp){
		this.hp = hp;
		this.mp = mp;
	}
}
  ```

  * value를 Dictionary로 관리 하는 법
  ```csharp
public class CollectionTest : MonoBehaviour {
	Dictionary<string,Dictionary<int,StatData>> dataDic = new Dictionary<string,Dictionary<int,StatData>>();
	// key는 직업, value 는 스탯(lv,hp,mp)를 딕셔너리로 관리  
	void Start(){
		TextAsset textAsset = Resources.Load<TextAsset> ("Datas");
		string[] lines = textAsset.text.Split ('\n');

		foreach (string line in lines) {
			string[] words = line.Split ('\t');
			// words[0] : level, words[1] : hp, words[2] : mp
			if (dataDic.ContainsKey (words [0])) {

				dataDic.Add (words [0], new Dictionary<int,StatData> ());
			}
			dataDic [words [0]].Add (int.Parse (words [1]), new StatData(int.Parse(words[2]),int.Parse(words[3])));
		}
	}

}


public class StatData{
	public int hp, mp;
	public StatData(int hp, int mp){
		this.hp = hp;
		this.mp = mp;
	}
}
  ```
---
## 형 변환
  * int -> string : int.ToString("형식")
    - 형식에는 N0, N1 등등이 있는데 각각은 소수점 자리 수를 의미함
    - 123456 -> 123,456
  * string -> int : int.Parse("형식")
  * float -> int = (int)변수
---
## enum (열거형)
  * 변수가 가질 수 있는 값의 범위를 지정하는 방법. 쉽게 말해, 자료형을 만드는 것. 변수의 값을 일련의 선택지로 제한할 수 있다.
  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public enum MonsterType {Zombie,Alien,Plant}; // 인덱스값으로 표현가능. Zombie : 0 , Alien : 1 , Plant : 2

  public class Test : MonoBehaviour{
    public MonsterType type = MonsterType.Zombie;

    void Start(){
      Debug.Log(type.ToString());
    }
  }
  ```
---
## Unity 좌표계
  * World Point : 실제로 좌표계에서 우리가 아는 위치 값 (3,1,0) 등
  * Viewport Point : 0~1 사이의 값으로 화면을 기준으로 상대적인 위치값을 나타냄 ((0.4,0.1,0) 이라면 x축으로 40%만큼, y축으로 10%만큼 떨어져있다는 것 )
  * Screen Point : 해상도에 따른 위치값  (해상도 값에 Viewport 값을 곱해주면 나옴)
  ```csharp
  // 클릭하는 곳에 해당 오브젝트 생성하는 코드
  public class pointtest : MonoBehaviour {

	public GameObject obj;
	void Update(){
		if (Input.GetMouseButtonDown (0)) //좌클릭
		{
			GameObject tempObj = Instantiate (obj);
			Vector3 tempV = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			tempV.z = 0f;
			tempObj.transform.position = tempV;
		}
	}
}

  ```  
---
## Foreach 문
  * 배열(or 컬렉션)에 있는 모든 요소들에 대해 반복적인 명령을 수행할 때 사용하는 반복문
  ```csharp
    public class Example : MonoBehaviour{
      public GameObject[] objArr = new GameObject[3];

      private void Start(){
        foreach(GameObject obj in objArr){
          obj.SetActive(false);
        }
        // for ( int i = 0 ; i < 3 ; i++){
        //  objArr[i].SetActive(false);
      //}
      }
    }
  ```
---
## GameObject 변수에 값을 할당하는 방법
  * 1. 에디터에서 씬에 있는 게임 오브젝트 혹은 프리팹을 변수에 드래그&드롭
  * 2. GameObject.Find (씬에 있는 모든 Object를 검사하여 찾아내는 것이므로 부하가 많이 걸림)
  * 3. Resources.Load
  ```csharp
    [SerializeField]
    private GameObject tempObj;
    void Start(){
      tempObj = GameObject.Find("circle");
    }

  ```
  ```csharp
    [SerializeField]
    private Sprite tempObj;
    void start(){
      tempObj = Resources.Load<Sprite>("Box") //프리팹을 로드
    }
  ```
---
## AddForce
  * Rigidbody2D를 가지고있는 오브젝트에게 어떠한 힘을 가하는 것
    ```csharp
    if (Input.GetKeyDown(KeyCode.Space)){
      GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 300f);
    } // space 누르면 점프를 하는 것
    ```
---
## SetActive
  * 물체를 활성/비활성화 상태로 바꾸는 함수
    - gameObject.SetActive(true);
    - gameObject.SetActive(false);
   ```csharp
   if (Input.GetKeyDown (KeyCode.LeftArrow)) {
     testObj.SetActive (false); // 화면에서 없앰
   }
   if (Input.GetKeyDown (KeyCode.RightArrow)) {
     testObj.SetActive (true); // 화면에서 출력
   }
   ```

---
## GUI (unity Graphic User Interface)
  * nGUI : 유료 에셋 제공
  * uGUI : 유니티에서 제공하는 에셋
---
## Canvas
  * UI를 그리는 공간
    - 모든 UI 요소는 Canvas 자식 오브젝트
    - c# 편집시에는 using UnityEngine.UI;를 사용
  * Render Mode : 화면 위에 UI를 그리는 모드
    - Screen Space - Overlay :카메라 비율, 해상도가 변경되면 자동으로 이에 맞춰짐 (포지션을 움직일 수 없고, 카메라와 동떨어진 영역을 갖게 됨)
    - Screen Space - Camera : 캔버스를 내가 원하는 카메라의 영역크기에 맞춤 (가장 많이 쓰는 모드)
      + Plane Distance : 카메라와 캔버스까지의 거리(z값)
      + Canvas Scaler는 세로 게임의 경우 Match Height 쪽으로 맞추고, 가로 게임의 경우 Width 쪽으로 맞춤
    - World Space : 씬에 있는 다른 오브젝트처럼 동작하는 모드 (수동으로 크기, 비율을 조절 가능)
---
## Layout
  * UI를 편집하는 경우 Pivot & Local 설정을 많이 사용
  * Rect tool : UI요소를 이동, 크기 조절, 회전하는데 사용
  * Pivot(피벗(원점)을 다른곳에 두고 그 피벗을 기준으로 편집 가능),Local(사각형의 꼭지점을 잡아줌) 모드를 많이 사용한다.
---
## Rect Transform
  * 모든 오브젝트는 Tranform 컴포넌트를 가지는데, 기존 Transform 컴포넌트 대신 UI에 사용되는 Transform 컴포넌트를 의미한다.
  * Anchors : UI의 부모에 대한 고정 오프셋, 부모 사각형의 폭과 높이에 대한 비율로 정의
    - UI 중 경험치바, 체력 등의 UI는 항상 고정된 위치에 존재하므로 이것이 필요하다.
  * Pos X, Pos Y : 앵커에 대한 피벗 포지션
  * Left,Right,Top,Bottom : 앵커가 떨어져있다면 Pos X, Pos Y대신 다음과 같이 표시되며 각각 앵커로부터 떨어진 거리를 뜻한다.
  * 해상도에 따라서 피벗,앵커로 자동으로 크기가 변환되므로 아주 편함.

---
## Visual Components (Text)
  * 화면에 텍스트를 표시
    - 폰트,크기,정렬을 선택
    - 텍스트가 사각 영역 너비/높이 보다 클 경우 옵션 선택
  * Horizontal Overflow : 가로의 텍스트 크기가 지정한 영역보다 클 때 wrap(보이지 않음),Overflow(최대 사이즈보다 커도 보여줌) 선택 가능
  * Vertical Overflow :  세로의 텍스트 크기가 지정한 영역보다 클 때 wrap(보이지 않음),Overflow(최대 사이즈보다 커도 보여줌) 선택 가능
  * Best fit : 텍스트 영역 크기에 텍스트를 맞춰줌
  * tip : Outline 컴포넌트를 추가하면 텍스트에 테두리를 씌어준다. (훨씬 깔끔하다)

---
## Visual Components (Image)
  * 화면에 스프라이트 이미지를 표시 (canvas 내에)
    - Image Type 이 굉장히 중요
      + simple : 기본
      + sliced : 확대/축소 시에 테두리 부분의 깨짐현상이 발생할 때 미리 슬라이스 영역을 정해서 이를 방지할 수 있다.
      + tiled : 테두리는 유지하고 , 바둑판식으로 채울 수 있다.
      + filled : 스킬 쿨다운이나, 스킬바 등을 만들 때 유용하게 사용할 수 있다. (조금씩 채워지는 것처럼 표현가능)

---
## Visual Components (Button)
  * 버튼을 클릭했을 때 일어나는 동작을 정의
   - 모바일 게임의 대표적인 interaction 컴포넌트
  * Button 에는 4가지 상태가 존재
    - Normal (기본 상태)
    - Highlighted (손을 올렸을때 반짝임)
    - Pressed (눌렸을 때)
    - Disabled (버튼을 사용하지 못하게 막을때)
  * Transition
    - Color Tint : 각 상태마다 색깔 지정가능 (가장 많이 사용)
    - Sprite Swap : 각 상태마다 다른 이미지로 교체 가능
    - Animation : 각 상태마다 애니메이션을 사용
  * On click()
    - 클릭했을 때 어떤 기능이 수행될 것인지를 결정

  > Raycast Target : 비주얼 컴포넌트에 들어가있고, 기본적으로 체크 되어있다. 체크 되어있으면 사용자와 상호작용을 한다는 뜻이므로 다른 버튼등과 겹치게 되면 버튼이 오작동할 수 있음
  그래서 상호작용을 하지않는 이미지 등의 경우 체크 해제를 해주는 것이 좋다.  

---
## Vertical Layout Group Component
  * 오브젝트들을 자동으로 일렬로 정렬해줌
  * 간격도 조정이 가능
  * scroll view를 만들 때 버튼 정렬등에 유용
---
## Input Field
  * Placeholder
  * Text
```csharp
public class passwordManager : MonoBehaviour {
  public InputField inputField;

  public void OkBtn(){
    if (inputField.text.Equals ("12345")) {
      Debug.Log ("Log in");

    } else {
      Debug.Log ("fail!");
    }

  }
}
```

---
## Unity Animation
  * 애니메이션을 표현하려면, Animator라는 컴포넌트를 가지고 있어야함.
    - Animator Controller : 애니메이션 상태를 컨트롤 해주는 에셋
    - Transition : 상태 전환 조건
    - Animation Clip : 재생할 애니메이션 동작 (state 안에 들어감)
---
## Unity 2D (Save & Load)
  * Player Prefs
    - Key : 저장된 데이터의 고유 값/ 문자열 (String) 형식
    - Value : 저장된 데이터 / 정수, 실수, 물자열 형식
  * 데이터 저장하기
    - PlayerPrefs.SetInt(Key,Value) -> 정수형 데이터 저장
    - PlayerPrefs.SetFloat(Key,Value) -> 실수형 데이터 저장
    - PlayerPrefs.SetString(Key,Value) -> 문자형 데이터 저장
    ```csharp
      void Start(){
        PlayerPrefs.SetInt("HighScore",100);
      }
    ```
  * 데이터 불러오기
    - PlayerPrefs.GetInt(Key) -> 정수형 데이터 로드
    - PlayerPrefs.GetFloat(Key) -> 실수형 데이터 로드
    - PlayerPrefs.GetString(Key) -> 문자열 데이터 로드
    ```csharp
      void Start(){
        int highScore;
        highScore = PlayerPrefs.GetInt("HighScore");
      }
    ```
---
## Scene Management
  * 씬(Scene)
    - 게임 오브젝트가 배치되어 있는 파일
    - 메인 메뉴, 레벨 등을 하나의 씬으로 만든다.
    - Scenes bulid : Ctrl + Shift + B
  * 씬 전환하기
    - 씬 전환을 위해서 스크립트 최상단에 'Using UnityEngine.SceneManagement;' 를 사용해주어야 한다.
    - SceneManager.LoadScene(씬 번호) : 해당 번호의 씬을 로드한다.
    - SceneManager.LoadScene(씬 이름) : 해당 이름의 씬을 로드한다.
    ```csharp
    public void SceneLoad(string SceneName){
      SceneManager.LoadScene (SceneName);
    }

    public void SceneLoad(int SceneIndex){
      SceneManager.LoadScene (SceneIndex);
    }
    ```
---
## Audio System
  * Audio Clip 을 최적화하는것이 중요!
  * Force To Mono : 오디오 단일 채널 여부 (용량도 절반으로 줄기 때문에 모바일 게임은 체크하는 것이 좋음) (스테레오가 중요하면 언체크)
  * Load Type
    - Decompress On Load : 오디오 파일의 압축을 메모리에 모두 풀어두는 것, 메모리를 많이 사용한다.장점으로는 오디오를 재생할때 성능이 좋다. (효과음은 이 기능 사용)
    - Compressed In Memory : 메모리에 압축해두겠다.
    - Streaming : 재생하는 부분만 압축해제해서 오디오 재생. 메모리를 가장 적게 차지하는 대신 성능 오버헤드가 심하다. (배경음악은 보통 이 기능 사용)
  * Compression format
    - PCM : 거의 압축을 안하는 것 (재생 빈도 많음 / 크기가 작음)(효과음)
    - Vorbis/mp3 : 압축을 많이 하는 것 (재생빈도 적음 / 크기가 큼)(배경 음악)
---
## Audio Source
  * Mute : 음소거
  * Bypass Reverb Zones : 오디오에 동굴효과 적용
  * Play On Awake : 맨 처음에 플레이를 하면서 오디오 소스가 시작될지의 여부 (배경 음악은 체크 되어있는게 맞음)
  * Loop : 반복
  ```csharp
    GetComponent<AudioSource>().Play // c#환경에서 audiosource 컴포넌트의 함수 잡아내기 Stop,Pause,UnPause 도 사용가능
  ```
---
## Audio Listener
  * Audio Listener은 메인 카메라에 기본적으로 컴포넌트로 존재한다.
  * 씬에 하나만 존재해야한다!
  * 메인카메라를 복사하면 메인카메라에서 Audio Listener을 꺼줘야한다.
  * 오브젝트가 가까워지면 소리를 재생시키려면, 3D sound Settings 에서 Spatial Blend를 1로 키운다.
---
## UnityAds
  * Simple Ads
    - 유저의 의도와 관계없이 출력 , 스킵 가능, 수익성 낮음
  * Reward Ads
    - 유저가 원해서 시청, 스킵 불가능, 수익성 높음
---
