using UnityEngine;
using System.Collections;

public class Outro : MonoBehaviour
{
	public GUITexture fade_gui;
	public float waittime = 4.0f;
	public float waittime2 = 19.0f;
	public float waittime3 = 22.0f;
	public int levelid = 0;
	Quaternion look_up = Quaternion.Euler(-45f,0f,0f);
	Color fade_color;
	
	void Awake()
	{
		audio.Play();
		StartCoroutine(DoWait());
		StartCoroutine(BeginFade());
		StartCoroutine(DoEnd());
		fade_gui.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		fade_color = fade_gui.color;
	}
	
	void FixedUpdate()
	{
		if(transform.rotation.eulerAngles.y > -45f)
			transform.rotation = Quaternion.RotateTowards(transform.rotation,look_up,2.0f);
		else
			enabled = false;
	}
	
	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waittime);
		enabled = true;
	}
	
	IEnumerator BeginFade()
	{
		yield return new WaitForSeconds(waittime2);
		StartCoroutine(DoFade());
	}
	
	IEnumerator DoFade()
	{
		while(fade_color.a < 0.5f)
		{
			yield return new WaitForSeconds(0.05f);
			fade_color.a += 0.01f;
			fade_gui.color = fade_color;
		}
	}
	
	IEnumerator DoEnd()
	{
		yield return new WaitForSeconds(waittime3);
		Application.LoadLevel(levelid);
	}
}