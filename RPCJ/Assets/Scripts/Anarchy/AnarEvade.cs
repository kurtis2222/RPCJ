using UnityEngine;
using System.Collections;

public class AnarEvade : MonoBehaviour
{
	public AudioClip sound;
	public Transform trig_obj;
	bool block_script = false;
	
	void OnTriggerEnter(Collider col)
	{
		if(!block_script)
		{
			col.audio.PlayOneShot(sound);
			StartCoroutine(DestroyTimer());
			enabled = true;
			block_script = true;
		}
	}
	
	void FixedUpdate()
	{
		trig_obj.position += trig_obj.forward * 0.05f;
	}
	
	IEnumerator DestroyTimer()
	{
		yield return new WaitForSeconds(15.0f);
		Destroy(trig_obj.gameObject);
		Destroy(gameObject);
	}
}