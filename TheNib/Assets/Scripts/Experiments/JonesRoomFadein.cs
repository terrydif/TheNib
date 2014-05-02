using UnityEngine;
using System.Collections;

public class JonesRoomFadein : MonoBehaviour
{
	public GlitchEffect glitchLeft;
	public GlitchEffect glitchRight;

	private float fadeTimer = -1;

	public void Disable()
	{
		glitchLeft.intensity = 0;
		glitchRight.intensity = 0;

		glitchLeft.enabled = false;
		glitchRight.enabled = false;

		this.enabled = false;
	}

	void Update()
	{
		fadeTimer += Time.deltaTime * 2;
		fadeTimer = Mathf.Clamp(fadeTimer, -1, 1);

		renderer.material.color = Color.Lerp(Color.black, new Color(0, 0, 0, 0), fadeTimer);

		if(fadeTimer >= 1)
		{
			Invoke("Disable", 0.5f);
		}
	}
}
