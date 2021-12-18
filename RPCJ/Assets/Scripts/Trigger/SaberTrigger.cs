using UnityEngine;
using System.Collections;

public class SaberTrigger : MonoBehaviour
{
	public GameObject[] cop;
	public AudioClip saber_snd;
	
	public void DoTrigger(GameObject sender)
	{
		foreach(GameObject c in cop)
		{
			c.transform.GetChild(0).renderer.enabled = true;
			c.transform.GetChild(1).renderer.enabled = true;
		}
		sender.audio.PlayOneShot(saber_snd);
	}
}