using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
	public Transform proj_point;
	RaycastHit hit = new RaycastHit();
	bool[] isdown = new bool[2];
	
	public AudioClip death_snd;
	public AudioClip[] step_snd;
	Vector3 oldpos;
	CharacterMotor fpscontrol;
	int stepnumb = 0;
	public GameObject player;
	
	//Scope
	bool iszooming = false;
	MouseLook[] ms;
	Camera[] cams;
	GUITexture hud;
	GameObject scope;
	
	//Gun Flash Light
	public Light weap_light;
	
	//Mouse
	float msens = 5.0f;
	float ssens = 1.0f;
	
	//Limit hud
	GameObject hud_items;
	HudStamina hud_st;
	public bool hud_stat = true;
	
	//Access weapon script if true
	public bool weaponactive = true;
	
	//HP System
	HudAmmo hud_hp;
	HudHit hud_hit;
	int hp = 100;
	bool isdead = false;
	
	void Awake()
	{
		hud_items = (GameObject)Instantiate(Resources.Load("hud_items"));
		hud_items.transform.Find("Hud").gameObject.SetActiveRecursively(hud_stat);
		if(!weaponactive)
		{
			Destroy(player.GetComponent<WeaponScript>());
			hud_items.transform.Find("HudCross").gameObject.SetActiveRecursively(false);
			hud_items.transform.Find("HudWeapon").gameObject.SetActiveRecursively(false);
		}
	}
	
	void Start()
	{
		msens = OptionLoader.msens;
		ssens = OptionLoader.ssens;
		oldpos = transform.position;
		fpscontrol = GetComponent<CharacterMotor>();
		StartCoroutine(StepTimer());
		cams = GetComponentsInChildren<Camera>();
		hud = hud_items.transform.Find("HudCross").guiTexture;
		scope = hud_items.transform.Find("HudSniper").gameObject;
		hud_hp = hud_items.transform.Find("Hud").transform.Find("HudHP").GetComponent<HudAmmo>();
		hud_st = hud_items.transform.Find("Hud").transform.Find("HudST").GetComponent<HudStamina>();
		hud_hit = hud_items.transform.Find("HudHit").GetComponent<HudHit>();
		hud_st.GetInfo(gameObject);
		scope.SetActiveRecursively(false);
		MouseLook.sensitivityX = Mathf.Abs(msens);
		MouseLook.sensitivityY = msens;
	}
	
	void FixedUpdate()
	{
		if(Input.GetButton("Use"))
		{
			if(!isdown[0])
			{
				if(!isdead)
				{
					if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,2.0f))
					{
						if(hit.collider.name == "use_tr")
							hit.collider.GetComponent<UseTrigger>().DoTrigger(gameObject);
						else if(hit.collider.name == "spec_tr")
							hit.collider.GetComponent<GraveTrigger>().DoTrigger(gameObject);
							
					}
				}
				else Application.LoadLevel(Application.loadedLevel);
				isdown[0] = true;
			}
		}
		else 
			isdown[0] = false;
		
		if(Input.GetButton("AltFire") && weaponactive)
		{
			if(!isdown[1])
			{
				switch(player.GetComponent<WeaponScript>().weaponid)
				{
					case 4:
					case 8:
					{
						weap_light.enabled = !weap_light.enabled;
						break;
					}
					case 6:
					{
						iszooming = !iszooming;
						if(iszooming)
						{
							hud.enabled = false;
							scope.SetActiveRecursively(true);
							foreach(Camera c in cams)
								c.fov = 5.0f;
							MouseLook.sensitivityX = Mathf.Abs(ssens);
							MouseLook.sensitivityY = ssens;
						}
						else
						{
							hud.enabled = true;
							scope.SetActiveRecursively(false);
							foreach(Camera c in cams)
								c.fov = 60.0f;
							MouseLook.sensitivityX = Mathf.Abs(msens);
							MouseLook.sensitivityY = msens;
						}
						break;
					}
				}
				isdown[1] = true;
			}
		}
		else isdown[1] = false;
	}
	
	IEnumerator StepTimer()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.4f);
			if(Vector3.Distance(transform.position,oldpos) > 3.0f && fpscontrol.grounded)
			{
				if(fpscontrol.stamina > 0) fpscontrol.stamina-=10;
				if(fpscontrol.stamina < 0) fpscontrol.stamina=0;
				hud_st.ChangeValue(fpscontrol.stamina);
				MakeStep();
			}
			else
			{
				if(fpscontrol.stamina < 1000) fpscontrol.stamina+=20;
				if(fpscontrol.stamina > 1000) fpscontrol.stamina=1000;
				hud_st.ChangeValue(fpscontrol.stamina);
			}
			oldpos = transform.position;
		}
	}
	
	void MakeStep()
	{
		if(stepnumb == step_snd.Length-1) stepnumb = 0;
		else stepnumb += 1;
		audio.PlayOneShot(step_snd[stepnumb]);
	}
	
	public void DisableSniper()
	{
		hud.enabled = true;
		scope.SetActiveRecursively(false);
		foreach(Camera c in cams)
			c.fov = 60.0f;
		MouseLook.sensitivityX = Mathf.Abs(msens);
		MouseLook.sensitivityY = msens;
	}
	
	public void DoDamage(int dam)
	{
		if(hp > 0)
		{
			hp-=dam;
			hud_hit.DoHit();
			if(hp <= 0)
			{
				if(hp < 0)
					hp = 0;
				DoDeath();
			}
			hud_hp.ChangeValue(hp,100);
		}
	}
	
	public void DoDeath()
	{
		scope.SetActiveRecursively(false);
		foreach(Camera c in cams)
			c.fov = 60.0f;
		MouseLook.sensitivityX = Mathf.Abs(msens);
		MouseLook.sensitivityY = msens;
		player.GetComponent<WeaponScript>().ShowWeapon(false);
		hud_items.SetActiveRecursively(false);
		hud_items.transform.Find("HudRespawn").guiText.enabled = true;
		hud_items.transform.Find("HudRespawn").gameObject.active = true;
		GetComponent<CharacterMotor>().enabled = false;
		GetComponent<CharacterController>().enabled = false;
		GetComponent<MouseLook>().enabled = false;
		transform.Find("camera").transform.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		if(weaponactive)
			player.GetComponent<WeaponScript>().enabled = false;
		audio.PlayOneShot(death_snd);
		isdead = true;
	}
	
	public bool IsDead()
	{
		return isdead;
	}
}