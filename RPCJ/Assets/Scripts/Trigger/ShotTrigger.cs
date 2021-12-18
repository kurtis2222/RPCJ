using UnityEngine;
using System.Collections;

public class ShotTrigger : MonoBehaviour
{
	public int levelid = -1;
	public AudioClip sound;
	public float waittime = 5.0f;
	public bool use_tr = true;
	public bool dis_col = false;
	bool block_script = false;
	
	public void DoTrigger(GameObject sender)
	{
		if(!block_script)
		{
			if(sound != null)
				sender.audio.PlayOneShot(sound);
			if(use_tr)
			{
				if(GetComponent<SpawnTrigger>())
					GetComponent<SpawnTrigger>().DoTrigger();
				if(GetComponent<DestroyTrigger>())
					GetComponent<DestroyTrigger>().DoTrigger();
				if(GetComponent<AltModelTrigger>())
					GetComponent<AltModelTrigger>().DoTrigger();
				if(GetComponent<FreezeTrigger>())
					GetComponent<FreezeTrigger>().DoTrigger(sender);
			}
			if(levelid != -1)
				StartCoroutine(DoWait());
			block_script = true;
			if(dis_col)
				collider.enabled = false;
		}
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
}