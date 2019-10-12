using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpers_Controller : MonoBehaviour {

	//the Rigidbody2D
	public Rigidbody2D rigidBody2D;
	public GameObject parent;

	void OnEnable() {

		if (parent == null) {
			parent = gameObject.transform.parent.gameObject;
		}
		
		if (rigidBody2D == null) {
			rigidBody2D = parent.GetComponent<Rigidbody2D> ();
		}

		rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
		rigidBody2D.mass = 2;
		rigidBody2D.drag = 20;
		rigidBody2D.angularDrag = 10000;
		rigidBody2D.gravityScale = 0;
	}
}
