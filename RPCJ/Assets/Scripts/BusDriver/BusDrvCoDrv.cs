using UnityEngine;
using System.Collections;

public class BusDrvCoDrv : MonoBehaviour
{
	public BusDrvCoHdl.CoSay co_say;
	
	public void DoSay(GameObject sender)
	{
		transform.parent.GetComponent<BusDrvCoHdl>().SendSound(sender,co_say);
	}
}