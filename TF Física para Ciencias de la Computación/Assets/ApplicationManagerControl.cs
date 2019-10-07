using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationManagerControl : MonoBehaviour {

	public bool isCreatingObject;
	public int typeOfCreatingObject;

	[Header("Particle Variables")]
	public GameObject particleGameobject;
	private GameObject currentInstantiateParticle;
	private ParticleControl selectedParticle;

	[Header("Particle Canvas Variables")]
	public GameObject canvasParticleEdit;
	public InputField particleWeightInputField;
	public InputField particleChargeInputField;

	[Header("Magnetic Field Variables")]
	public GameObject magneticFieldGameobject;
	private GameObject currentInstantiateMagneticField;
	private MagneticFieldControl selectedMagneticField;

	[Header("Magnetic Canvas Variables")]
	public GameObject canvasMagneticFieldEdit;
	public InputField magneticFieldXDistanceInputField;
	public InputField magneticFieldYDistanceInputField;
	public InputField magneticFieldChargeInputField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (isCreatingObject == true) {
				switch (typeOfCreatingObject) {
				case 0:
					currentInstantiateParticle.GetComponent<ParticleControl> ().StopFollowMousePosition ();
					isCreatingObject = false;
					break;
				case 1:
					currentInstantiateMagneticField.GetComponent<MagneticFieldControl> ().StopFollowMousePosition ();
					isCreatingObject = false;
					break;
				}
			}
		}
	}
	public void InstantiateParticle(){
		if (isCreatingObject == false) {
			currentInstantiateParticle = Instantiate (particleGameobject, Input.mousePosition, transform.rotation);
			currentInstantiateParticle.GetComponent<ParticleControl> ().SetFollowMousePosition ();
			currentInstantiateParticle.GetComponent<ParticleControl> ().ChangeParticleCharge ();
			isCreatingObject = true;
			typeOfCreatingObject = 0;
		}
	}
	public void ShowEditCanvas(ParticleControl tmp){
		if (isCreatingObject == false) {
			selectedParticle = tmp;
			particleChargeInputField.text = selectedParticle.particleCharge.ToString ();
			particleWeightInputField.text = selectedParticle.particleMass.ToString ();
			canvasParticleEdit.gameObject.SetActive (true);
		}
	}
	public void CancelEditCanvas(){
		selectedParticle = null;
		canvasParticleEdit.gameObject.SetActive (false);
	}
	public void SaveParticleVariables(){
		if (particleChargeInputField.text != "" && particleChargeInputField.text != "") {
			selectedParticle.particleCharge = double.Parse (particleChargeInputField.text);
			selectedParticle.particleMass = double.Parse (particleWeightInputField.text);
			selectedParticle.ChangeParticleCharge ();
			canvasParticleEdit.gameObject.SetActive (false);
		}
	}
	public void InstantiateMagnetricField(){
		if (isCreatingObject == false) {
			currentInstantiateMagneticField = Instantiate (magneticFieldGameobject, Input.mousePosition, transform.rotation);
			currentInstantiateMagneticField.GetComponent<MagneticFieldControl> ().SetFollowMousePosition ();
			isCreatingObject = true;
			typeOfCreatingObject = 1;
		}
	}
	public void ShowEditCanvas(MagneticFieldControl tmp){
		if (isCreatingObject == false) {
			selectedMagneticField = tmp;
			magneticFieldXDistanceInputField.text = selectedMagneticField.xDistance.ToString ();
			magneticFieldYDistanceInputField.text = selectedMagneticField.yDistance.ToString ();
			magneticFieldChargeInputField.text = selectedMagneticField.magneticField.ToString ();
			canvasMagneticFieldEdit.gameObject.SetActive (true);
		}
	}
	public void CancelEditMagneticFieldCanvas(){
		selectedMagneticField = null;
		canvasMagneticFieldEdit.gameObject.SetActive (false);
	}
	public void SaveMagneticFieldVariables(){
		if (magneticFieldXDistanceInputField.text != "" && magneticFieldYDistanceInputField.text != ""
			&& magneticFieldChargeInputField.text != "") {
			selectedMagneticField.xDistance = double.Parse (magneticFieldXDistanceInputField.text);
			selectedMagneticField.yDistance = double.Parse (magneticFieldYDistanceInputField.text);
			selectedMagneticField.magneticField = double.Parse (magneticFieldChargeInputField.text);
			selectedMagneticField.ChangeMagneticFieldVariables ();
			canvasMagneticFieldEdit.gameObject.SetActive (false);
		}
	}
}
