using UnityEngine;
using System.Collections;

public class HPTrigger : MonoBehaviour
{
	public AudioClip sound;
	public int hp = 100;
	public int levelid = -1;
	public float waittime = 5.0f;
	public bool use_tr = true;
	
	public void DoTrigger(GameObject sender, int dam)
	{
		if(hp > 0)
		{
			hp-=dam;
			if(hp <= 0)
			{
				renderer.enabled = false;
				collider.enabled = false;
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
				else
					Destroy(gameObject);
			}
		}
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
}