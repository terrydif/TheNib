using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
	public bool fadingIn;

	private float timer;
	private Color previousColor;
	private Color nextColor;

	private Color clearColor;
	private Color whiteColor;

	private float fadeSpeed = 1;
	
	void Start ()
	{
		clearColor = new Color (1, 1, 1, 0);
		whiteColor = new Color (1, 1, 1, 1);

		// Set Initial Colors
		nextColor = clearColor;
		SetColor(whiteColor);
	}
	
	void Update ()
	{
		if (fadingIn) 
		{
			timer = Mathf.Clamp (timer + Time.deltaTime * fadeSpeed, 0, 1);
			renderer.material.color = Color.Lerp (previousColor, nextColor, timer);
		}
	}
	
	public void FadeIn ()
	{
		fadingIn = true;
	}

	public void SetColor(Color color)
	{
		previousColor = nextColor;
		nextColor = color;
	}
}