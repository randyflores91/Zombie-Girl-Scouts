using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public static int zombiesActive;
	public GameObject zombie1;
	public GameObject zombie2;
	public GameObject zombie3;
	public GameObject pauseMenu;
	bool pause;
	float time;

	// Use this for initialization
	void Start () {
		zombiesActive = 3;
		pause = false;
		time = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > 3.0f) {
			zombie1.SetActive (true);
		}
		if (time > 8.0f) {
			zombie2.SetActive (true);
		}
		if (time > 13.0f) {
			zombie3.SetActive (true);
		}
			
		if (zombiesActive == 0) {
			SceneManager.LoadScene ("Win");
		}


		if (pause == false) {
			if (Input.GetKeyDown(KeyCode.P)) {
				pauseMenu.SetActive (true);
				pause = true;
				Time.timeScale = 0;
			}
		}
		else {
			if (Input.GetKeyDown (KeyCode.P)) {
				pauseMenu.SetActive (false);
				pause = false;
				Time.timeScale = 1;
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				Time.timeScale = 1;
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				Application.Quit ();
			}
		}
	}
}
