using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Playing_State : MonoBehaviour {

	private Game_Controller gameController;

//	private Player systemPlayer;

	public UI_Controller uiController;

	public GameObject ballManager;
	public GameObject ball;
	public Vector3 ballSpawn;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}

		if (uiController == null)
			uiController = gameController.uiManager.GetComponent<UI_Controller> ();

		// Get the System Player
//		systemPlayer = ReInput.players.GetSystemPlayer();

		//subscribe to this delegate
		Ball_Controller.onGoal += GetPoints;
	}

	public void EnterState () {

		Debug.Log ("playing state");
	}

	public void ExitState () {

		gameController.currentState = Game_Controller.Game_State.End_State;
		gameController.ChangeState ();
	}

	void Update () {

// 		if (ReInput.players.GetPlayer(0).GetButtonDown("Secondary Button") || ReInput.players.GetPlayer(1).GetButtonDown("Secondary Button")) {
// //		if (systemPlayer.GetButtonDown("Cancel Button")) {

// 			ExitState ();
// 		}

	}

	void ReSpawnBall () {

		Instantiate (ball, ballSpawn, Quaternion.identity, ballManager.transform);
	}

	void GetPoints (GameObject keepOwner) {

		//can change from ballOwner to keepOwner to decide what determines the point

		//increase score by 1
		if (keepOwner.name == "Keep 2") {

			Debug.Log ("player 1 point!");
			gameController.playerScores [0] += 1;
			uiController.UpdateScore (gameController.playerScores [0], 0);

		} else if (keepOwner.name == "Keep 1") {

			Debug.Log ("player 2 point!");
			gameController.playerScores [1] += 1;
			uiController.UpdateScore (gameController.playerScores [1], 1);
		}

		ReSpawnBall ();
	}

	void OnDisable () {

		//subscribe is up top!!!
		//unsubscribe to this delegate
		Ball_Controller.onGoal -= GetPoints;
	}
}
