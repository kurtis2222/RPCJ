using UnityEngine;
using System.Collections;

public class FullscreenHud : MonoBehaviour
{
	void Start()
	{
		guiTexture.pixelInset = new Rect(0,0,Screen.width,Screen.height);
	}
}