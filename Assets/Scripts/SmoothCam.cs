using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
	public GameObject target;
	private Vector3 targetPos;
	public float moveSpd;
	
	void Update () 
	{
		targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
		Vector3 velocity = targetPos - transform.position;
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 100f, moveSpd * Time.deltaTime);	
	}
}
