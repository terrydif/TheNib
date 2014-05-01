using UnityEngine;
using System.Collections;

public class FogHandler : MonoBehaviour {

	public OVRCameraController riftCamera;
	public float speed;
	public float colorSpeed;

	private float _density;
	private Color _color;

	void Awake () 
	{
		_density = 0.01f;
		_color = new Color(0.7f,0.0f,1.0f,0.6f);
	}

	void Update () 
	{
		RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, _density, Time.deltaTime * speed);
		RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, _color, Time.deltaTime * colorSpeed);
		riftCamera.BackgroundColor = Color.Lerp(riftCamera.BackgroundColor, _color, Time.deltaTime * colorSpeed);
	}

	public void setFog (float density, Color color)
	{
		_density = density;
		_color = color;
	}
	
}
