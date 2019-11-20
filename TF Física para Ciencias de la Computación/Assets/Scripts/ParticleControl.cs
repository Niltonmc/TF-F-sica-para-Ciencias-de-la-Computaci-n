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
	private Rigidbody rbParticle;
	public double magneticField;
	public bool startMovement = false;
	public bool startParabolicMovement = false;
	//private float currentTimeForMovement;


	[Header("X Axis Variables")]
	private float xPosition;
	private float velocityAxisX;

	[Header("Y Axis Variables")]
	public float yInitialPosition;
	private float yPosition;
	private float velocityAxisY;

	[Header("Movement Variables")]
	public bool canFollowPath;
	public float gravity;
	public float angleMovement;
	public float velocity;
	public float totalMovementTime;
	private float currentTime;

	// Use this for initialization
	void Awake () {
		particleRenderer = GetComponent<Renderer> ();
		rbParticle = GetComponent<Rigidbody> ();
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
			if (startParabolicMovement == false) {
				transform.position = new Vector3 (transform.position.x + (float)particleSpeedX * Time.deltaTime,
					transform.position.y, transform.position.z);
			} else {
				//MoveParabolic ();
			}
		}
	}
	void FixedUpdate(){
		if (startMovement == true) {
			if (startParabolicMovement == true) {
				transform.position = new Vector3 (transform.position.x + (float)particleSpeedX * Time.deltaTime,
					transform.position.y, transform.position.z);
				rbParticle.AddForce (0, (float)( magneticField * particleCharge / particleMass), 0, ForceMode.Acceleration);
			}
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
			print ("entra");
			magneticField = other.gameObject.GetComponent<MagneticFieldControl> ().magneticField;
			//CalculateTotalMovementTime ((float)particleSpeedX, 90.0f, transform.position.y, new Vector2 (0, 0));
			startParabolicMovement = true;
		}
	}

	public void CalculateTotalMovementTime(float vel, float angle, float initialY,Vector2 playerPos){
		velocity = vel;
		angleMovement = angle;
		yInitialPosition = initialY;
		velocityAxisX = velocity * Mathf.Cos (angleMovement * Mathf.Deg2Rad);
		velocityAxisY = velocity * Mathf.Sin (angleMovement * Mathf.Deg2Rad);
		float x1 = (velocityAxisY + Mathf.Sqrt ((velocityAxisY * velocityAxisY) - 2 * gravity * yInitialPosition)) / gravity;
		float x2 = (velocityAxisY - Mathf.Sqrt ((velocityAxisY * velocityAxisY) - 2 * gravity * yInitialPosition)) / gravity;
		if (x1 < 0) {
			totalMovementTime = x2;
		}
		if (x2 < 0) {
			totalMovementTime = x1;
		}
		canFollowPath = true;
	}

	public void CalculateTotalMovementTime(float velX, float velY, float angle, float initialY,Vector2 playerPos){
		angleMovement = angle;
		yInitialPosition = initialY;
		velocityAxisX = velX;
		velocityAxisY = velY;
		float x1 = (velocityAxisY + Mathf.Sqrt ((velocityAxisY * velocityAxisY) - 2 * gravity * yInitialPosition)) / gravity;
		float x2 = (velocityAxisY - Mathf.Sqrt ((velocityAxisY * velocityAxisY) - 2 * gravity * yInitialPosition)) / gravity;
		if (x1 < 0) {
			totalMovementTime = x2;
		}
		if (x2 < 0) {
			totalMovementTime = x1;
		}
		canFollowPath = true;
	}

	void MoveParabolic(){
		if (currentTime < totalMovementTime) {
			currentTime = currentTime + Time.deltaTime;
			xPosition = velocityAxisX * currentTime;
			yPosition = velocityAxisY * currentTime - (gravity * currentTime * currentTime) / 2;
			transform.position = new Vector2 (xPosition, yPosition);
		}
	}
}
