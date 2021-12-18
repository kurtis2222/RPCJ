using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
	public GameObject[] tr_obj;
	
	public void DoTrigger()
	{
		foreach(GameObject g in tr_obj)
			GameObject.Instantiate(g,transform.position,new Quaternion(0,0,0,0));
	}
}