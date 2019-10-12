using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Camera_Controller : MonoBehaviour {

	void Awake () {
	
		// Switch to 640 x 480 fullscreen
//		Screen.SetResolution(640, 480, true);
		Debug.Log (Screen.width + " " + Screen.height);
	}
}



