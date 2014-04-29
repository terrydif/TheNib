using UnityEngine;
using System.Collections;

public class ArmIK : MonoBehaviour
{
	public GameObject centerSpinner;
	public GameObject targetObject;
	public GameObject[] joints;
	private float jointLength;
	private float maxDistance;
	private Vector3 targetPosition;
	private Quaternion targetCenterRotation;

	void Start()
	{
		jointLength = Vector3.Distance(transform.position, joints[1].transform.position);
		maxDistance = jointLength * joints.Length;
	}

	void Update()
	{
		targetPosition = targetObject.transform.position;

		float distanceToTarget = Mathf.Clamp(Vector3.Distance(transform.position, targetPosition), 0, maxDistance);
		float jointAngle = Mathf.Acos((distanceToTarget / joints.Length) / jointLength) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

		joints[0].transform.localRotation = Quaternion.Euler(-jointAngle * 1, 0, 0);

		for(int j = 1; j < joints.Length; j++)
		{
			joints[j].transform.localRotation = Quaternion.Euler(jointAngle * 2, 0, 0);
		}

		if(maxDistance - distanceToTarget < 0.3f)
		{
			targetCenterRotation = Quaternion.Euler(0, targetObject.transform.eulerAngles.y, 0);
		}

		centerSpinner.transform.rotation = Quaternion.Slerp(centerSpinner.transform.rotation, targetCenterRotation, Time.deltaTime * 8);
	}
}
