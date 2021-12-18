using UnityEngine;
using System.Collections;

public class HudAmmo : MonoBehaviour {
	
	float tmp;
	float st_max;
	float[] data;
	
	void Start ()
	{
		data = new float[] {guiTexture.pixelInset.x, guiTexture.pixelInset.y, guiTexture.pixelInset.height};
		st_max = guiTexture.pixelInset.width;
	}
	
	public void ChangeValue (int input, int max)
	{
		if(max == 0) tmp = 0;
		else tmp = (float)input / (float)max * st_max;
		guiTexture.pixelInset = new Rect(data[0], data[1], tmp, data[2]);
	}
	
	public void ChangeValue2 (int input, int max)
	{
		if(data != null)
		{
			if(max == 0) tmp = 0;
			else tmp = (float)input / (float)max * st_max;
			guiTexture.pixelInset = new Rect(data[0], data[1], tmp, data[2]);
		}
	}
}