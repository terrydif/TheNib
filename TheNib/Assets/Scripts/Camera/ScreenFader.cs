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
	private Color blackColor;

	private float fadeSpeed = 1;

	void Awake ()
	{
		clearColor = new Color (1, 1, 1, 0);
		whiteColor = new Color (1, 1, 1, 1);
		blackColor = new Color (0, 0, 0, 1);
		
		// Set Initial Colors
		nextColor = blackColor;
		SetFade(whiteColor, 1.0f);
	}
	
	void Update ()
	{
		if (fadingIn) 
		{
			timer = Mathf.Clamp (timer + Time.deltaTime * fadeSpeed, 0, 1);
			renderer.material.color = Color.Lerp (previousColor, nextColor, timer);

			if(renderer.material.color == nextColor)
			{
				fadingIn = false;
				timer = 0;
			}
		}
	}
	
	public void FadeIn()
	{
		fadingIn = true;
	}

	public void SetFade(Color color, float speed)
	{
		previousColor = nextColor;
		nextColor = color;
		fadeSpeed = speed;
	}
}