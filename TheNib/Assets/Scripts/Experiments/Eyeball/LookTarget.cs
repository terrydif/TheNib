using UnityEngine;
using System.Collections;

public class LookTarget : MonoBehaviour
{
	public GameObject targetSource;
	private float distanceFromTarget = 0.425f;
	private float lerpSpeed = 4;
	private Perlin perlin;

	void Start()
	{
		perlin = new Perlin();
	}

	void Update()
	{
		float perlinSpeed = 0.66f;
		float perlinSize = 0.15f;
		Vector3 perlinOffset = new Vector3(perlin.Noise(Time.time * perlinSpeed), perlin.Noise(Time.time * perlinSpeed + 124.27f), perlin.Noise(Time.time * perlinSpeed + 254.57f)) * perlinSize;
		transform.position = Vector3.Lerp(transform.position, targetSource.transform.position + targetSource.transform.forward * distanceFromTarget + transform.TransformDirection(perlinOffset), Time.deltaTime * lerpSpeed);
		transform.rotation = targetSource.transform.rotation;
	}
}
