using UnityEngine;
using System.Collections;

public class MoonWalker : MonoBehaviour
{
	public float speed = 4.0f;
	public Transform jackson;
	public AudioClip fred_snd;
	Renderer jackson_sprite;
	public Texture jackson_stand;
	public Texture[] jackson_sprites;
	Vector3 dir = Vector3.zero;
	float hor, ver;
	float head = 0f;
	float wspeed = 0.1f;
	int anim = 0;
	bool walking;
	
	void Awake()
	{
		audio.PlayOneShot(fred_snd);
		jackson_sprite = jackson.renderer;
		StartCoroutine(DoWalk());
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxisRaw("Horizontal");	
		ver = Input.GetAxisRaw("Vertical");
		walking = rigidbody.velocity.magnitude > 0.1f;
		
		if(hor > 0 && ver > 0)
			head = -135f;
		else if(hor < 0 && ver > 0)
			head = 135f;
		else if(hor > 0 && ver < 0)
			head = -45f;
		else if(hor < 0 && ver < 0)
			head = 45f;
		else if(hor > 0)
			head = -90f;
		else if(hor < 0)
			head = 90f;
		else if(ver > 0)
			head = 180f;
		else if(ver < 0)
			head = 0f;
		
		if(!walking)
			jackson_sprite.material.mainTexture = jackson_stand;
		
		jackson.rotation = Quaternion.Euler(-90f,head,0f);
		dir.x = hor*speed;
		dir.z = ver*speed;
		if(Input.GetButton("Fire1"))
		{
			dir *= 2;
			wspeed = 0.075f;
		}
		else wspeed = 0.1f;
		rigidbody.velocity = dir;
	}
	
	IEnumerator DoWalk()
	{
		while(true)
		{
			yield return new WaitForSeconds(wspeed);
			if(walking)
			{
				anim%=4;
				jackson_sprite.material.mainTexture = jackson_sprites[anim];
				anim++;
			}
		}
	}
	
	public void DoEnd()
	{
		walking = false;
		rigidbody.velocity = Vector3.zero;
		jackson_sprite.material.mainTexture = jackson_stand;
		Destroy(this);
	}
}