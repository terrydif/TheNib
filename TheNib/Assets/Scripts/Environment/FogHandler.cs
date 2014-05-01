using UnityEngine;
using System.Collections;

public class FogHandler : MonoBehaviour {

	public OVRCameraController riftCamera;
	public float speed;
	public float colorSpeed;

	private float density;
	private Color color;

	void Awake () 
	{
		density = RenderSettings.fogDensity;
		color = RenderSettings.fogColor;
	}

	void Update () 
	{
		RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, 0.01f, Time.deltaTime * speed);
		RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, new Color(0.8f,0.1f,1.0f,0.3f), Time.deltaTime * colorSpeed);
		riftCamera.BackgroundColor = Color.Lerp(riftCamera.BackgroundColor, new Color(0.8f,0.1f,1.0f,0.3f), Time.deltaTime * colorSpeed);
	}
	
}
