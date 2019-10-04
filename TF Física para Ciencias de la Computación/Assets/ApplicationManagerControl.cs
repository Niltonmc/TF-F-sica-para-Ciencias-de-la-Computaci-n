using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManagerControl : MonoBehaviour {

	public GameObject particleGameobject;
	private GameObject currentInstantiateObject;
	public bool isCreatingObject;
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
}
