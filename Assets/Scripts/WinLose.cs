using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Game");
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
	}
}
