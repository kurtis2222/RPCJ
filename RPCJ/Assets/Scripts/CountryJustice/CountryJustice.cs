using UnityEngine;
using System.Collections;

public class CountryJustice : MonoBehaviour {
	
	public float speed = 5.0f;
	public float ang_speed = 2.0f;
	public Transform fan;
	public AudioClip music;
	public AudioClip begin_snd, end_snd;
	public int levelid = 0;
	float hor, ver;
	
	void Awake()
	{
		audio.PlayOneShot(begin_snd);
		StartCoroutine(WaitTimer());
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		fan.RotateAround(fan.right,ver);
		rigidbody.AddForce(transform.forward * speed * ver);
		rigidbody.angularVelocity = transform.up * ang_speed * hor;
		if(transform.position.y < -10)
		{
			enabled = false;
			audio.Stop();
			audio.PlayOneShot(end_snd);
			StartCoroutine(NextLevel());
		}
	}
	
	IEnumerator WaitTimer()
	{
		yield return new WaitForSeconds(14.0f);
		audio.PlayOneShot(music);
		enabled = true;
	}
	
	IEnumerator NextLevel()
	{
		yield return new WaitForSeconds(15.0f);
		Application.LoadLevel(levelid);
	}
}