using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour {

	//the Input_Controller script
	public Input_Controller playerInput;

	//the Rigidbody2D
	public Rigidbody2D rigidBody2D;

	public int thrust;
	public float currentThrust;
	public int torque;
	public float circleFunction;
	public float angle;
	public float lastAngle;
	public float pureHorizontal;
	public float pureVertical;
	public float horizontal;
	public float vertical;

	void OnEnable () {

		//get the Input_Controller script
		if (playerInput == null)
			playerInput = GetComponentInParent<Input_Controller> ();

		if (rigidBody2D == null)
			rigidBody2D = GetComponent<Rigidbody2D> ();

		thrust = 60; //1500; //6
		torque = 25; //thrust * 20; //175
		circleFunction = 0.7071f;
		angle = -90;
		rigidBody2D.centerOfMass = Vector3.zero;
	}

	void Update() {

		pureHorizontal = Mathf.Abs (playerInput.Horizontal());
		pureVertical = Mathf.Abs (playerInput.Vertical());
		horizontal = playerInput.Horizontal();
		vertical = playerInput.Vertical();
	}

	void FixedUpdate () {

		Move ();
		Angle ();
	}

	void Move () {

		//adjust speed for diagonal movement
		currentThrust = pureHorizontal > 0 && pureVertical > 0 ? thrust * circleFunction : thrust;

		if (pureHorizontal > 0.35f || pureVertical > 0.35f)
			rigidBody2D.AddForce(new Vector2(horizontal * currentThrust, vertical * currentThrust), ForceMode2D.Impulse);
	}

	void Angle () {

		//get angle
		if (pureHorizontal > 0 || pureVertical > 0)
			lastAngle = Mathf.Atan2 (-horizontal, vertical) * Mathf.Rad2Deg;

		//new direction!
		rigidBody2D.MoveRotation(Mathf.LerpAngle(rigidBody2D.rotation, lastAngle, torque * Time.deltaTime));
	}
}
