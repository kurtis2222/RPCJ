using UnityEngine;
using System.Collections;

public class AmericaSec : MonoBehaviour
{
	public Transform proj_point;
	public Transform weapon;
	public AudioClip gunfire;
	public Transform reset;
	Renderer gunflash;
	Transform helper;
	bool[] isdown = new bool[2];
	RaycastHit hit = new RaycastHit();
	Vector3 wp_norm, wp_fire;
	Vector3 wp_p0, wp_p1, wp_p2;
	bool dir = false;
	bool dobob = false;
	bool block = true;
	
	void Awake()
	{
		StartCoroutine(DelayStart());
		helper = weapon.parent;
		wp_norm = weapon.transform.localPosition;
		wp_fire = wp_norm - new Vector3(0,0,0.1f);
		gunflash = weapon.transform.Find("gunflash").renderer;
		wp_p0 = helper.transform.localPosition;
		wp_p1 = wp_p0 - new Vector3(0,0.05f,0);
		wp_p2 = wp_p0 + new Vector3(0,0.05f,0);
	}
	
	void FixedUpdate()
	{
		if(!block)
		{
			if(Input.GetButton("Fire1"))
			{
				if(!isdown[0])
				{
					isdown[0] = true;
					gunflash.enabled = true;
					light.enabled = true;
					audio.PlayOneShot(gunfire);
					weapon.transform.localPosition = wp_fire;
					StartCoroutine(ResetWeapon());
				}
			}
			if(Input.GetButton("Use"))
			{
				if(!isdown[1])
				{
					if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,2.0f))
					{
						if(hit.collider.name == "use_tr")
							hit.collider.GetComponent<UseTrigger>().DoTrigger(gameObject);		
					}
					isdown[1] = true;
				}
			}
			else
				isdown[1] = false;
			
			if(GetComponent<CharacterController>().velocity.magnitude > 0.2f)
			{
				helper.transform.localPosition = Vector3.MoveTowards(
					helper.transform.localPosition,
					dir ? wp_p2 : wp_p1,
					0.005f);
				if(helper.localPosition == wp_p1)
					dir = true;
				else if(helper.localPosition == wp_p2)
					dir = false;
				dobob = true;
			}
			else if(dobob)
			{
				helper.localPosition = Vector3.MoveTowards(weapon.localPosition,wp_p0,4.0f);
				if(helper.localPosition == wp_p0)
					dobob = false;
			}
		}
		
		helper.localPosition = Vector3.Lerp(
				helper.localPosition, wp_p0 +
				new Vector3(Input.GetAxis("Mouse X") * 0.1f, Input.GetAxis("Mouse Y") * 0.1f, 0f),
				Time.fixedDeltaTime*2.0f);
		
		if(transform.position.y < 20.0f)
		{
			transform.position = reset.position;
			transform.rotation = reset.rotation;
		}
	}
	
	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds(40.0f);
		audio.Play();
		block = false;
	}
	
	IEnumerator ResetWeapon()
	{
		yield return new WaitForSeconds(0.15f);
		gunflash.enabled = false;
		light.enabled = false;
		weapon.transform.localPosition = wp_norm;
		isdown[0] = false;
	}
}