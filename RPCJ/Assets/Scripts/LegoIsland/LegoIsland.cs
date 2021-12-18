using UnityEngine;
using System.Collections;

public class LegoIsland : MonoBehaviour
{
	public float waittime = 5.0f;
	public AudioClip visor_snd;
	public AudioClip end_snd;
	
	//Intro
	public Camera[] cameras;
	bool freeze;
	
	//Other
	public GameObject enemy;
	public float speed = 10.0f;
	public float lspeed = 7.0f;
	public float enemy_lspeed = 6.0f;
	public float enemy_speed = 9.8f;
	public GUIText kmph;
	public GUIText gear;
	public GUIText hcount;
	public GameObject info;
	public AudioSource engine;
	public AudioClip count_snd, go_snd;
	public int levelid = 0;
	float ver;
	int count = 3;
	
	//Gear changing
	float[] gears = { 1, 40, 80, 120, 170 };
	float[] efmpw = { 1, 1, 30, 70, 110 };
	float pl_sd;
	int pl_gr;
	bool jmp;
	
	//Wheels
	public Transform[] wheels;
	
	void Awake()
	{
		pl_gr = 0;
		freeze = true;
		audio.PlayOneShot(visor_snd);
		StartCoroutine(DoWait());
	}
	
	void FixedUpdate()
	{
		ver = Input.GetAxis("Vertical");
		if(freeze)
		{
			engine.pitch = 1+ver*9;
			return;
		}
		pl_sd = (rigidbody.velocity.magnitude * 8f);
		if(pl_gr == 0)
		{
			if(ver > 0)
				engine.pitch = 1+ver*9;
		}
		else
			engine.pitch = 1+Mathf.Clamp(pl_sd/gears[pl_gr]*9,0,9);
		kmph.text = pl_sd.ToString("0");
		if(ver > 0 && pl_gr > 0 && pl_sd < gears[pl_gr])
		{
			if(pl_sd < efmpw[pl_gr])
				rigidbody.AddForce(transform.forward * lspeed);
			else
				rigidbody.AddForce(transform.forward * speed);
		}
		
		//Enemy
		enemy.audio.pitch = 1+enemy.rigidbody.velocity.magnitude/1.5f;
		if(enemy.rigidbody.velocity.magnitude > 5f)
			enemy.rigidbody.AddForce(enemy.transform.forward * enemy_speed);
		else
			enemy.rigidbody.AddForce(enemy.transform.forward * enemy_lspeed);
		
		if(rigidbody.velocity.magnitude > 0.2f)
			for(int i = 0; i < 4; i++)
				wheels[i].RotateAround(wheels[i].right,1.0f);
		
		for(int i = 4; i < 8; i++)
			wheels[i].RotateAround(wheels[i].right,1.0f);
		
		if(transform.position.z > 160)
			EndRace(true);
		else if(enemy.transform.position.z > 160)
			EndRace(false);
	}
	
	void Update()
	{
		jmp = Input.GetButtonUp("Jump");
		if(ver < 0 && jmp && pl_gr > 0)
		{
			pl_gr--;
			if(pl_gr == 0)
				gear.text = "N";
			else
				gear.text = pl_gr.ToString();
		}
		else if(jmp && pl_gr < gears.Length - 1)
		{
			pl_gr++;
			gear.text = pl_gr.ToString();
		}
	}
	
	void EndRace(bool win)
	{
		enabled = false;
		rigidbody.velocity = enemy.rigidbody.velocity = Vector3.zero;
		engine.pitch = enemy.audio.pitch = 1;
		hcount.enabled = true;
		hcount.text = win ? "You win!" : "You lose!";
		if(!win)
			levelid = Application.loadedLevel;
		else
			audio.PlayOneShot(end_snd);
		StartCoroutine(FinishWait());
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waittime);
		for(int i = 0; i < cameras.Length; i++)
			cameras[i].enabled = !cameras[i].enabled;
		hcount.enabled = true;
		Destroy(info);
		audio.PlayOneShot(count_snd);
		StartCoroutine(Countdown());
	}
	
	IEnumerator Countdown()
	{
		while(count > 0)
		{
			yield return new WaitForSeconds(1.0f);
			count--;
			hcount.text = count > 0 ? count.ToString() : "GO!";
			if(count == 0)
			{
				freeze = false;
				audio.PlayOneShot(go_snd);
				StartCoroutine(RemoveCounter());
			}
			else
				audio.PlayOneShot(count_snd);
		}
	}
	
	IEnumerator RemoveCounter()
	{
		yield return new WaitForSeconds(1.0f);
		hcount.enabled = false;
	}
			
	IEnumerator FinishWait()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel(levelid);
		enabled = false;
	}
}