using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

	public GameObject[] playerScore;

	public void UpdateScore(int newScore, int player) {

		string scoreString = newScore.ToString();
		playerScore [player].GetComponent<Text> ().text = scoreString;
	}
}
