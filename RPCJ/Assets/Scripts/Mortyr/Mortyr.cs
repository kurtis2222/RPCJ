using UnityEngine;
using System.Collections;

public class Mortyr : MonoBehaviour
{
	int hp = 100;
	int ammo = 16;
	int weaponid = 1;
	public GameObject[] weapons;
	public AudioClip[] wsound;
	Renderer[] gunflash = new Renderer[2];
	public Transform wp_helper;
	Quaternion normal_pos, fire_pos;
	bool isdown = false;
	
	public AudioClip[] step_snd;
	int step = 0;
	bool blocksnd = false;
	
	public GUITexture hud_wicon;
	public GUIText hud_ammo;
	public GUIText hud_hp;
	public HudHit hud_hit;
	public GUIText hud_respawn;
	public Texture[] wicon;
	CharacterController control;
	
	public GameObject maincam;
	public Transform proj_point;
	RaycastHit hit = new RaycastHit();
	bool gotmg = false;
	bool isdead = false;
	System.Random rnd = new System.Random();
	
	public AudioClip[] pick_snd = new AudioClip[3];
	
	float[] waittime =
	{
		0.5f,
		0.5f,
		0.1f
	};
	
	void Start()
	{
		control = GetComponent<CharacterController>();
		normal_pos = wp_helper.localRotation;
		fire_pos = normal_pos * Quaternion.Euler(-2.0f,0,0);
		for(int i = 0; i < weapons.Length-1; i++)
			gunflash[i] = weapons[i+1].transform.Find("gunflash").renderer;
	}
	
	void FixedUpdate()
	{
		if(!isdown && !isdead)
		{
			if(Input.GetKey(KeyCode.Alpha1)) ChangeWeapon(0);
			if(Input.GetKey(KeyCode.Alpha2)) ChangeWeapon(1);
			if(Input.GetKey(KeyCode.Alpha3) && gotmg) ChangeWeapon(2);
			if(Input.GetButton("Fire1"))
			{
				if(weaponid == 0 || ammo > 0)
				{
					if(weaponid != 0)
					{
						light.enabled = true;
						gunflash[weaponid-1].enabled = true;
						wp_helper.localRotation = fire_pos;
						ammo--;
						hud_ammo.text = ammo.ToString();
					}
					audio.PlayOneShot(wsound[weaponid]);
					isdown = true;
					StartCoroutine(ResetWeapon());
					if(Physics.Raycast(proj_point.position,proj_point.forward,out hit,weaponid != 0 ? 50.0f : 2.0f))
						if(hit.collider.name == "mortyr_enemy")
							hit.collider.GetComponent<MortyrEnemy>().DoDamage();
				}
			}
		}
		if(!blocksnd && control.isGrounded && control.velocity.magnitude > 0.5f)
		{
			audio.PlayOneShot(step_snd[step]);
			step++;
			step%=step_snd.Length;
			blocksnd = true;
			StartCoroutine(StepWait());
		}
		if(isdead && Input.GetButton("Use"))
			Application.LoadLevel(Application.loadedLevel);
	}
	
	void ChangeWeapon(int weaponid)
	{
		weapons[this.weaponid].renderer.enabled = false;
		this.weaponid = weaponid;
		weapons[weaponid].renderer.enabled = true;
		hud_wicon.guiTexture.texture = wicon[weaponid];
		hud_ammo.enabled = weaponid != 0;
	}
	
	IEnumerator ResetWeapon()
	{
		yield return new WaitForSeconds(waittime[weaponid]);
		if(light.enabled)
			light.enabled = false;
		if(weaponid != 0)
		{
			gunflash[weaponid-1].enabled = false;
			wp_helper.localRotation = normal_pos;
		}
		isdown = false;
	}
	
	IEnumerator StepWait()
	{
		yield return new WaitForSeconds(0.5f);
		blocksnd = false;
	}
	
	public void DoDamage()
	{
		if(hp > 0)
		{
			hp-=rnd.Next(1,6);
			if(hp <= 0)
			{
				hp = 0;
				GetComponent<FPSWalkerEnhanced>().can_control = false;
				GetComponent<MouseLook>().enabled = false;
				maincam.GetComponent<MouseLook>().enabled = false;
				hud_respawn.enabled = true;
				isdead = true;
			}
			hud_hp.text = hp.ToString();
			hud_hit.DoHit();		
		}
	}
	
	public bool GiveHP()
	{
		if(hp == 100) return false;
		hp+=15;
		if(hp > 100)
			hp = 100;
		hud_hp.text = hp.ToString();
		audio.PlayOneShot(pick_snd[0]);
		return true;
	}
	
	public void GiveAmmo()
	{
		ammo+=5;
		hud_ammo.text = ammo.ToString();	
		audio.PlayOneShot(pick_snd[1]);
	}
	
	public void GiveMG()
	{
		gotmg = true;
		ChangeWeapon(2);
		audio.PlayOneShot(pick_snd[2]);
	}
}