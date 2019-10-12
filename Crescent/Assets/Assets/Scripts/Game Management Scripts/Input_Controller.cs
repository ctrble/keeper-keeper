using UnityEngine;
using System.Collections;
using Rewired;

public class Input_Controller : MonoBehaviour {

/*

SETUP

Attach this script to each player GameObject.
The player objects should be named "Player 1", "Player 2", and so forth.

Reference this script from other scripts with:


//the Input_Controller script
public Input_Controller playerInput;

void OnEnable () {

	//get the Input_Controller script
	if (playerInput == null)
		playerInput = GetComponent<Input_Controller> ();
}

void Update () {

	//check the button bools
	if(playerInput.Button1())
		//do some stuff
}
*/

	//Rewired
	public int playerId;
	private Player player;

	//axis and buttons
	private string horizontalAxis = "Move Horizontal";
	private string verticalAxis = "Move Vertical";
	private string primaryButton = "Primary Button";
	private string secondaryButton = "Secondary Button";

	void OnEnable () {

		//set player id
		SetPlayerControls ();
	}

	void SetPlayerControls () {

		//player 1
		if (gameObject.name == "Player 1(Clone)" || gameObject.name == "Player 1") {

			playerId = 0;
		}

		//player2
		if (gameObject.name == "Player 2(Clone)" || gameObject.name == "Player 2") {

			playerId = 1;
		}

		//player3
		if (gameObject.name == "Player 3(Clone)" || gameObject.name == "Player 3") {

			playerId = 2;
		}

		//player4
		if (gameObject.name == "Player 4(Clone)" || gameObject.name == "Player 4") {

			playerId = 3;
		}

		// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);
	}

	public float Horizontal () {

		return player.GetAxis(horizontalAxis);
	}

	public float Vertical () {

		return player.GetAxis(verticalAxis);
	}

	public bool PrimaryButton () {

		if (player.GetButtonDown (primaryButton)) {
		
			return true;
		} else {
			return false;
		}
	}

	public bool SecondaryButton () {

		if (player.GetButtonDown (secondaryButton)) {

			return true;
		} else {
			return false;
		}
	}
}