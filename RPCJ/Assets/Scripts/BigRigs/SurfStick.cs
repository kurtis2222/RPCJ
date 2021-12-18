using UnityEngine;
using System.Collections;

public class SurfStick : MonoBehaviour
{	
	public Transform helper;
	RaycastHit hit = new RaycastHit();
	Vector3 increase = new Vector3(0.0f,20.0f,0.0f);
	Quaternion tilt;
	
	void FixedUpdate()
	{
		if(Physics.Raycast(transform.position+increase,-transform.up,out hit,40.0f))
		{
			transform.position = hit.point;
			helper.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
			tilt = Quaternion.FromToRotation(Vector3.up, hit.normal);
			helper.rotation = tilt*helper.rotation;
		}
	}
}
