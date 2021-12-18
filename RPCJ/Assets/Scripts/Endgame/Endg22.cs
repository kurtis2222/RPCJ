using UnityEngine;
using System.Collections;

public class Endg22 : MonoBehaviour
{
	public Transform[] random_pos;
	public GameObject boss_hud;
	public GUIText gui_stella;
	public GUITexture boss_bar;
	//Phase 2
	public Transform proj_point;
	public Transform player;
	public Object projectile;
	public AudioClip shoot_snd;
	//Phase 3
	public AudioClip taunt;
	public AudioClip empty_snd;
	public AudioClip clash_music;
	public ParticleEmitter flame;
	public GameObject par_blood;
	public AudioClip hit_snd;
	public AudioClip impact_snd;
	public AudioClip end_snd;
	public GameObject outro;
	Vector3 last_loc = new Vector3(10f,50f,10f);
	
	int hp = 1000;
	int dmg = 0;
	int time = 10;
	System.Random rnd = new System.Random();
	int tmp;
	int phase = 0;
	RaycastHit hit = new RaycastHit();
	static bool beaten = false;
	
	void Start()
	{
		//Kisebb kegyelem
		if(beaten) hp = 1;
		gui_stella.material.color = new Color(243f/255f,132f/255f,23f/255f,0.75f);
		boss_hud.SetActiveRecursively(true);
		StartCoroutine(ChangePos());
	}
	
	void FixedUpdate()
	{
		if(phase < 2)
			proj_point.LookAt(player);
		else
		{
			transform.LookAt(player);
			transform.position += transform.forward * 0.2f;
			if(Physics.Raycast(transform.position,transform.forward,out hit,0.5f))
			{
				if(hit.collider.name == "Player")
				{
					hit.collider.GetComponent<MainScript>().DoDamage(20);
					if(player.GetComponent<MainScript>().IsDead())
						enabled = false;
				}
				audio.PlayOneShot(impact_snd);
				transform.position = last_loc;
			}
		}
	}
	
	public void DoDamage(int dam)
	{
		hp-=dam;
		dmg+=dam;
		boss_bar.GetComponent<HudAmmo>().ChangeValue(hp,1000);
		
		if(phase < 2)
		{
			if(dmg > 49)
			{
				dmg = 0;
				DoChange();
			}
		}
		else
			transform.position = last_loc;
		
		if(hp <= 0)
		{
			hp = 0;
			collider.enabled = false;
			boss_bar.GetComponent<HudAmmo>().ChangeValue(hp,1000);
			if(phase == 1)
			{
				player.audio.Stop();
				player.audio.PlayOneShot(empty_snd);
				player.GetComponentInChildren<WeaponScript>().DoFinal();
				renderer.materials[0].shader = renderer.materials[1].shader = Shader.Find("Unlit/Texture");
			}
			if(phase < 2)
				StartCoroutine(NextPhase());
			else
			{
				player.audio.Stop();
				renderer.enabled = enabled = false;
				StartCoroutine(DefQuote());
			}
		}
	}
	
	void DoChange()
	{
		time = 10;
		tmp = rnd.Next(0,random_pos.Length);
		transform.position = random_pos[tmp].position;
		transform.rotation = random_pos[tmp].rotation;
	}
	
	IEnumerator ChangePos()
	{
		while(phase < 2)
		{
			yield return new WaitForSeconds(1.0f);
			if(time > 0)
				time--;
			else
				DoChange();
		}
	}
	
	IEnumerator DoShoot()
	{
		while(phase < 2 && !player.GetComponent<MainScript>().IsDead())
		{
			yield return new WaitForSeconds(0.5f);
			if(Physics.SphereCast(proj_point.position,0.2f,proj_point.forward,out hit,100.0f))
				if(hit.collider.name == "Player")
				{
					audio.PlayOneShot(shoot_snd);
					GameObject.Instantiate(projectile,proj_point.position,proj_point.rotation);
				}
		}
	}
	
	IEnumerator NextPhase()
	{
		yield return new WaitForSeconds(2.0f);
		if(!player.GetComponent<MainScript>().IsDead())
		{
			collider.enabled = true;
			if(phase == 0)
			{
				beaten = true;
				StartCoroutine(DoShoot());
			}
			hp = 1000;
			boss_bar.GetComponent<HudAmmo>().ChangeValue(hp,1000);
			phase++;
			if(phase == 2)
			{
				WeaponScript ws = player.GetComponentInChildren<WeaponScript>();
				ws.melee_hit = hit_snd;
				ws.par_blood = par_blood;
				ws = null;
				flame.emit = true;
				player.light.color = new Color(0f,1f,0f);
				player.light.renderMode = LightRenderMode.ForcePixel;
				player.light.enabled = true;
				player.audio.clip = clash_music;
				player.audio.Play();
				player.audio.PlayOneShot(taunt);
			}
		}
	}
	
	IEnumerator DefQuote()
	{
		yield return new WaitForSeconds(2.0f);
		audio.PlayOneShot(end_snd);
		StartCoroutine(DoWait());
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(2.0f);
		outro.SetActiveRecursively(true);
		Destroy(boss_hud);
		Destroy(GameObject.Find("hud_items(Clone)"));
		Destroy(player.gameObject);
		Destroy(gameObject);
	}
}