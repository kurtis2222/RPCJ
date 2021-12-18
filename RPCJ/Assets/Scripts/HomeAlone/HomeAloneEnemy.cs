using UnityEngine;
using System.Collections;

public class HomeAloneEnemy : MonoBehaviour
{
	public AudioClip caught_snd;
	public GameObject other;
	public Transform player;
	public Renderer sprite;
	public Texture[] sprites;
	int anim = 0;
	
	void Awake()
	{
		StartCoroutine(DoWalk());
	}
	
	void FixedUpdate()
	{
		transform.LookAt(player);
		transform.position += transform.forward * 0.2f;
		
		if(Vector3.Distance(transform.position,player.position) < 0.5f)
		{
			Destroy(other);
			enabled = false;
			GetComponent<ImageTrigger>().DoTrigger();
			player.audio.PlayOneShot(caught_snd);
			StartCoroutine(DoRestart());
		}
	}
	
	IEnumerator DoWalk()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.2f);
			anim%=2;
			sprite.material.mainTexture = sprites[anim];
			anim++;
		}
	}
	
	IEnumerator DoRestart()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}