using UnityEngine;
using System.Collections;

public class SniperScope : MonoBehaviour {
	
	bool started_before = false;
	public int part = 0;
	
	void Start ()
	{
		if(!started_before)
		{
			if(part == 0)
				guiTexture.pixelInset = new Rect(0,0, Screen.width/2 - Screen.height/2,Screen.height);
			else if(part == 1)
				guiTexture.pixelInset = new Rect(Screen.width/2 + Screen.height/2,0, Screen.width/2 - Screen.height/2,Screen.height);
			if(part == 2)
				guiTexture.pixelInset = new Rect(Screen.width/2 - Screen.height/2,0,Screen.height,Screen.height);
			started_before = true;
		}
	}
}
