using UnityEngine;
using System.Collections;

public class RoomOne : MonoBehaviour {

	public Transform dais;
	public Vector3 newPosition;

	/* Assign variables for objects to be manipulated
	 * Cause Random Light Changes and Camera Effects
	 * Write method for scene transition; called from TimelineManager
	 * */
	
	void Start()
	{
		newPosition = dais.position;
	}

	void Update()
	{
		dais.position = Vector3.Lerp(dais.position, newPosition, Time.deltaTime * 0.3f);
	}

	public void exitRoom()
	{
		newPosition.y -= 240;
	}
}
