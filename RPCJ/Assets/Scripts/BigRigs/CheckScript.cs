using UnityEngine;
using System.Collections;

public class CheckScript : MonoBehaviour
{
	public int id = 0;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			col.transform.root.GetComponent<BigRigs>().AddCheck(id);
			Destroy(gameObject);
		}
	}
}
