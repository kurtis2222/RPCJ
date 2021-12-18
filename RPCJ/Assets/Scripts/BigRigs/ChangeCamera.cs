using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour
{
	public Camera cam;
	public GameObject control;
	public GameObject info;
	
	void Start()
	{
		control.rigidbody.velocity = control.transform.forward*2.0f;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			col.camera.enabled = false;
			cam.enabled = true;
			info.active = true;
			control.GetComponent<BigRigs>().enabled = true;
		}
	}
}