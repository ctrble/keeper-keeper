using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sprite_Controller : MonoBehaviour {

	private Game_Controller gameController;

	public Sprite[] playerSprites;

	//the SpriteRenderer
	public SpriteRenderer spriteRenderer;

	public void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = GameObject.Find ("Game Controller").GetComponent<Game_Controller> ();
		}

		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer> ();

		SetSprite ();
	}

	void SetSprite () {

		for (int i = 0; i <= gameController.playerCount; i++) {

			if (gameObject.transform.parent.name == "Player " + (i + 1) + "(Clone)")
				spriteRenderer.sprite = playerSprites [i];
		}
	}
}
