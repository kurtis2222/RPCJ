using UnityEngine;
using System.Collections;

public class DeathBringer : MonoBehaviour
{
	public GameObject sword;
	public Transform proj_point;
	public float waittime = 5.0f;
	public int levelid = 0;
	public AudioClip insane_snd;
	public AudioClip burp_snd;
	public Object particle;
	
	bool endscript = false;
	Transform helper;
	Transform cam;
	bool isdown = false;
	bool burp = false;
	RaycastHit hit = new RaycastHit();
	Quaternion wp_p1, wp_p2, wp_df;
	bool dobob = false;
	bool dir = false;
	Vector3 sway_norm;
	int kills = 0;
	System.Random rnd = new System.Random();
	
	void Awake()
	{
		cam = transform.Find("Main Camera");
		helper = sword.transform.parent;
		wp_df = helper.transform.localRotation;
		wp_p1 = wp_df * Quaternion.Euler(new Vector3(0f,0f,10f));
		wp_p2 = wp_df * Quaternion.Euler(new Vector3(0f,0f,-10f));
		sway_norm = helper.transform.localPosition;
	}
	
	void FixedUpdate()
	{
		if(endscript)
		{
			cam.transform.localRotation = Quaternion.RotateTowards(
				cam.transform.localRotation,
				cam.transform.localRotation * Quaternion.Euler(rnd.Next(-10,11),rnd.Next(-10,11),0),
				1.0f);
		}
		else
		{
			if(Input.GetButton("Fire1"))
			{
				if(!isdown)
				{
					if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,2.0f))
					{
						if(hit.collider.name == "enemy")
						{
							hit.collider.renderer.enabled = false;
							hit.collider.enabled = false;
							GameObject.Instantiate(particle,hit.collider.transform.position,
								hit.collider.transform.rotation);
							kills++;
							if(kills == 10)
							{
								endscript = true;
								GetComponent<FPSWalkerEnhanced>().can_control = false;
								GetComponent<MouseLook>().enabled = false;
								cam.GetComponent<MouseLook>().enabled = false;
								audio.Stop();
								audio.PlayOneShot(insane_snd);
								StartCoroutine(DoChange());
								StartCoroutine(SwayLoop());
							}
						}
					}
					sword.animation.Play("db_swiss");
					StartCoroutine(ResetSword());
					isdown = true;
				}
			}
			if(Input.GetButton("AltFire"))
			{
				if(!burp)
				{
					audio.PlayOneShot(burp_snd);
					StartCoroutine(ResetBurp());
					burp = true;
				}
			}
			if(Physics.Raycast(transform.position,-transform.up,out hit,1.2f))
				if(hit.collider.name == "db_ice")
					StartCoroutine(CrashIce(hit.collider.gameObject));
			if(transform.position.y < -2.0f)
				Application.LoadLevel(Application.loadedLevel);
			if(GetComponent<CharacterController>().velocity.magnitude > 0.2f)
			{
				helper.localRotation = Quaternion.RotateTowards(
					helper.localRotation,
					dir ? wp_p2 : wp_p1,
					1.0f);
				if(helper.localRotation == wp_p1)
					dir = true;
				else if(helper.localRotation == wp_p2)
					dir = false;
				dobob = true;
			}
			else if(dobob)
			{
				helper.localRotation = Quaternion.RotateTowards(helper.localRotation,wp_df,4.0f);
				if(helper.localRotation == wp_df)
					dobob = false;
			}
			helper.localPosition = Vector3.Lerp(
				helper.localPosition,sway_norm +
				new Vector3(Input.GetAxis("Mouse X") * 0.1f, Input.GetAxis("Mouse Y") * 0.1f, 0f),
				Time.fixedDeltaTime*2.0f);
		}
	}
	
	IEnumerator ResetSword()
	{
		yield return new WaitForSeconds(0.5f);
		sword.animation.Play("db_idle");
		isdown = false;
	}
	
	IEnumerator ResetBurp()
	{
		yield return new WaitForSeconds(1.0f);
		burp = false;
	}
	
	IEnumerator CrashIce(GameObject ice_obj)
	{
		yield return new WaitForSeconds(1.0f);
		Destroy(ice_obj);
	}
	
	IEnumerator DoChange()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
	
	IEnumerator SwayLoop()
	{
		while(true)
		{
			yield return new WaitForSeconds(1.0f);
			sword.animation.Play("db_swiss");
		}
	}
}