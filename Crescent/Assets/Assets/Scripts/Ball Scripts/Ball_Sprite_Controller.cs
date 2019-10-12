using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Sprite_Controller : MonoBehaviour {

	public Sprite[] ballSprites;
	public Color[] playerColors;

	//the SpriteRenderer
	public SpriteRenderer spriteRenderer;
	public TrailRenderer trailRenderer;

	void OnEnable () {

		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer> ();

		SetSprite (4);
	}

	public void SetSprite (int ballOwner) {

		spriteRenderer.sprite = ballSprites[ballOwner];
		SetGradient(ballOwner);
	}

	void SetGradient(int ballOwner) {

		Gradient gradient = new Gradient();
		gradient.SetKeys(
				new GradientColorKey[] { new GradientColorKey(playerColors [ballOwner], 0), new GradientColorKey(playerColors [ballOwner], 1) },
				new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(1, 1.0f) }
				);
		trailRenderer.colorGradient = gradient;
	}
}
