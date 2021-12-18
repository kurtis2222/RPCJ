using UnityEngine;
using System.Collections;

public class HeliGun : MonoBehaviour
{
	public Transform player;
	public ParticleEmitter gunfire;
	public AudioClip gun_snd;
	public Transform heli_obj;
	public Transform heli;
	bool engage = false;
	RaycastHit hit = new RaycastHit();
	
	void Start()
	{
		StartCoroutine(ThinkTimer());
		StartCoroutine(ShotTimer());
	}
	
	void FixedUpdate()
	{
		transform.LookAt(player);
		heli.LookAt(new Vector3(player.position.x,heli.position.y,player.position.z));
	}
	
	IEnumerator ThinkTimer()
	{
		while(true)
		{
			yield return new WaitForSeconds(2.0f);
			if(Physics.Raycast(transform.position,transform.forward,out hit,100.0f))
				engage = hit.collider.transform == player;
			else
				engage = false;
		}
	}
	
	IEnumerator ShotTimer()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.05f);
			if(engage)
			{
				player.GetComponent<MainScript>().DoDamage(2);
				gunfire.emit = true;
				heli_obj.audio.PlayOneShot(gun_snd);
				if(Physics.Raycast(transform.position,transform.forward,out hit,100.0f))
					engage = hit.collider.transform == player;
				else
					engage = false;
			}
			else if(gunfire.emit)
				gunfire.emit = false;
		}
	}
}
