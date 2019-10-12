using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Controller : MonoBehaviour {

	public Rigidbody2D rigidBody2D;
	public Animator animator;

	public GameObject buttonOpen;
	public GameObject buttonClosed;

	public bool open;

	void OnEnable() {

		if (rigidBody2D == null)
			rigidBody2D = GetComponentInChildren<Rigidbody2D> ();

		if (animator == null)
			animator = GetComponent<Animator> ();

	}

	void Update() {

		if (buttonOpen.activeInHierarchy){

			open = true;
		} else if (buttonClosed.activeInHierarchy) {

			open = false;
		}
	}

	public void ButtonOpen() {

		buttonOpen.SetActive(true);
	}

	public void ButtonClosed() {

		buttonClosed.SetActive(true);
	}
}
