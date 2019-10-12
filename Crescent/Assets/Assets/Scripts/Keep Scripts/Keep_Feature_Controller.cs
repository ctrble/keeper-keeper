using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep_Feature_Controller : MonoBehaviour {

	//the Rigidbody2D
	public Rigidbody2D rigidBody2D;

	public bool bumpersBool;
	public bool toggleBool;

	public GameObject bumpers;
	public GameObject toggle;

	void OnEnable() {

		if (rigidBody2D == null) {
			rigidBody2D = GetComponent<Rigidbody2D> ();
		}

		//true for now, later have it based on level choice or something
		// bumpersBool = true;
		// toggleBool = true;

		HasBumpers();
		HasToggle();
	}

	void Update() {
			
		
	}

	public bool HasBumpers () {

		if (bumpersBool) {
		
			bumpers.gameObject.SetActive(true);
			return true;
		} else {

			bumpers.gameObject.SetActive(false);
			ResetRigidBody();
			return false;
		}
	}

	public bool HasToggle () {

		if (toggleBool) {
		
			toggle.gameObject.SetActive(true);
			return true;
		} else {

			toggle.gameObject.SetActive(false);
			return false;
		}
	}

	void ResetRigidBody() {
		rigidBody2D.bodyType = RigidbodyType2D.Static;
	}
}
