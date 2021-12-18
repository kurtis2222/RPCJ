using UnityEngine;
using System.Collections;

public class Endg12 : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			col.GetComponent<CharacterMotor>().jumping.enabled = true;
			Destroy(gameObject);
		}
	}
}