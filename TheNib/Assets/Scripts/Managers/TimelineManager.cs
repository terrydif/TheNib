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
	public FogHandler fogHandler;
	public ParticleHandler particleHandler;

	private float nextGlitch = 5;
	public GlitchEffect glitchLeft;
	public GlitchEffect glitchRight;

	// Room Two

	public void DeactivateGlitch()
	{
		nextGlitch = Random.Range(3, 8);

		glitchLeft.enabled = false;
		glitchRight.enabled = false;
	}

	void Start() 
	{
		if (currentRoom != 2 && currentRoom != 3)
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
			dais.position = Vector3.MoveTowards(dais.position, newDaisPosition, Time.deltaTime * 0.25f);
		}

		nextGlitch -= Time.deltaTime;
		if(nextGlitch < 0)
		{
			nextGlitch = 100;
			glitchLeft.enabled = true;
			glitchRight.enabled = true;
			Invoke("DeactivateGlitch", 0.25f);
		}
	}

	public void callFade()
	{
		screenFader.FadeIn();
	}

	public void firstLight()
	{
		callFade();
	}

	public void slowFadeFromWhite()
	{
		screenFader.SetFade(new Color(0,0,0,0), 0.1f);
		Invoke("callFade", 1.0f);
	}

	public void fadeToBlack()
	{
		screenFader.SetFade(new Color(0,0,0,1), 0.5f);
		Invoke("callFade", 0f);
	}

	public void tubeFogTransition()
	{
		fogHandler.setFog(0.004f, new Color(0,0,0,1));
	}

	public void beginParticleIncrease()
	{
		particleHandler.beginExponentialParticles();
	}

	public void disableParticles()
	{
		particleHandler.gameObject.SetActive(false);
	}

	public void transitionRooms()
	{
		switch (currentRoom)
		{
		case 1:
			Debug.Log("Switch to Room 2!");
			moving = true;
			newDaisPosition.y -= 11;
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
