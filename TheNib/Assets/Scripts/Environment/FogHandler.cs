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
		_density = 0.2f;
		_color = new Color(0.7f,0.0f,1.0f,0.6f);
	}

	void Update () 
	{
		RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, _density, Time.deltaTime * speed);
		RenderSettings.fogColor = ColorMoveTowards(RenderSettings.fogColor, _color, Time.deltaTime * colorSpeed);
		riftCamera.BackgroundColor = ColorMoveTowards(riftCamera.BackgroundColor, _color, Time.deltaTime * colorSpeed);
	}

	public void setFog (float density, Color color)
	{
		_density = density;
		_color = color;
	}

	public Color ColorMoveTowards(Color currentColor, Color targetColor, float maxDelta)
	{
		return (Color)Vector4.MoveTowards(currentColor, targetColor, maxDelta);
	}
}
