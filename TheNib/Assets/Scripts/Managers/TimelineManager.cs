using UnityEngine;
using System.Collections;

public class TimelineManager : MonoBehaviour {
	
	private float time;
	private int currentRoom;

	public RoomOne roomOne;

	void Start() 
	{
		currentRoom = 1;
		time = 0.0f;
	}

	void Update() 
	{
		time += Time.deltaTime;
	}

	public void transitionRooms()
	{
		switch (currentRoom)
		{
		case 1:
			Debug.Log("Switch to Room 2!");
			roomOne.exitRoom();
			currentRoom = 2;
			break;

		case 2:
			Debug.Log("Switch to Room 3!");
			currentRoom = 3;
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
