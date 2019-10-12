using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Masker : MonoBehaviour {

	public GameObject arenaWalls;
	public EdgeCollider2D arenaCollider;

	void OnEnable () {

		//get arena walls
		if (arenaCollider == null)
			arenaCollider = arenaWalls.GetComponent<EdgeCollider2D> ();
	}

	void OnTriggerEnter2D (Collider2D other) {

		//let player or ball inside the goal
		if (other.gameObject.transform.parent.tag == "Player" || other.gameObject.transform.parent.tag == "Ball") {

			Physics2D.IgnoreCollision(arenaCollider, other.GetComponentInChildren<Collider2D>());
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		//now player or ball can hit walls while outside the goal
		if (other.gameObject.transform.parent.tag == "Player" || other.gameObject.transform.parent.tag == "Ball") {

			Physics2D.IgnoreCollision(arenaCollider, other.GetComponentInChildren<Collider2D>(), false);
		}
	}
}
