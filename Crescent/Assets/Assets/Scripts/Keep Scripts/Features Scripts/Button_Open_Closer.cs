using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Open_Closer : MonoBehaviour {

	public GameObject backWall;
	public Animator animator;
	public GameObject hitBy;
	public GameObject pusher;

	void OnEnable() {

		if (animator == null)
			animator = GetComponentInParent<Animator> ();

		transform.localPosition = new Vector3 (0, 0, 0);

		StartCoroutine("Setup");
	}

	IEnumerator Setup() {

		yield return new WaitForSeconds(0.2f);
		backWall.SetActive(true);

		if (gameObject.name == "Button Closed")
			pusher.SetActive(false);
	}

	void FixedUpdate() {

		// transform.localPosition = new Vector3(0, transform.localPosition.y, 0);	
	}

	void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.tag == "Player") {
			
			hitBy = other.gameObject;
		}

		if (other.gameObject.name == backWall.name) {
			
			if (gameObject.name == "Button Open")
				pusher.SetActive(true);

			backWall.SetActive(false);
			gameObject.SetActive(false);
		}
	}

	void OnDisable() {

		if(gameObject.name == "Button Open")
			animator.SetTrigger("close");

		if(gameObject.name == "Button Closed")
			animator.SetTrigger("open");
	}
}
