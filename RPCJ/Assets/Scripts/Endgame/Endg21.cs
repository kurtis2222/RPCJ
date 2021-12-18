using UnityEngine;
using System.Collections;

public class Endg21 : MonoBehaviour
{
	public AudioClip snd;
	public GameObject boss;
	public GameObject boss_info;
	
	void OnTriggerEnter(Collider col)
	{
		col.audio.PlayOneShot(snd);
		boss.active = true;
		boss_info.active = true;
		boss.GetComponent<Endg22>().enabled = true;
		Destroy(gameObject);
	}
}