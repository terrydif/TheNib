using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
	public static float map(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
