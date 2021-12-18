using UnityEngine;
using System.Collections;

public class BusDriver : MonoBehaviour
{
	public float speed = 5.0f;
	public float steer_speed = 5.0f;
	
	//HUD
	public GUIText hud_spd, hud_gear, hud_time, hud_text;
	public GUITexture hud_prog;
	int[] time = {0,0,0};
	
	//Engine
	public AudioSource engine;
	public AudioClip turbo_snd;
	public AudioClip in_snd, out_snd;
	public AudioClip gear_snd;
	
	public AudioClip fred_snd;
	//Countdown
	public AudioClip cheer_snd, finish_snd, ignite_snd;
	public AudioClip[] count_snd;
	int count_idx = 0;
	
	public Transform[] wheels;
	public Camera[] cameras;
	public Behaviour[] taill;
	
	//Waypoints
	public Transform waypoint;
	Transform[] tmp_ways;
	Transform[] waypoints;
	int curr_point = 0;
	public float arrow_minus;
	public float arrow_len;
	float pointdist = 0;
	Rect arrow_prog;
	
	//Gears
	public float[] gears = new float[6];
	int cgear = 0;
	bool reverse = false;
	float direction;
	
	Transform[] whelper;
	float hor, ver;
	float cspeed;
	float rspeed = 0;
	
	bool isdown = false;
	bool isgas = false;
	bool cango = false;
	
	//Intro
	bool canrev = false;
	bool dorev = false;
	bool revn = false;
	
	public int levelid = 0;
	
	void Awake()
	{
		//Waypoints
		int i2 = 0;
		tmp_ways = waypoint.gameObject.GetComponentsInChildren<Transform>();
		waypoints = new Transform[tmp_ways.Length-1];
		for(int i = 0; i < tmp_ways.Length; i++)
		{
			waypoints[i2] = tmp_ways[i];
			if(tmp_ways[i] != waypoint)
				i2++;
		}
		tmp_ways = null;
		i2 = default(int);
		//Arrow setup
		arrow_prog = hud_prog.pixelInset;
		//Wheels
		whelper = new Transform[wheels.Length];
		for(int i = 0; i < wheels.Length; i++)
			whelper[i] = wheels[i].parent;
		audio.PlayOneShot(fred_snd);
		StartCoroutine(WaitForStart());
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		direction = transform.InverseTransformDirection(rigidbody.velocity).z;
		taill[0].enabled = taill[1].enabled = 
			taill[2].enabled = taill[3].enabled = reverse ? ver > 0 : ver < 0;
		if(cango)
		{
			rspeed = rigidbody.velocity.magnitude * 3.0f;
			hud_spd.text = rspeed.ToString("000");
			//Turbo SND
			if(ver == 1)
				isgas = true;
			else if(isgas)
			{
				isgas = false;
				audio.PlayOneShot(turbo_snd);
			}
			
			//Engine SND
			cspeed = rigidbody.velocity.magnitude/gears[cgear];
			if(cspeed > 1.0)
			{
				if(cgear < 5 && direction > 0)
				{
					if(cameras[0].enabled)
						audio.PlayOneShot(gear_snd);
					cgear++;
					hud_gear.text = (cgear+1).ToString();
				}
				cspeed = 1.0f;
			}
			else if(cgear > 0 && cspeed < 0.5)
			{
				if(cameras[0].enabled)
						audio.PlayOneShot(gear_snd);
				cgear--;
				hud_gear.text = (cgear+1).ToString();
			}
			engine.pitch = 0.25f + cspeed;
			
			//Reverse gear
			if(direction < -1)
			{
				hud_gear.text = "R";
				reverse = true;
			}
			else if(reverse)
			{
				hud_gear.text = (cgear+1).ToString();
				reverse = false;
			}
			
			if(rigidbody.velocity.magnitude > 0.2f)
			{
				rigidbody.angularVelocity = new Vector3(0f,steer_speed * hor,0f);
				rigidbody.AddForce(-transform.forward * 0.5f * cspeed);
			}
			if((!reverse && rspeed < 265) || (reverse && rspeed < 51))
				rigidbody.AddForce(transform.forward * speed * ver);
			for(int i = 0; i < wheels.Length; i++)
			{
				if(rigidbody.velocity.magnitude > 0.2f)
					wheels[i].RotateAround(wheels[i].right*ver,4.0f);
				if(i < 2)
					whelper[i].localRotation = Quaternion.Euler(0f,0f,45.0f*hor);
			}
			//Checkpoints
			if(curr_point < waypoints.Length && Vector3.Distance(waypoints[curr_point].position,transform.position) < 15.0f)
			{
				curr_point++;
				if(curr_point == waypoints.Length)
				{
					cango = false;
					canrev = false;
					engine.pitch = 0.25f;
					hud_text.enabled = true;
					hud_text.text = "Finish";
					hud_spd.text = "000";
					hud_gear.text = "N";
					audio.PlayOneShot(finish_snd);
					StartCoroutine(ChangeLevel());
				}
			}
			else if(curr_point > 1 && Vector3.Distance(waypoints[curr_point-2].position,transform.position) < 15.0f)
				curr_point--;
			if(curr_point > 0 && curr_point < waypoints.Length)
				pointdist = 1-(Vector3.Distance(transform.position,waypoints[curr_point].position)/
					Vector3.Distance(waypoints[curr_point-1].position,waypoints[curr_point].position));
			//Draw progress
			arrow_prog.x = ((float)curr_point+pointdist)/waypoints.Length * arrow_len + arrow_minus;
			if(arrow_prog.x < arrow_minus)
				arrow_prog.x = arrow_minus;
			hud_prog.pixelInset = arrow_prog;
		}
		else if(canrev)
			engine.pitch = 0.25f + ver;
		
		if(Input.GetButton("Jump"))
		{
			if(!isdown)
			{
				if(engine.audio.clip == in_snd)
					engine.audio.clip = out_snd;
				else
					engine.audio.clip = in_snd;
				engine.audio.Play();
				cameras[0].enabled = cameras[1].enabled;
				cameras[1].enabled = !cameras[1].enabled;
				isdown = true;
			}
		}
		else isdown = false;
		
		if(dorev)
		{
			engine.pitch += revn ? -0.025f : 0.025f;
			if(!revn && engine.pitch > 1.0f)
				revn = true;
			if(revn && engine.pitch < 0.25f)
			{
				engine.pitch = 0.25f;
				revn = false;
				canrev = true;
				dorev = false;
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.name == "co")
			col.GetComponent<BusDrvCoDrv>().DoSay(gameObject);
	}
	
	IEnumerator TimeMeasure()
	{
		while(cango && time[2] < 99)
		{
			yield return new WaitForSeconds(0.01f);
			time[0]++;
			if(time[0] > 99)
			{
				time[0] = 0;
				time[1]++;
				if(time[1] == 60)
				{
					time[1] = 0;
					time[2]++;
				}
			}
			hud_time.text =
				time[2].ToString("00") + ":" +
				time[1].ToString("00") + ":" +
				time[0].ToString("00");
		}
	}
	
	IEnumerator Intro()
	{
		yield return new WaitForSeconds(5.0f);
		audio.PlayOneShot(ignite_snd);
		dorev = true;
		hud_text.enabled = true;
		StartCoroutine(CountDown());
	}
	
	IEnumerator CountDown()
	{
		while(count_idx < count_snd.Length)
		{
			yield return new WaitForSeconds(0.8f);
			audio.PlayOneShot(count_snd[count_idx]);
			if(count_idx < 5)
				hud_text.text = (5-count_idx).ToString();
			count_idx++;
			if(count_idx == count_snd.Length)
			{
				cango = true;
				hud_text.text = "Go!";
				StartCoroutine(TimeMeasure());
				StartCoroutine(RemText());
				if(cameras[0].enabled)
						audio.PlayOneShot(gear_snd);
				hud_gear.text = (cgear+1).ToString();
			}
		}
	}
	
	IEnumerator RemText()
	{
		yield return new WaitForSeconds(0.8f);
		hud_text.enabled = false;
	}
	
	IEnumerator ChangeLevel()
	{
		yield return new WaitForSeconds(10.0f);
		Application.LoadLevel(levelid);
	}
	
	IEnumerator WaitForStart()
	{
		yield return new WaitForSeconds(7.0f);
		audio.Play();
		audio.PlayOneShot(cheer_snd);
		StartCoroutine(Intro());
	}
}