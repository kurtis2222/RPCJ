using UnityEngine;
using System.Collections;

public class BossProj : MonoBehaviour
{
	public AudioClip impact_snd;
	RaycastHit hit = new RaycastHit();
	
	void Start()
	{
		rigidbody.velocity = transform.forward * 20.0f;
		StartCoroutine(AutoDestroy());
	}
	
	void FixedUpdate()
	{
		if(Physics.SphereCast(transform.position,0.2f,transform.forward,out hit,0.2f))
		{
			if(hit.collider.name == "Player")
				hit.collider.GetComponent<MainScript>().DoDeath();
			audio.PlayOneShot(impact_snd);
			enabled = false;
			renderer.enabled = false;
			StartCoroutine(DoWait());
		}
	}
	
	IEnumerator DoWait()	
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
	
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(5.0f);
		if(enabled)
			Destroy(gameObject);
	}
}