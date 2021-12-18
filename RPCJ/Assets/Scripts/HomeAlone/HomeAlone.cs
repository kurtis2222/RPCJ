using UnityEngine;
using System.Collections;

public class HomeAlone : MonoBehaviour
{
	public Transform cam;
	public Renderer sprite;
	public Texture[] sprites;
	float hor, ver;
	Vector3 sprite_dir;
	int anim = 0;
	float mag;
	
	void Awake()
	{
		sprite_dir = sprite.transform.localScale;
		StartCoroutine(DoWalk());
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		mag = rigidbody.velocity.magnitude;
		if(mag < 0.1f)
			sprite.material.mainTexture = sprites[2];
		if(hor != 0)
		{
			if(hor > 0)
				sprite_dir.x = 1;
			else
				sprite_dir.x = -1;
			sprite.transform.localScale = sprite_dir;
			rigidbody.velocity = new Vector3(12f*hor,0f,4f*ver);
		}
		else
		{
			if(ver != 0)
				rigidbody.velocity = new Vector3(0f,0f,10f*ver);
			else
				rigidbody.velocity = Vector3.zero;
		}
		cam.transform.position = new Vector3(transform.position.x,cam.transform.position.y,cam.transform.position.z);
	}
	
	IEnumerator DoWalk()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.2f);
			if(mag > 0.1f)
			{
				anim%=2;
				sprite.material.mainTexture = sprites[anim];
				anim++;
			}
		}
	}
}