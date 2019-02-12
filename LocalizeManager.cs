using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizeManager : MonoBehaviour {
	public string textDataPath = "LocalizeText";
	public SystemLanguage baseLanguage; //기본 언어
	public SystemLanguage[] useLanguages; //사용할 수 있는 언어
	private SystemLanguage systemLanguage; // 최종적으로 사용할 언어

	public Dictionary<SystemLanguage, List<string>> textDic = new Dictionary<SystemLanguage, List<string>> ();

	public static LocalizeManager Instance {
		get {
			return instance;
		}
	}
	private static LocalizeManager instance;

	void Awake() {
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	
		SystemLanguage deviceSystemLanguage = Application.systemLanguage; //이 device의 언어를 가져옴

		systemLanguage = baseLanguage;
		foreach (SystemLanguage item in useLanguages) {
			if (deviceSystemLanguage.Equals (item)) {
				systemLanguage = item;
			}
		}

		foreach (SystemLanguage tLanguage in useLanguages) {
			textDic.Add (tLanguage, new List<string> ());
		}
	
		TextAsset ta = Resources.Load<TextAsset> (textDataPath);
		string[] lines = ta.text.Split ('\n');
		foreach (string line in lines) {
			string[] words = line.Split ('\t');
			for (int i = 0; i < useLanguages.Length; i++) {
				textDic [useLanguages [i]].Add (words [i]);
			}
		}
	}
	public static string GetText(int index) {
		return Instance.textDic [Instance.systemLanguage] [index];
	}
}
