using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationManagerControl : MonoBehaviour {

	public bool isCreatingObject;

	[Header("Particle Variables")]
	public GameObject particleGameobject;
	private GameObject currentInstantiateObject;
	private ParticleControl selectedParticle;

	[Header("Particle Canvas Variables")]
	public GameObject canvasParticleEdit;
	public InputField particleWeightInputField;
	public InputField particleChargeInputField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (isCreatingObject == true) {
				currentInstantiateObject.GetComponent<ParticleControl> ().StopFollowMousePosition ();
				isCreatingObject = false;
			}
		}
	}
	public void InstantiateParticle(){
		if (isCreatingObject == false) {
			currentInstantiateObject = Instantiate (particleGameobject, Input.mousePosition, transform.rotation);
			currentInstantiateObject.GetComponent<ParticleControl> ().SetFollowMousePosition ();
			currentInstantiateObject.GetComponent<ParticleControl> ().ChangeParticleCharge ();
			isCreatingObject = true;
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
}
