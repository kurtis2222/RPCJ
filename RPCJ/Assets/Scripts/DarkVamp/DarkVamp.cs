using UnityEngine;
using System.Collections;

public class DarkVamp : MonoBehaviour
{
	public int levelid = 0;
	public ParticleEmitter smoke;
	
	public GameObject img1, img2;
	public GameObject img_trig;
	public AudioClip start_snd;
	public AudioClip end_snd;
	public float waittime = 5.0f;
	
	public HudAmmo hud_hp;
	public GUIText hud_rem;
	
	RaycastHit hit = new RaycastHit();
	bool isdown = false;
	int kills = 30;
	int lives = 5;
	bool win = false;
	
	void Awake()
	{
		audio.PlayOneShot(start_snd);
		img1.GetComponent<ImageTrigger>().DoTrigger();
		img2.GetComponent<ImageTrigger>().DoTrigger();
		hud_rem.material.color = new Color(1.0f,0.0f,0.0f);
		StartCoroutine(DoEnable());
	}
	
	void FixedUpdate()
	{
		isdown = Input.GetButton("Fire1");
		
		smoke.emit = isdown;
		if(isdown)
			if(Physics.Raycast(transform.position,transform.forward,out hit,10.0f))
			{
				if(hit.collider.name == "dv_enemy")
				{
					Destroy(hit.collider.gameObject);
					kills--;
					hud_rem.text = kills.ToString();
				}
			}
		if(!win && (kills == 0 || Input.GetKey(KeyCode.DownArrow)))
		{
			audio.Stop();
			win = true;
			//Clean
			Destroy(GameObject.Find("dv_controller"));
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Player"))
				Destroy(g);
			img_trig.GetComponent<ImageTrigger>().DoTrigger();
			audio.PlayOneShot(end_snd);
			StartCoroutine(WaitTimer());
		}
	}
	
	IEnumerator WaitTimer()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
	
	public void DoDamage()
	{
		lives--;
		kills--;
		hud_hp.ChangeValue(lives,5);
		hud_rem.text = kills.ToString();
		if(lives < 0)
			Application.LoadLevel(Application.loadedLevel);
	}
	
	IEnumerator DoEnable()
	{
		yield return new WaitForSeconds(12.0f);
		audio.Play();
		enabled = true;
	}
}