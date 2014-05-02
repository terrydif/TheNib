using UnityEngine;
using System.Collections;

public class BSODHandler : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		Invoke("turnOn", 2.5f);
	}

	void turnOn()
	{
		renderer.enabled = true;
	}
}
