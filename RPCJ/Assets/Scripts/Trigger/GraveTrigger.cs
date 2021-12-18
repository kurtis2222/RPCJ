using UnityEngine;
using System.Collections;

public class GraveTrigger : MonoBehaviour
{
	public AudioClip fred;
	public AudioClip fred2;
	public AudioClip bus_snd;
	public AudioClip bus_snd2;
	public Transform cam;
	public Transform bus;
	public Transform bus_targ;
	public int levelid = 0;
	Quaternion zero = Quaternion.Euler(15f,0f,0f);
	bool look = false;
	
	public void DoTrigger(GameObject sender)
	{
		Destroy(sender);
		cam.gameObject.SetActiveRecursively(true);
		cam.audio.PlayOneShot(fred);
		StartCoroutine(Wait());
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(4.0f);
		cam.audio.PlayOneShot(bus_snd);
		StartCoroutine(Wait2());
	}
	
	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(2.0f);
		enabled = true;
		cam.audio.PlayOneShot(fred2);
		StartCoroutine(Wait3());
	}
	
	IEnumerator Wait3()	
	{
		yield return new WaitForSeconds(2.0f);
		cam.audio.PlayOneShot(bus_snd2);
		look = true;
	}
	
	void FixedUpdate()
	{
		cam.rotation = Quaternion.RotateTowards(cam.rotation,zero,5.0f);
		if(look)
		{
			bus.position = Vector3.MoveTowards(bus.position,bus_targ.position,0.2f);
			if(Vector3.Distance(bus.position,bus_targ.position) < 0.1f)
			{
				Application.LoadLevel(levelid);
				enabled = false;
			}
		}
	}
}