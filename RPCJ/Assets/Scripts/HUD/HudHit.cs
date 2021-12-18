using UnityEngine;
using System.Collections;

public class HudHit : MonoBehaviour {

	void Start ()
	{
		guiTexture.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		StartCoroutine(HideHit());
	}
	
	public void DoHit()
	{
		guiTexture.enabled = true;
	}
	
	IEnumerator HideHit()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);
			if(guiTexture.enabled)
				guiTexture.enabled = false;
		}
	}
}
