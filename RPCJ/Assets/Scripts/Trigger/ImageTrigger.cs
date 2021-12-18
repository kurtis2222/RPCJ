using UnityEngine;
using System.Collections;

public class ImageTrigger : MonoBehaviour
{
	GameObject hud;
	GUITexture img;
	GUITexture backg;
	public Texture image;
	public bool fullscreen = false;
	public float waittime = 1.0f;
	public float destroytime = 0.0f;
	
	public void DoTrigger()
	{
		hud = (GameObject)GameObject.Instantiate(Resources.Load("hud_img"));
		img = hud.transform.Find("img").guiTexture;
		if(fullscreen)
		{
			backg = hud.transform.Find("backg").guiTexture;
			int width = Screen.width;
			int height = Screen.height;
			float aspect = (float)height/image.height;
			img.transform.localPosition = new Vector3(0,0,3);
			img.pixelInset = new Rect(width/2-(image.width*aspect)/2,0,image.width*aspect,image.height*aspect);
			backg.pixelInset = new Rect(0,0,width,height);
		}
		else
			img.pixelInset = new Rect(-image.width,0,image.width,image.height);
		img.texture = image;
		if(waittime > 0)
		{
			StartCoroutine(ShowImage());
			if(destroytime > 0)
				StartCoroutine(DestroyImage());
		}
		else
		{
			img.enabled = true;
			if(fullscreen)
				backg.enabled = true;
			if(destroytime > 0)
				StartCoroutine(DestroyImage());
		}
	}
	
	IEnumerator ShowImage()
	{
		yield return new WaitForSeconds(waittime);
		img.enabled = true;
		if(fullscreen)
			backg.enabled = true;
	}
	
	IEnumerator DestroyImage()
	{
		yield return new WaitForSeconds(destroytime);
		Destroy(hud);
		Destroy(this);
	}
}