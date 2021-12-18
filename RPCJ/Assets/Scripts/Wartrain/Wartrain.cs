using UnityEngine;
using System.Collections;

public class Wartrain : MonoBehaviour
{
	public float trig_pos;
	public AudioClip fred_start, fred_snd, fred_end;
	public AudioClip shoot_snd;
	public Renderer[] gunflash;
	public Light wlight;
	public Transform proj_point;
	public int levelid = 0;
	
	float trainpos = 0.0f;
	bool blockshot = false;
	bool said = false;
	RaycastHit hit;
	int i;
	
	void Start()
	{
		audio.PlayOneShot(fred_start);
	}
	
	void FixedUpdate()
	{
		trainpos = transform.position.x;
		if(!blockshot && Input.GetButton("Fire1"))
		{
			if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,100.0f))
			{
				if(hit.collider.GetComponent<WartrainEnemy>())
					hit.collider.GetComponent<WartrainEnemy>().DoDamage();
				else if(hit.collider.GetComponent<WartrainPlane>())
					hit.collider.GetComponent<WartrainPlane>().DoDamage();
			}
			blockshot = true;
			audio.PlayOneShot(shoot_snd);
			gunflash[0].enabled = gunflash[1].enabled = wlight.enabled = true;
			StartCoroutine(ResetShot());
			StartCoroutine(ResetFlare());
		}
		if(trainpos > -515.0f)
			transform.position += transform.forward * 0.1f;
		else
		{
			enabled = false;
			audio.PlayOneShot(fred_end);
			GetComponent<ImageTrigger>().DoTrigger();
			StartCoroutine(DoWait());
		}
		if(!said && trainpos <= trig_pos)
		{
			said = true;
			audio.PlayOneShot(fred_snd);
		}
	}
	
	IEnumerator ResetFlare()
	{
		yield return new WaitForSeconds(0.1f);
		gunflash[0].enabled = gunflash[1].enabled = wlight.enabled = false;
	}
	
	IEnumerator ResetShot()
	{
		yield return new WaitForSeconds(0.25f);
		blockshot = false;
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(10.0f);
		Application.LoadLevel(levelid);
	}
}