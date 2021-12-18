using UnityEngine;
using System.Collections;

public class AirboneHero : MonoBehaviour
{
	float hor, ver;
	public ParticleEmitter[] emitters;
	
	void Start()
	{
		transform.Find("loopsnd").audio.loop = true;
		transform.Find("loopsnd").audio.Play();
	}
	
	void Update()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		rigidbody.AddForce(transform.forward * 2.0f * ver);
		rigidbody.angularVelocity = transform.up * 1.0f * hor;
		foreach(ParticleEmitter p in emitters)
			p.emit = rigidbody.velocity.magnitude > 0.2f || rigidbody.angularVelocity.magnitude > 0.2f;
	}
}