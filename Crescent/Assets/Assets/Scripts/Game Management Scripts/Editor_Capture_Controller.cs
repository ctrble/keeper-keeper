using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Editor_Capture_Controller : MonoBehaviour {

	// Capture frames as a screenshot sequence stored as PNG files in a folder
	// Can them combine them into a video using software like ffmpeg

	public bool recordScreen = true;
	public string recordButton = "9"; // Or set whatever key you want in the Inspector
	public int frameRate = 24; // Remember to also set this in the frames to video script outside of Unity
	public int magnificaton = 0; // Default is 0, Unity will multiply screenshot resolution with magnification x magnification (like 4x4), be wary of performance
	private int elapsedTime;
	private int countOffset;
	private int fileName;
	private string folder;
	private string date;

	public RenderTexture currentRT;

	void Start () {

		// Set the playback framerate (real time will not relate to game time after this).
		Time.captureFramerate = frameRate;

		if (recordScreen) {

			// For consistent file naming if recording immediately
			countOffset = 2;

			// Prep the folder
			CalculateFolderName ();
		}
	}

	void LateUpdate () {

		elapsedTime = Time.frameCount;

		if (Input.GetKeyDown (recordButton)) {

			// Update frame count
			countOffset = elapsedTime;

			// Prep the folder
			CalculateFolderName ();

			// Toggle screen recording on or off
			recordScreen = !recordScreen;
		}
			
		if (Application.isEditor && recordScreen) {

			// Go screenshots, go!
			RecordScreenShots ();
//			StartCoroutine (RecordScreenShotsNow());
		}
	}

	void RecordScreenShots () {

		// Create the folder
		System.IO.Directory.CreateDirectory(folder);

		// Set file name
		fileName = Time.frameCount - countOffset + 2;

		// Append filename to folder name (format is '0005 shot.png"')
		string name = string.Format("{0}/{1:D04} shot.png", folder, fileName);

		// Capture the screenshot to the specified file.
		ScreenCapture.CaptureScreenshot(name, magnificaton);


//		StartCoroutine (RecordScreenShots(name));
	}

	IEnumerator RecordScreenShots (string name) {

		//Wait for graphics to render
		yield return new WaitForEndOfFrame();

		RenderTexture rt = new RenderTexture(Screen.width/3, Screen.height/3, 24);
		Texture2D screenShot = new Texture2D(Screen.width/3, Screen.height/3, TextureFormat.RGB24, false);

		//just one camera
		Camera.main.targetTexture = rt;
		Camera.main.Render();

		//Render from all!
//		foreach(Camera cam in Camera.allCameras)
//		{
//			cam.targetTexture = rt;
//			cam.Render();
//			cam.targetTexture = null;
//		}

		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, Screen.width/3, Screen.height/3), 0, 0);
		Camera.main.targetTexture = null;
		RenderTexture.active = null; //Added to avoid errors
		Destroy(rt);

		//Split the process up
		yield return 0;

		byte[] bytes = screenShot.EncodeToPNG();
		File.WriteAllBytes(name, bytes);

	}

	//work with this for better performance
	//from http://answers.unity3d.com/questions/664558/capturescreenshot.html
//	void save () {
//		int width = Screen.width;
//		int height = Screen.height;
//		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
//
//		// Read screen contents into the texture
//		RenderTexture.active = ScreenShot.Instance.currentRT;
//		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//		tex.Apply();
//		byte[] screenshot = tex.EncodeToPNG();
//		RenderTexture.active = null;
//		File.WriteAllBytes(pathToImage, screenshot);
//	}



	void CalculateFolderName() {

		// Name the folders by date and time
		date = System.DateTime.Now.ToString("MMddHHmmss");
		folder = "Screenshots/" + date;
	}
}