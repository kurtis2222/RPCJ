using UnityEngine;
using System.Collections;

public class HudScaleFont : MonoBehaviour {
	
	void Start ()
	{
		guiText.material.color = new Color(243f/255f,132f/255f,23f/255f,0.75f);
		
		if(Screen.width < 1024 || Screen.height < 768)
		{
			guiText.pixelOffset =
					new Vector2(guiText.pixelOffset.x * Screen.width / 1024,
						guiText.pixelOffset.y * Screen.height / 768);
			guiText.fontSize = (int)(24 * (Screen.width+Screen.height)/1792);
		}
	}
}