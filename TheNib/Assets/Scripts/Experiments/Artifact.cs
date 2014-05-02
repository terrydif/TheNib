using UnityEngine;
using System.Collections;

public class Artifact : MonoBehaviour
{
	public GameObject lookCamera;

	public GlitchEffect glitchLeft;
	public GlitchEffect glitchRight;
	public VortexEffect vortexLeft;
	public VortexEffect vortexRight;
	public MotionBlur blurLeft;
	public MotionBlur blurRight;

	public AudioSource artifactNoise;
	public AudioSource lookAwayNoise;

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

		if(effectPower > 17.5f)
		{
			//glitchLeft.enabled = true;
			//glitchRight.enabled = true;

			if(glitchLeft.intensity == 0)
			{
				//glitchLeft.intensity = 0.15f;
				//glitchRight.intensity = 0.15f;
			}
		}
		
		vortexLeft.angle = perlin.Noise(Time.time) * effectPower / 2f;
		vortexRight.angle = perlin.Noise(Time.time) * effectPower / 2f;

		blurLeft.blurAmount = Mathf.Lerp(blurLeft.blurAmount, Map.map(effectPower, 0, 35, 0, 0.8f), Time.deltaTime * 5);
		blurRight.blurAmount = Mathf.Lerp(blurRight.blurAmount, Map.map(effectPower, 0, 35, 0, 0.8f), Time.deltaTime * 5);

		artifactNoise.volume = Mathf.Clamp(Map.map(angleTo, 30, 0, 0, 0.6f), 0, 0.6f);
		artifactNoise.pitch = Mathf.Lerp(artifactNoise.pitch, Mathf.Clamp(Map.map(angleTo, 30, 0, 0.4f, 0.7f), 0.4f, 0.7f), Time.deltaTime * 0.4f) + perlin.Noise(Time.time)/50f;
	
		//lookAwayNoise.volume = Mathf.Lerp(lookAwayNoise.volume, Mathf.Clamp(Map.map(angleTo, 50, 90, 0, 1), 0, 1), Time.deltaTime * 4f);
	}
}
