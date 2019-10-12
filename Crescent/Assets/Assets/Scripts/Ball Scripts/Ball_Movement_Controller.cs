using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement_Controller : MonoBehaviour {

	//the Rigidbody2D
	public Rigidbody2D rigidBody2D;

	float maxVelocity;
	float sqrMaxVelocity;

	void OnEnable () {

		if (rigidBody2D == null)
			rigidBody2D = GetComponentInParent<Rigidbody2D> ();

		maxVelocity = 40f; //25
		sqrMaxVelocity = maxVelocity * maxVelocity;
	}

	void FixedUpdate () {

		LimitVelocity ();
	}

	void LimitVelocity () {

		if (rigidBody2D.velocity.sqrMagnitude > sqrMaxVelocity) {

			rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxVelocity;
			// Debug.Log ("limiting ball");
		}
	}
}
