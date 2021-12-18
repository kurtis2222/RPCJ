using UnityEngine;
using System.Collections;

public class MortyrItem : MonoBehaviour
{
	public int itemid = 0;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			if(itemid == 0)
			{
				if(col.GetComponent<Mortyr>().GiveHP())
					Destroy(gameObject);
			}
			else
			{
				if(itemid == 1)
					col.GetComponent<Mortyr>().GiveAmmo();
				else if(itemid == 2)
					col.GetComponent<Mortyr>().GiveMG();
				Destroy(gameObject);
			}
		}
	}
}