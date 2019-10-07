using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

	[Header("Physics Variables")]
	public double particleCharge;
	public double particleMass;
	public double particleSpeed;

	[Header("Creation Variables")]
	public bool canFollowMouse;
	private Vector3 mousePosition;
	private Vector3 smoothVelocity = Vector3.zero;
	public float mouseFollowSpeed;

	[Header("Sthetic Variables")]
	public Material[] particlePossibleMaterials;
	public int materialSelected;
	private Renderer particleRenderer;
	// Use this for initialization
	void Awake () {
		particleRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canFollowMouse == true) {
			mousePosition = Input.mousePosition;
			mousePosition.z = transform.position.z - Camera.main.transform.position.z;
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
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
}
