using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    bool blockshot = false;
    public GameObject audiosrc;
    MainScript controller;
    public GameObject player;

    public GameObject[] weapon = new GameObject[2];
    public AudioClip[] weapon_shoot = new AudioClip[2];
    public AudioClip[] weapon_reload = new AudioClip[2];
    public AudioClip melee_hit;

    public Transform proj_point;
    RaycastHit hit = new RaycastHit();
    Transform gunflash;

    GUIText gui_cammo;
    GameObject gui_ammo;
    GUIText gui_mammo;

    int[] mammo = new int[10];
    int[] cammo = new int[10];

    int[] max_ammo;
    int[] clip_ammo;

    float[] fire_reset;
    float[] fire_delay;
    float[] reload_delay;

    int[,] damage;

    bool[] isauto;
	public bool[] filters;
    bool isfiredown = false;
    bool auto_reload = false;
    bool ismelee = false;

    Vector3[] normal_pos = new Vector3[10];
    Vector3[] shoot_pos = new Vector3[10];
    Vector3[] reload_pos = new Vector3[10];

    public int weaponid = 0;
    float mwheel = 0;
	
	//Death
    bool isdead = false;
	HudwIcon hud_wicon;
	
	//Particles
	public GameObject par_blood;
	public GameObject par_spark;

    void Start()
    {
        //Load arrays	
        max_ammo = new int[]
		{
			1,
			170,
			36,
			50,
			240,
			300,
			100,
			150,
			100,
			50
		};

        clip_ammo = new int[]
		{
			1,
			17,
			6,
			8,
			30,
			50,
			20,
			50,
			50,
			2
		};

        fire_reset = new float[]
		{
			0.1f,
			0.15f,
			0.15f,
			0.15f,
			0.02f,
			0.02f,
			0.2f,
			0.05f,
			0.05f,
			0.2f
		};

        fire_delay = new float[]
		{
			0.15f,
			0.15f,
			0.3f,
			0.35f,
			0.027f,
			0.027f,
			0.3f,
			0.027f,
			0.027f,
			0.3f
		};

        reload_delay = new float[]
		{
			1.5f,
			1.0f,
			2.5f,
			1.5f,
			1.5f,
			1.5f,
			1.5f,
			2.0f,
			2.0f,
			1.5f
		};

        damage = new int[,] 
		{
			{75,150},
			{10,20},
			{50,70},
			{80,150},
			{5,25},
			{5,15},
			{50,150},
			{10,25},
			{10,30},
			{80,120}
		};

        isauto = new bool[]
		{
			false,
			false,
			false,
			false,
			true,
			true,
			false,
			true,
			true,
			false
		};
        //Load arrays end
		ismelee = weaponid == 0;
        controller = audiosrc.GetComponent<MainScript>();
		hud_wicon = GameObject.Find("HudWIcon").GetComponent<HudwIcon>();
		hud_wicon.ChangeIcon(weaponid);
        weapon[weaponid].renderer.enabled = true;
        for (int i = 0; i < mammo.Length; i++)
        {
            mammo[i] = max_ammo[i];
            cammo[i] = clip_ammo[i];
            normal_pos[i] = weapon[i].transform.localPosition;
            shoot_pos[i] = normal_pos[i] - new Vector3(0, 0, 0.1f);
            reload_pos[i] = normal_pos[i] - new Vector3(0, 0.3f, 0);
        }
        gui_ammo = GameObject.Find("HudAmmo");
        gui_ammo.GetComponent<HudAmmo>().enabled = true;
        gui_cammo = GameObject.Find("HudCAmmo").guiText;
        gui_mammo = GameObject.Find("HudMAmmo").guiText;
        gui_cammo.text = cammo[weaponid].ToString("00");
        gui_mammo.text = mammo[weaponid].ToString("000");
    }
	
	public void DoFinal()
	{
		for(int i = 1; i < weapon.Length; i++)
			filters[i] = true;
		FastChangeWeapon(0);
	}

    public void ResetAmmo()
    {
        for (int i = 0; i < mammo.Length; i++)
        {
            mammo[i] = max_ammo[i];
            cammo[i] = clip_ammo[i];
        }
        gui_ammo.GetComponent<HudAmmo>().ChangeValue2(cammo[weaponid], clip_ammo[weaponid]);
        gui_cammo.text = cammo[weaponid].ToString("00");
        gui_mammo.text = mammo[weaponid].ToString("000");
    }

    void ChangeWeapon(int wid)
    {
        if (weaponid != wid && !filters[wid])
        {
            if (wid == 0) ismelee = true;
            else ismelee = false;

            blockshot = true;
			audiosrc.GetComponent<MainScript>().weap_light.enabled = false;
            controller.DisableSniper();
            weapon[weaponid].renderer.enabled = false;
            weaponid = wid;
            StartCoroutine(ReappearWeapon());
        }
    }

    bool ChangeWeapon2(int wid, int old)
    {
		if(filters[wid])
		{
			audiosrc.GetComponent<MainScript>().weap_light.enabled = false;
			controller.DisableSniper();
        	weapon[old].renderer.enabled = false;
			return false;
		}
        if (wid == 0) ismelee = true;
        else ismelee = false;

        blockshot = true;
		audiosrc.GetComponent<MainScript>().weap_light.enabled = false;
        controller.DisableSniper();
        weapon[old].renderer.enabled = false;
        StartCoroutine(ReappearWeapon());
		return true;
    }

    void FastChangeWeapon(int wid)
    {
        if (weaponid != wid && !filters[wid])
        {
            if (wid == 0) ismelee = true;
            else ismelee = false;

            controller.DisableSniper();
            isfiredown = true;
            weapon[weaponid].renderer.enabled = false;
            weapon[weaponid].transform.localPosition = normal_pos[weaponid];
            if (gunflash != null) gunflash.renderer.enabled = false;
            weaponid = wid;
            weapon[weaponid].renderer.enabled = true;
			hud_wicon.ChangeIcon(weaponid);
			gui_ammo.GetComponent<HudAmmo>().ChangeValue(cammo[weaponid], clip_ammo[weaponid]);
            gui_cammo.text = cammo[weaponid].ToString("00");
            gui_mammo.text = mammo[weaponid].ToString("000");
            isfiredown = false;
			audiosrc.GetComponent<MainScript>().weap_light.enabled = false;
			audiosrc.light.enabled = false;
        }
    }

    public void ShowWeapon(bool input)
    {
        if (input)
            weapon[weaponid].renderer.enabled = input;
        else
        {
            weapon[weaponid].renderer.enabled = input;
            if (gunflash != null) gunflash.renderer.enabled = input;
            audiosrc.light.enabled = input;
        }
        isdead = !input;
    }

    IEnumerator ReappearWeapon()
    {
        yield return new WaitForSeconds(1.0f);
        if (!isdead)
            weapon[weaponid].renderer.enabled = true;
		hud_wicon.ChangeIcon(weaponid);
        gui_ammo.GetComponent<HudAmmo>().ChangeValue(cammo[weaponid], clip_ammo[weaponid]);
        gui_cammo.text = cammo[weaponid].ToString("00");
        gui_mammo.text = mammo[weaponid].ToString("000");
        blockshot = false;
    }

    //It only works fine with this Update
    void Update()
    {
        if (!blockshot && !isfiredown)
        {
            mwheel = Input.GetAxis("Mouse ScrollWheel");
            if (mwheel < 0)
            {
				do
				{
	                if (weaponid >= 9)
	                    weaponid = 0;
	                else
	                    weaponid++;
				}
                while(!ChangeWeapon2(weaponid, weaponid - 1 < 0 ? 9 : weaponid - 1));
            }
            else if (mwheel > 0)
            {
				do
				{
	                if (weaponid <= 0)
	                    weaponid = 9;
	                else
	                    weaponid--;
				}
                while(!ChangeWeapon2(weaponid, weaponid + 1 > 9 ? 0 : weaponid + 1));
            }
        }
    }

    void DoMeleeAttack()
    {
		weapon[weaponid].animation.Play("st_hit");
        BlockWeapon(fire_delay[weaponid]);
        audiosrc.audio.PlayOneShot(weapon_shoot[weaponid]);
        Physics.Raycast(proj_point.position, proj_point.forward, out hit, 2.0f, 9);
        if (hit.collider)
        {
			if(hit.collider.GetComponent<Endg22>())
				hit.collider.GetComponent<Endg22>().DoDamage(Random.Range(damage[weaponid,0],damage[weaponid,1]));
			if(hit.collider.GetComponent<ShotTrigger>())
				hit.collider.GetComponent<ShotTrigger>().DoTrigger(controller.gameObject);
			if(hit.collider.tag == "Player")
				GameObject.Instantiate(par_blood,hit.point,new Quaternion(0,0,0,0));
			else if(hit.collider.GetComponent<HPTrigger>())
			{
				hit.collider.GetComponent<HPTrigger>().DoTrigger(
					controller.gameObject,
					Random.Range(damage[weaponid,0],damage[weaponid,1])
					);
				audiosrc.audio.PlayOneShot(melee_hit);
			}
			else
				audiosrc.audio.PlayOneShot(melee_hit);
        }	
        isfiredown = true;
    }

    void DoShot()
    {
        gunflash = weapon[weaponid].transform.Find("gunflash");
        cammo[weaponid] -= 1;
        gui_ammo.GetComponent<HudAmmo>().ChangeValue(cammo[weaponid], clip_ammo[weaponid]);
        gui_cammo.text = cammo[weaponid].ToString("00");
        audiosrc.light.enabled = true;
        gunflash.renderer.enabled = true;
        audiosrc.audio.PlayOneShot(weapon_shoot[weaponid]);
        weapon[weaponid].transform.localPosition = shoot_pos[weaponid];
        if(!isauto[weaponid]) StartCoroutine(ResetGunFire(fire_reset[weaponid]));
        BlockWeapon(fire_delay[weaponid]);
        Physics.Raycast(proj_point.position, proj_point.forward, out hit, 500.0f, 9);
        if (hit.collider)
        {
			if(hit.collider.GetComponent<Endg22>())
				hit.collider.GetComponent<Endg22>().DoDamage(Random.Range(damage[weaponid,0],damage[weaponid,1]));
			if(hit.collider.GetComponent<ShotTrigger>())
				hit.collider.GetComponent<ShotTrigger>().DoTrigger(controller.gameObject);
			if(hit.collider.tag == "Player")
				GameObject.Instantiate(par_blood,hit.point,new Quaternion(0,0,0,0));
			else if(hit.collider.GetComponent<HPTrigger>())
				hit.collider.GetComponent<HPTrigger>().DoTrigger(
					controller.gameObject,
					Random.Range(damage[weaponid,0],damage[weaponid,1])
					);
			else
				GameObject.Instantiate(par_spark,hit.point,new Quaternion(0,0,0,0));
        }
        isfiredown = true;
    }

    void FixedUpdate()
    {
        if (!blockshot)
        {
            if (!isfiredown)
            {
                if (Input.GetKey(KeyCode.Alpha1)) ChangeWeapon(0);
                else if (Input.GetKey(KeyCode.Alpha2)) ChangeWeapon(1);
                else if (Input.GetKey(KeyCode.Alpha3)) ChangeWeapon(2);
                else if (Input.GetKey(KeyCode.Alpha4)) ChangeWeapon(3);
                else if (Input.GetKey(KeyCode.Alpha5)) ChangeWeapon(4);
                else if (Input.GetKey(KeyCode.Alpha6)) ChangeWeapon(5);
                else if (Input.GetKey(KeyCode.Alpha7)) ChangeWeapon(6);
                else if (Input.GetKey(KeyCode.Alpha8)) ChangeWeapon(7);
                else if (Input.GetKey(KeyCode.Alpha9)) ChangeWeapon(8);
                else if (Input.GetKey(KeyCode.Alpha0)) ChangeWeapon(9);
            }
			
            if (Input.GetButton("Fire1") && ismelee)
                DoMeleeAttack();
            else if (Input.GetButton("Fire1") && cammo[weaponid] > 0 && !ismelee)
                DoShot();
			else if (isfiredown)
			{
                isfiredown = false;
				if (isauto[weaponid])
				{
					weapon[weaponid].transform.localPosition = normal_pos[weaponid];
 					audiosrc.light.enabled = false;
					weapon[weaponid].transform.Find("gunflash").renderer.enabled = false;
				}
			}
            else if (Input.GetButton("Reload") || (cammo[weaponid] <= 0 && auto_reload) && !ismelee)
            {
                if (mammo[weaponid] > 0 && cammo[weaponid] < clip_ammo[weaponid])
                {
                    if (mammo[weaponid] > (clip_ammo[weaponid] - cammo[weaponid]))
                    {
                        mammo[weaponid] -= (clip_ammo[weaponid] - cammo[weaponid]);
                        cammo[weaponid] = clip_ammo[weaponid];
                    }
                    else
                    {
                        cammo[weaponid] = mammo[weaponid] - (clip_ammo[weaponid] - cammo[weaponid]);
                        cammo[weaponid] = clip_ammo[weaponid] + cammo[weaponid];
                        mammo[weaponid] = 0;
                    }
                    gui_cammo.text = cammo[weaponid].ToString("00");
                    gui_mammo.text = mammo[weaponid].ToString("000");
                    gui_ammo.GetComponent<HudAmmo>().ChangeValue(cammo[weaponid], clip_ammo[weaponid]);
                    audiosrc.audio.PlayOneShot(weapon_reload[weaponid]);
                    weapon[weaponid].transform.localPosition = reload_pos[weaponid];
                    BlockWeapon2(reload_delay[weaponid]);
                }
            }
        }
    }
	
	//Shooting
    void BlockWeapon(float seconds)
    {
        blockshot = true;
		StartCoroutine(WeaponSleep(seconds));
    }
	
	IEnumerator WeaponSleep(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		if (!ismelee)
            weapon[weaponid].transform.localPosition = normal_pos[weaponid];
		StartCoroutine(UnBlockWeapon(seconds));
	}

    IEnumerator UnBlockWeapon(float seconds)
    {
        yield return new WaitForSeconds(seconds);
		if(enabled)
		{
			if (Input.GetButton("Fire1") && ismelee)
			{
				weapon[weaponid].animation.Play("st_idle");
	            DoMeleeAttack();
			}
	        else if (Input.GetButton("Fire1") && cammo[weaponid] > 0 && !ismelee)
	            DoShot();
			else
			{
				if(ismelee)
					weapon[weaponid].animation.Play("st_idle");
	        	blockshot = false;
				//blockanim = false;
			}
		}
		else
			blockshot = false;
    }
	
	IEnumerator ResetGunFire(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        audiosrc.light.enabled = false;
        gunflash.renderer.enabled = false;
    }
	
	//Reloading
	void BlockWeapon2(float seconds)
    {
        blockshot = true;
		StartCoroutine(UnBlockWeapon2(seconds));
    }
	
	IEnumerator UnBlockWeapon2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        blockshot = false;
        if (!ismelee)
            weapon[weaponid].transform.localPosition = normal_pos[weaponid];
        else
            weapon[weaponid].animation.Play("st_idle");
    }
}