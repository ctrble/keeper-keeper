using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup_State : MonoBehaviour {

	private Game_Controller gameController;

	public GameObject playerManager;
	public GameObject[] playerObjects;
	public Vector3[] playerSpawn;

	public GameObject ballManager;
	public GameObject ball;
	public Vector3 ballSpawn;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}
	}

	public void EnterState () {

		Debug.Log ("setup state");
		SetupGame ();
	}

	public void ExitState () {

		gameController.currentState = Game_Controller.Game_State.Playing_State;
		gameController.ChangeState ();
	}

	void SetupGame() {

		Debug.Log ("Set up the game now!");

		SpawnPlayers (gameController.playerCount);
		SpawnBall ();

		ExitState ();
	}

	void SpawnPlayers (int playerCount) {

		//spawn players until joysticks and max players are filled
		for (int i = 0; i < playerCount && i < playerObjects.Length; i++) {

			Instantiate (playerObjects[i], playerSpawn[i], Quaternion.identity, playerManager.transform);
		}
	}

	void SpawnBall () {

		Instantiate (ball, ballSpawn, Quaternion.identity, ballManager.transform);
	}
}
