using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PearlNavigation : MonoBehaviour {

	Animator anim;
	public NavMeshAgent agent;
	Vector3 currentPos;
	Vector3 newPoint;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		currentPos = this.transform.position;
		newPoint = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		currentPos = this.transform.position;
		float diff = Vector3.Distance (newPoint, currentPos);
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				newPoint = hit.point;
				agent.destination = hit.point;
			}
		}
		if (diff < 0.5f && diff > -0.5f)
			anim.SetBool ("isRunning", false);
		else
			anim.SetBool ("isRunning", true);
	}
}
