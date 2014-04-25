using UnityEngine;
using System.Collections;

public class GravityMutator : MonoBehaviour {
	
	public Vector3 currentGravity;
	public float transitionSpeed;

	private Vector3 originalGravity;
	
	void Awake() 
	{
		originalGravity = Physics.gravity;
		currentGravity = originalGravity;
	}

	public void updateGravity(Vector3 newGravity)
	{
		Physics.gravity = originalGravity;
		currentGravity = originalGravity;
	}

	public void updateGravity(Vector3 newGravity, float speed)
	{
		Physics.gravity = newGravity;
		currentGravity = newGravity;
		transitionSpeed = speed;
	}

	public void resetGravity()
	{
		updateGravity(originalGravity);
	}

	void Update() 
	{
		Physics.gravity = Vector3.Lerp(Physics.gravity, currentGravity, Time.deltaTime * transitionSpeed);
	}
}