using UnityEngine;
using System.Collections;

public class WallsCloseIn : MonoBehaviour
{
	public Vector3 moveSpeed;
	public Texture2D[] crackTexs;
	public Texture2D[] crackNormalTexs;
	public GameObject crackPlane;
	public GlitchEffect glitchLeft;
	public GlitchEffect glitchRight;
	public AudioSource glitchSound;
	
	private int currentCrack = 0;
	private float timeUntilCrack = 47f;
	private float crackSpeed = 1f;

	public void IncrementCrack()
	{
		glitchLeft.intensity += 0.333f;
		glitchRight.intensity += 0.333f;

		if(currentCrack < crackTexs.Length - 1)
		{
			currentCrack++;
			crackPlane.renderer.material.mainTexture = crackTexs[currentCrack];
			crackPlane.renderer.material.SetTexture("_BumpMap", crackNormalTexs[currentCrack]);
			crackSpeed = crackSpeed/2;
			Invoke("IncrementCrack", crackSpeed);
		}
	}

	void GoToBlack()
	{
		Application.LoadLevel("Black");
	}

	void Update()
	{
		transform.position += moveSpeed * Time.deltaTime;

		if(crackPlane != null)
		{
			timeUntilCrack -= Time.deltaTime;
			if(timeUntilCrack <= 0 && currentCrack == 0)
			{
				glitchLeft.intensity = 0;
				glitchRight.intensity = 0;
				IncrementCrack();

				Invoke("GoToBlack", 5);
				glitchSound.Play();
			}

			if(currentCrack > 0)
			{
				glitchLeft.enabled = true;
				glitchRight.enabled = true;
			}
		}
	}
}
