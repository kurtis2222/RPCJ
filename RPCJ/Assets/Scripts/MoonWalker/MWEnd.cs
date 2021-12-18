using UnityEngine;
using System.Collections;

public class MWEnd : MonoBehaviour
{
	public Transform enemy;
	public Transform enemy_gui;
	public AudioClip fred_snd;
	public float scaretime = 2.0f;
	public float waittime = 4.0f;
	public int levelid = 0;
	bool grow = false;
	Vector3 grow_scale = Vector3.zero;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			collider.enabled = false;
			col.GetComponent<MoonWalker>().DoEnd();
			col.audio.PlayOneShot(fred_snd);
			enabled = true;
			StartCoroutine(DoScare());
		}
	}
	
	void FixedUpdate()
	{
		if(enemy != null)
			enemy.position += transform.right * 0.1f;
		if(grow && enemy_gui.localScale.x < 1.0f)
		{
			grow_scale.x = grow_scale.y += 0.01f;
			enemy_gui.localScale = grow_scale;
		}
	}
	
	IEnumerator DoScare()
	{
		yield return new WaitForSeconds(scaretime);
		Destroy(enemy.gameObject);
		enemy_gui.guiTexture.enabled = true;
		grow = true;
		StartCoroutine(DoWait());
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
}