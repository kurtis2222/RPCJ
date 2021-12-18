using UnityEngine;
using System.Collections;

public class HudScale : MonoBehaviour {
	
	void Awake()
	{
		if(Screen.width < 1024 || Screen.height < 768)
			guiTexture.pixelInset =
				new Rect(guiTexture.pixelInset.x * Screen.width / 1024,
					guiTexture.pixelInset.y * Screen.height / 768,
					guiTexture.pixelInset.width * Screen.width / 1024,
					guiTexture.pixelInset.height * Screen.height / 768);
	}
}