using UnityEngine;
using System.Collections;

public class EyeBlink : MonoBehaviour
{
	public float openRotation;
	public float closedRotation;

	private float targetRotation;
	
	private float blinkTimer;

	void Update()
	{
		targetRotation = Mathf.MoveTowardsAngle(targetRotation, openRotation, Time.deltaTime * 120);

		blinkTimer -= Time.deltaTime;
		if(blinkTimer <= 0)
		{
			Random.seed = (int)(Time.time * 1000);
			blinkTimer = Random.Range(0.5f, 5f);
			targetRotation = closedRotation;
		}

		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(targetRotation, 0, 0), Time.deltaTime * 16);
	}
}
