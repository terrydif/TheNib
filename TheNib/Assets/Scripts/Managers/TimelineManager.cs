﻿using UnityEngine;
using System.Collections;

public class TimelineManager : MonoBehaviour {
	
	private float time;
	private bool moving;
	public static int currentRoom;

	public ScreenFader screenFader;

	// Room One
	public Transform dais;
	public Vector3 newDaisPosition;

	// Room Two

	void Start() 
	{
		if (currentRoom == null)
		{
			currentRoom = 1;
			newDaisPosition = dais.position;
		}

		moving = false;
		time = 0.0f;
	}

	void Update() 
	{
		time += Time.deltaTime;

		if (moving)
		{
			dais.position = Vector3.Lerp(dais.position, newDaisPosition, Time.deltaTime * 0.3f);
		}
	}

	public void firstLight()
	{
		screenFader.FadeIn();
	}

	public void transitionRooms()
	{
		switch (currentRoom)
		{
		case 1:
			Debug.Log("Switch to Room 2!");
			moving = true;
			newDaisPosition.y -= 240;
			currentRoom = 2;
			break;

		case 2:
			Debug.Log("Switch to Room 3!");
			currentRoom = 3;
			Application.LoadLevel("JonesRoom");
			break;

		case 3:
			Debug.Log("Kill the Player!");
			currentRoom = 0;
			break;

		default:
			Debug.Log("Don't Do Anything!");
			break;
		}
	}
}
