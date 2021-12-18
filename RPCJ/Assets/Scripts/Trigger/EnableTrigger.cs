using UnityEngine;
using System.Collections;

public class EnableTrigger : MonoBehaviour
{
	public GameObject[] tr_obj;
	public bool[] tr_enable;
	
	public void DoTrigger()
	{
		for(int i = 0; i < tr_obj.Length; i++)
			tr_obj[i].SetActiveRecursively(tr_enable[i]);
	}
}
