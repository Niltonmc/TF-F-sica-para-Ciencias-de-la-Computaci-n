using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

	[Header("Physics Variables")]
	public double particleCharge;
	public double particleMass;
	public double particleSpeedX;
	public double particleAcceleration;
	public double initialPosY;

	[Header("Creation Variables")]
	public bool canFollowMouse;
	private Vector3 mousePosition;
	public float mouseFollowSpeed;

	[Header("Sthetic Variables")]
	public Material[] particlePossibleMaterials;
	public int materialSelected;
	private Renderer particleRenderer;

	[Header("Other Variables")]
	//public float timeForMovement;
	public bool startMovement = false;
	//private float currentTimeForMovement;

	// Use this for initialization
	void Awake () {
		particleRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canFollowMouse == true && startMovement == false) {
			mousePosition = Input.mousePosition;
			mousePosition.z = transform.position.z - Camera.main.transform.position.z;
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
		/*
		if (canFollowMouse == false && startMovement == false) {
			currentTimeForMovement = currentTimeForMovement + Time.deltaTime;
			if (currentTimeForMovement >= timeForMovement) {
				startMovement = true;
			}
		*/
		if (startMovement == true) {
			transform.position = new Vector3 (transform.position.x+(float)particleSpeedX*Time.deltaTime,
				transform.position.y, transform.position.z);
		}
	}
	public void ChangeParticleCharge(){
		if (particleCharge < 0) {
			materialSelected = 0;
		} else if (particleCharge == 0) {
			materialSelected = 1;
		} else if (particleCharge > 0) {
			materialSelected = 2;
		}
		particleRenderer.sharedMaterial = particlePossibleMaterials[materialSelected];
	}
	public void SetFollowMousePosition(){
		canFollowMouse = true;
	}
	public void StopFollowMousePosition(){
		canFollowMouse = false;
	}
	public void CalculateAceleration(double E){
		particleAcceleration = particleCharge * E / particleMass;
	}
	public void CalculateMovement(){

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MagneticField") {
			print ("Aqui se aplica la formula");
		}
	}
}
