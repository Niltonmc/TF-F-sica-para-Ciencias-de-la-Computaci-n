using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicateChangeLanguage : MonoBehaviour {

	private Text textToChange;
	public TextAsset textLanguagesAsset;
	public string[] posibleTextStrings;
	// Use this for initialization
	void Awake () {
		textToChange = GetComponent<Text> ();
		ReadTextAsset ();
		SetNewLanguage(PlayerPrefs.GetInt("CurrentLanguage"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void ReadTextAsset(){
		if (textLanguagesAsset != null) {
			posibleTextStrings = textLanguagesAsset.text.Split ('\n');
		}
	}
	public void SetNewLanguage(int pos){
		textToChange = GetComponent<Text> ();
		ReadTextAsset ();
		textToChange.text = posibleTextStrings [pos];
	}
}
