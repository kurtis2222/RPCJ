using UnityEngine;
using System.Collections;

public class DestroyTrigger : MonoBehaviour
{
	public GameObject[] tr_obj;
	
	public void DoTrigger()
	{
		foreach(GameObject g in tr_obj)
			Destroy(g);	
	}
}