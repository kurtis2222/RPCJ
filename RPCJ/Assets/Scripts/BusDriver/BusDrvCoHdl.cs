using UnityEngine;
using System.Collections;

public class BusDrvCoHdl : MonoBehaviour
{
	public enum CoSay
	{
		EasyL = 0,
		EasyR = 1,
		MedL = 2,
		MedR = 3,
		HardL = 4,
		HardR = 5,
		HairL = 6,
		HairR = 7,
		Jump = 8
	}
	
	public AudioClip[] co_snd;
	public Texture[] co_arrow;
	
	public GUIText jump;
	public GUITexture codrv;
	int wait = 0;
	int tmp = 0;
	
	void Awake()
	{
		StartCoroutine(DoClear());
	}
	
	public void SendSound(GameObject sender, CoSay say)
	{
		tmp = (int)say;
		sender.audio.PlayOneShot(co_snd[tmp]);
		if(tmp == 8)
		{
			jump.text = "Jump ahead";
			jump.enabled = true;
		}
		else
		{
			codrv.texture = co_arrow[tmp];
			codrv.enabled = true;
		}
		wait = 3;
	}
	
	IEnumerator DoClear()
	{
		while(true)
		{
			yield return new WaitForSeconds(1.0f);
			if(wait > 0)
			{
				wait--;
				if(wait == 0)
				{
					jump.enabled = false;
					codrv.enabled = false;
				}
			}
		}
	}
}