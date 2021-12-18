using UnityEngine;
using System.Collections;

public class MortyrEnemy : MonoBehaviour
{
	public Transform player;
	public AudioClip fire_snd;
	public AudioClip death_snd;
	public Object ammo_obj;
	Transform proj_point;
	NavMeshAgent nav;
	RaycastHit hit = new RaycastHit();
	Animation soldier;
	bool washit = false;
	bool blockshot = false;
	
	void Awake()
	{
		proj_point = transform.Find("proj_point");
		nav = GetComponent<NavMeshAgent>();
		soldier = transform.Find("mortyr_soldier").animation;
	}
	
	void FixedUpdate()
	{
		nav.destination = player.position;
		transform.LookAt(player);
		proj_point.LookAt(player);
		nav.speed = Vector3.Distance(transform.position,player.position) > 5.0f ? 4.0f : 0.0f;
		if(!blockshot && nav.speed == 0.0f && soldier.animation.name != "sol_stand")
			soldier.animation.Play("sol_stand");
		else if(!blockshot && nav.speed == 4.0f && soldier.animation.name != "sol_run")
			soldier.animation.Play("sol_run");
		
		if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,50.0f))
		{
			if(hit.collider.name == "Player" && !blockshot)
			{
				nav.speed = 0f;
				soldier.animation.Play("sol_fire");
				light.enabled = true;
				audio.PlayOneShot(fire_snd);
				hit.collider.GetComponent<Mortyr>().DoDamage();
				blockshot = true;
				StartCoroutine(ResetLight());
				StartCoroutine(ResetShot());
			}
		}
	}
	
	public void DoDamage()
	{
		if(washit)
		{
			audio.PlayOneShot(death_snd);
			Destroy(nav);
			Destroy(collider);
			transform.position -= new Vector3(0f,1f,0f);
			soldier.animation.Play("sol_death");
			Destroy(light);
			GameObject.Instantiate(ammo_obj,transform.position + new Vector3(0,0.2f,0),Quaternion.Euler(-90f,0f,0f));
			Destroy(this);
		}
		else washit = true;
	}
	
	IEnumerator ResetShot()
	{
		yield return new WaitForSeconds(2.0f);
		blockshot = false;
	}
	
	IEnumerator ResetLight()
	{
		yield return new WaitForSeconds(0.2f);
		light.enabled = false;
	}
}