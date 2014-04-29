using UnityEngine;
using System.Collections;

public class WallsCloseIn : MonoBehaviour
{
	public Vector3 moveSpeed;

	void Update()
	{
		transform.position += moveSpeed * Time.deltaTime;
	}
}
