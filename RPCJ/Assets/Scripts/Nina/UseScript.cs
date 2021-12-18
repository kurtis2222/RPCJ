using UnityEngine;
using System.Collections;

public class UseScript : MonoBehaviour
{
	public GameObject cart_left, cart_right;
	public Transform proj_point;
	public GUIText respawn;
	public AudioClip death_snd;
	bool isdown = false;
	bool isdead = false;
	RaycastHit hit = new RaycastHit();
	
	void FixedUpdate()
	{
		if(!isdead)
		{
			if(Input.GetButton("Use"))
			{
				if(!isdown)
				{
					if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,2.0f))
					{
						if(hit.collider.name == "use_left")
							cart_left.GetComponent<CartScript>().DoMove();
						else if(hit.collider.name == "use_right")
							cart_right.GetComponent<CartScript>().DoMove();
					}
					isdown = true;
				}
			}
			else isdown = false;
			if(Physics.SphereCast(transform.position,0.4f,-transform.up,out hit,1.5f))
				transform.parent = hit.collider.transform;
			else
				transform.parent = null;
			
			if(transform.position.y < -1.5f)
				DoDeath();
		}
		else
		{
			if(Input.GetButton("Use"))
				Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	public void DoDeath()
	{
		if(!isdead)
		{
			audio.PlayOneShot(death_snd);
			GetComponent<FPSWalkerEnhanced>().can_control = false;
			respawn.enabled = true;
			isdead = true;
		}
	}
}