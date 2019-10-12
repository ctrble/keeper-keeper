using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour {

	public delegate void GoalAction(GameObject keepOwner); //send GameObject info with this event
	public static event GoalAction onGoal;

	public GameObject keepOwner;
	public GameObject ballOwner;

	//the SpriteRenderer
	public Ball_Sprite_Controller ballSpriteController;

	void OnEnable () {

		if (ballSpriteController == null)
			ballSpriteController = GetComponentInChildren<Ball_Sprite_Controller> ();
	}

	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log(other.gameObject.tag);

		if (other.tag == "Inside Keep") {

			if (null != onGoal) {

				//currently broadcasts to Game_Management_Controller and Ball_Removal_Controller
				keepOwner = other.transform.parent.gameObject;
				onGoal (keepOwner); //trigger event and send GameObject info
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.tag == "Player") {

			//visually track who "owns" the ball
			ballOwner = other.gameObject;

			if (ballOwner.name == "Player 1(Clone)")
				ballSpriteController.SetSprite (0);

			else if (ballOwner.name == "Player 2(Clone)")
				ballSpriteController.SetSprite (1);

			else if (ballOwner.name == "Player 3(Clone)")
				ballSpriteController.SetSprite (2);

			else if (ballOwner.name == "Player 4(Clone)")
				ballSpriteController.SetSprite (3);
		}
	}
}
