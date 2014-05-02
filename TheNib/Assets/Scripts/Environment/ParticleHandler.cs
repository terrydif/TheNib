using UnityEngine;
using System.Collections;

public class ParticleHandler : MonoBehaviour 
{
	public bool increaseEmission;
	public float targetEmission;
	private float rate;

	void Start() 
	{
		increaseEmission = false;
		rate = 0.5f;
	}

	void Update() 
	{
		if (increaseEmission)
		{
			rate += 0.1f;
			particleSystem.emissionRate = Mathf.MoveTowards(particleSystem.emissionRate, targetEmission, Time.deltaTime * rate);
		}
	}

	public void beginExponentialParticles()
	{
		increaseEmission = true;
	}
}
