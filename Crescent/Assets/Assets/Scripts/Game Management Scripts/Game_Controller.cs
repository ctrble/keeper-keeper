using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Game_Controller : MonoBehaviour {

	/*
	State Machine
	Setup > Playing
		Set Score -- Always 0 to start
		Set Players -- # of Players w/ asssigned controllers (get from Player Prefs)
		Spawn All -- Players, Ball, Goals (get from Player Prefs)
	Playing > End
		Physics On -- Global bool
		Update Score 
		Player Input On
	End > Setup | Exit Game
		Despawn All -- Players, Ball, Goals
		Restart Game -- Back to Setup
		Exit Game -- Back to Main Menu
	*/

	//create an enum for the game states
	public enum Game_State {Setup_State, Playing_State, End_State}

	//variables for all the state scripts
	public Setup_State setupState;
	public Playing_State playingState;
	public End_State endState;

	//variables to tell the script which state to use
	public Game_State currentState;

	//other managers
	public GameObject playerManager;
	public GameObject ballManager;
	public GameObject keepManager;
	public GameObject uiManager;

	//global variables
	//# of players (later get from player prefs)
	//points per player
	public int playerCount;
	public int[] playerScores;

	void Awake () {
		
		//first, reference all of the state scripts
		setupState = GetComponent<Setup_State> ();
		playingState = GetComponent<Playing_State> ();
		endState = GetComponent<End_State> ();

		//get prepping
		currentState = Game_State.Setup_State;

		//temp, later get from player prefs
		playerCount = 2;
		playerScores = new int [playerCount];

		for (int i = 0; i < playerCount; i++) {
			playerScores[i] = 0;
		}

		//ready to go
		ChangeState ();
	}

	public void ChangeState () {

		//new state!
		switch (currentState) {
		case Game_State.Setup_State:
			setupState.EnterState ();
			break;
		case Game_State.Playing_State:
			playingState.EnterState ();
			break;
		case Game_State.End_State:
			endState.EnterState ();
			break;
		}
	}
}
