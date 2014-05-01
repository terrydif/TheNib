using UnityEngine;
using System.Collections;

public class Artifact : MonoBehaviour
{
	public GameObject lookCamera;

	public VortexEffect vortexLeft;
	public VortexEffect vortexRight;
	public MotionBlur blurLeft;
	public MotionBlur blurRight;

	private Perlin perlin;

	void Start()
	{
		perlin = new Perlin();
	}

	void Update()
	{
		float angleTo = Vector3.Angle(lookCamera.transform.forward, (transform.position - lookCamera.transform.position).normalized);
		float effectPower = Mathf.Clamp(35 - angleTo, 0, 35);
		effectPower = effectPower * effectPower;

		transform.Rotate(0, effectPower * Time.deltaTime, 0, Space.World);

		vortexLeft.center = new Vector2(0.5f + perlin.Noise(Time.time * (effectPower/200))/4,
		                                0.5f + perlin.Noise(Time.time * (effectPower/200) + 124.24f)/4);
		vortexRight.center = new Vector2(0.5f + perlin.Noise(Time.time * (effectPower/200))/4,
		                                 0.5f + perlin.Noise(Time.time * (effectPower/200) + 124.24f)/2);

		
		vortexLeft.angle = perlin.Noise(Time.time) * effectPower / 2f;
		vortexRight.angle = perlin.Noise(Time.time) * effectPower / 2f;

		blurLeft.blurAmount = Mathf.Lerp(blurLeft.blurAmount, Map.map(effectPower, 0, 35, 0, 0.8f), Time.deltaTime * 5);
		blurRight.blurAmount = Mathf.Lerp(blurRight.blurAmount, Map.map(effectPower, 0, 35, 0, 0.8f), Time.deltaTime * 5);
	}
}
