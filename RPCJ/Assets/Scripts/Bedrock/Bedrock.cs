using UnityEngine;
using System.Collections;

public class Bedrock : MonoBehaviour
{
	public Transform cam;
	public Texture[] fred_sprites;
	float hor, ver;
	CapsuleCollider pcol;
	Renderer fred_sprite;
	Vector3 sprite_dir;
	bool walking = false;
	int anim = 0;
	
	void Awake()
	{
		pcol = GetComponent<CapsuleCollider>();
		fred_sprite = transform.Find("fred").renderer;
		sprite_dir = fred_sprite.transform.localScale;
		StartCoroutine(DoWalk());
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		
		if(hor > 0)
			sprite_dir.x = 1;
		else if(hor < 0)
			sprite_dir.x = -1;
		fred_sprite.transform.localScale = sprite_dir;
		
		if(Physics.SphereCast(new Ray(transform.position,-transform.up),0.5f,0.5f))
		{
			if(hor != 0)
			{
				rigidbody.velocity = new Vector3(10f*hor,0f,0f);
				walking = true;
			}
			else
			{
				fred_sprite.material.mainTexture = fred_sprites[0];
				walking = false;
			}
			
			if(ver > 0)
				rigidbody.AddForce(new Vector3(0f,500f,0f));
		}
		else if(hor != 0)
		{
			rigidbody.AddForce(new Vector3(2f*hor,0f,0f));
			fred_sprite.material.mainTexture = fred_sprites[2];
			walking = false;
		}
		else
		{
			fred_sprite.material.mainTexture = fred_sprites[2];
			walking = false;
		}
		
		if(ver >= 0)
			pcol.height = 2.0f;
		else
			pcol.height = 1.0f;
		cam.transform.position = new Vector3(transform.position.x,cam.transform.position.y,cam.transform.position.z);
	}
	
	IEnumerator DoWalk()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.1f);
			if(walking)
			{
				anim%=2;
				fred_sprite.material.mainTexture = fred_sprites[anim];
				anim++;
			}
		}
	}
}