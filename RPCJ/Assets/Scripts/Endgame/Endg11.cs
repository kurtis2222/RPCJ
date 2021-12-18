using UnityEngine;
using System.Collections;

public class Endg11 : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			RenderSettings.fog = true;
			col.audio.Play();
			col.GetComponent<CharacterMotor>().jumping.enabled = false;
			Destroy(gameObject);
		}
	}
}