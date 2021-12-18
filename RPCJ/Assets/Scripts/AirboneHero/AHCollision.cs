using UnityEngine;
using System.Collections;

public class AHCollision : MonoBehaviour
{
	public float waittime = 2.0f;
	public float waittime2 = 3.0f;
	public int levelid = 0;
	
	public GameObject img1, img2;
	public AudioClip snd1, snd2;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			collider.enabled = false;
			col.GetComponent<AirboneHero>().enabled = false;
			col.audio.PlayOneShot(snd1);
			GetComponent<EnableTrigger>().DoTrigger();
			img1.GetComponent<ImageTrigger>().DoTrigger();
			StartCoroutine(Wait(col.gameObject));
			StartCoroutine(Wait2());
		}
	}
	
	IEnumerator Wait(GameObject sender)
	{
		yield return new WaitForSeconds(waittime);
		sender.audio.PlayOneShot(snd2);
		img2.GetComponent<ImageTrigger>().DoTrigger();
	}
	
	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(waittime2);
		Application.LoadLevel(levelid);
	}
}