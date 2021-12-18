using UnityEngine;
using System.Collections;

public class NinaGun : MonoBehaviour
{
	public AudioClip hit_snd;
	RaycastHit hit = new RaycastHit();
	bool blockshot = false;
	
	void FixedUpdate()
	{
		if(Physics.Raycast(transform.position,transform.forward,out hit,50.0f))
		{
			if(hit.collider.name == "Player")
			{
				hit.collider.GetComponent<UseScript>().DoDeath();
				Destroy(gameObject);
			}
			else if(hit.collider.name == "nina_cart")
			{
				if(!blockshot)
				{
					hit.collider.audio.PlayOneShot(hit_snd);
					blockshot = true;
					StartCoroutine(ResetGun());
				}
			}
		}
	}
	
	IEnumerator ResetGun()
	{
		yield return new WaitForSeconds(0.2f);
		blockshot = false;
	}
}