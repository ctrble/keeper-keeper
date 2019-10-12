using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Removal_Controller : MonoBehaviour {

	void RemoveBall (GameObject keepOwner) {

		Destroy (gameObject, 0.2f);
	}

	void OnEnable () {

		//subscribe to this delegate
		Ball_Controller.onGoal += RemoveBall;
	}

	void OnDisable () {

		//unsubscribe to this delegate
		Ball_Controller.onGoal -= RemoveBall;
	}
}
