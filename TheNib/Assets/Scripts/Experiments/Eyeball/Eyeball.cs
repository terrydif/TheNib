using UnityEngine;
using System.Collections;

public class Eyeball : MonoBehaviour
{
	public GameObject lookTarget;

	void Update()
	{
		transform.rotation = Quaternion.LookRotation(lookTarget.transform.position - transform.position, Vector3.up);
	}
}
