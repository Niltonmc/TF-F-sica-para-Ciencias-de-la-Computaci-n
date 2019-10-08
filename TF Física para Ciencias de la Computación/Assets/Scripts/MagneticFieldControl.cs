using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldControl : MonoBehaviour {

	[Header("Physics Variables")]
	public double xDistance;
	public double yDistance;
	public double magneticField;

	[Header("Creation Variables")]
	public bool canFollowMouse;
	private Vector3 mousePosition;
	public float mouseFollowSpeed;

	[Header("Sthetic Variables")]
	public Material[] magneticPossibleMaterials;
	public int materialSelected;
	private Renderer magneticPossibleRenderer;
	// Use this for initialization
	void Start () {
		magneticPossibleRenderer = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (canFollowMouse == true) {
			mousePosition = Input.mousePosition;
			mousePosition.z = transform.position.z - Camera.main.transform.position.z;
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
	}
	public void ChangeMagneticFieldCharge(){
		if (magneticField < 0) {
			materialSelected = 0;
		} else if (magneticField == 0) {
			materialSelected = 1;
		} else if (magneticField > 0) {
			materialSelected = 2;
		}
		magneticPossibleRenderer.sharedMaterial = magneticPossibleMaterials[materialSelected];
	}
	public void SetFollowMousePosition(){
		canFollowMouse = true;
	}
	public void StopFollowMousePosition(){
		canFollowMouse = false;
	}
	public void ChangeMagneticFieldVariables(){
		gameObject.transform.localScale = new Vector3 ((float)xDistance, (float)yDistance, gameObject.transform.localScale.z);
		ChangeMagneticFieldCharge ();
	}
}
