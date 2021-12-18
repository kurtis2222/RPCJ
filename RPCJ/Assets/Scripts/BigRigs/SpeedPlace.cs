using UnityEngine;
using System.Collections;

public class SpeedPlace : MonoBehaviour
{
	void Awake()
	{
		transform.position = new Vector3(0.6f*Screen.width/Screen.height,transform.position.y,transform.position.z);
	}
}