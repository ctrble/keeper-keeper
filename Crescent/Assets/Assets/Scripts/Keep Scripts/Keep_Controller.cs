using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep_Controller : MonoBehaviour {

	public GameObject[] keeps;
	public GameObject keepOwner;

	void OnEnable() {
			
  	keeps = GameObject.FindGameObjectsWithTag("Keep");
	}
}
