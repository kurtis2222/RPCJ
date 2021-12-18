using UnityEngine;
using System.Collections;

public class TeleportTrigger : MonoBehaviour
{
	public Transform point;
	
	public void DoTrigger(GameObject sender)
	{
		sender.transform.position = point.position;
		sender.transform.rotation = point.rotation;
	}
}