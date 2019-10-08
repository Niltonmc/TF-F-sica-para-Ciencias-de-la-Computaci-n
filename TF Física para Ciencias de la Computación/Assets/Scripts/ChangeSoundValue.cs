using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSoundValue : MonoBehaviour {

	private float soundsValue;
	private float initialSoundValue;
	public ApplicateSoundValue[] soundToAffect;
	public string typeSoundPref;
	public Slider _slide;
	public Text soundsValueText;
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetInitialValues(){
		soundsValue = PlayerPrefs.GetFloat (typeSoundPref);
		_slide.value = soundsValue*10;
		soundsValueText.text = (soundsValue*10).ToString ("F0");
		SaveInitialVolume ();
	}
	public void ChangeSoundsValue(){
		soundsValue = (_slide.value/10f);
		soundsValueText.text = (soundsValue*10).ToString ("F0");
		for (int i = 0; i < soundToAffect.Length; i++) {
			soundToAffect[i].ApplicateChange (soundsValue);
		}
	}
	public void SaveInitialVolume(){
		initialSoundValue = soundsValue;
	}
	public void RestorePreviousVolume(){
		soundsValue = initialSoundValue;
		soundsValueText.text = (soundsValue*10).ToString ("F0");
		for (int i = 0; i < soundToAffect.Length; i++) {
			soundToAffect[i].ApplicateChange (soundsValue);
		}
	}
	public void SaveNewVolume(){
		PlayerPrefs.SetFloat (typeSoundPref, soundsValue);

	}
}
