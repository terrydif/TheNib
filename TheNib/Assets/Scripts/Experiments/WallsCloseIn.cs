using UnityEngine;
using System.Collections;

public class WallsCloseIn : MonoBehaviour
{
	public Vector3 moveSpeed;
	public Texture2D[] crackTexs;
	public Texture2D[] crackNormalTexs;
	public GameObject crackPlane;

	private int currentCrack = 0;
	private float timeUntilCrack = 47;
	private float crackSpeed = 1f;

	public void IncrementCrack()
	{
		if(currentCrack < crackTexs.Length - 1)
		{
			currentCrack++;
			crackPlane.renderer.material.mainTexture = crackTexs[currentCrack];
			crackPlane.renderer.material.SetTexture("_BumpMap", crackNormalTexs[currentCrack]);
			crackSpeed = crackSpeed/2;
			Invoke("IncrementCrack", crackSpeed);
		}
	}

	void Update()
	{
		transform.position += moveSpeed * Time.deltaTime;

		if(crackPlane != null)
		{
			timeUntilCrack -= Time.deltaTime;
			if(timeUntilCrack <= 0 && currentCrack == 0)
			{
				IncrementCrack();
			}
		}
	}
}
