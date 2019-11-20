using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguageControl : MonoBehaviour {

	public ApplicateChangeLanguage[] allApplicateLanguages;
	public int currentLanguage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeLanguage(int tmp){
		currentLanguage = tmp;
		for (int i = 0; i < allApplicateLanguages.Length; i++) {
			print (i);
			allApplicateLanguages [i].SetNewLanguage (currentLanguage);
		}
	}
	public void RestoreLanguage(){
		int tmp = PlayerPrefs.GetInt ("CurrentLanguage");
		for (int i = 0; i < allApplicateLanguages.Length; i++) {
			allApplicateLanguages [i].SetNewLanguage (tmp);
		}
	}
}
