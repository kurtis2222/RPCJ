using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	public Transform target;
	public bool restart = false;
	
	public void DoTrigger(GameObject sender)
	{
		if(!restart)
		{
			sender.GetComponent<CharacterMotor>().enabled = false;
			sender.GetComponent<CharacterController>().enabled = false;
			sender.transform.position -= new Vector3(0,1.5f,0);
			sender.GetComponent<MouseLook>().enabled = false;
			sender.transform.Find("camera").transform.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		}
		if(target != null)
			sender.transform.Find("camera").transform.Find("Main Camera").LookAt(target);
		if(restart == true)
			sender.GetComponent<MainScript>().DoDeath();
	}
}