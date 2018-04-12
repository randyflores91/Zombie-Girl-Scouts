using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieNavigation : MonoBehaviour {


	Animator anim;
	Vector3 currentPos;
	Vector3 targetPoint;
	public Transform target;
	public float speed;
	bool fell;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		currentPos = this.transform.position;
		targetPoint = target.position;
		fell = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentPos = this.transform.position;
		targetPoint = target.position;
		float diff = Vector3.Distance (targetPoint, currentPos);

		if (Time.timeScale != 0) {
			if (fell == false) {
				if (diff < 20.0f && diff > -20.0f) {
					anim.SetBool ("isRunning", true);
					transform.LookAt (targetPoint);
					transform.Translate (0.0f, 0.0f, speed*Time.deltaTime);
				} else {
					transform.Translate (0.0f, 0.0f, 0.0f);
					anim.SetBool ("isRunning", false);
				}
			}
		
			if (currentPos.y < -0.5f) {
				anim.SetTrigger ("fell");
				this.transform.Rotate (Vector3.up * 5);
			}

			if (currentPos.y < -20.0f && fell == false) {
				fell = true;
				GameLogic.zombiesActive -= 1;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Pearl") {
			SceneManager.LoadScene ("Lose");
		}
	}
}
