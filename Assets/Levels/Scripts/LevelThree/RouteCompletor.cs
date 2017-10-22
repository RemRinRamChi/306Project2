﻿using UnityEngine;
using System.Collections;

public class RouteCompletor : MonoBehaviour {


	public int RouteNumber;

	private bool interacting;
	private bool finished;
	private GameObject LevelThreeController;
	
	// Use this for initialization
	void Start () {
		LevelThreeController = GameObject.FindWithTag("LevelThreeController");
	}
	
	// Update is called once per frame
	void Update () {
		if (interacting)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) && !finished)
			{
				LevelThreeController.GetComponent<LevelThreeController>().CompleteRoute(RouteNumber);
				finished = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			interacting = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			interacting = false;
		}
	}
	
	private void OnGUI()
	{
		if (interacting)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"Looks like this ancient cannon is still working... (Mouse LB)");
		}
	}
}
