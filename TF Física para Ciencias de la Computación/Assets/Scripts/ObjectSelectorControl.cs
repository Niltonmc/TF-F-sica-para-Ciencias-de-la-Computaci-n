using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectorControl : MonoBehaviour {

	RaycastHit hitRay;
	Ray ray;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray,out hitRay, 100.0f)){
			if (hitRay.transform != null) {
				if(Input.GetMouseButtonDown(0) == true){
					if (hitRay.transform.gameObject.GetComponent<ParticleControl> () != null) {
						print ("uwu");
					}
				}
			}
		}
	}
}
