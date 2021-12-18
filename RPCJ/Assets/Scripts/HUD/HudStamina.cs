using UnityEngine;
using System.Collections;

public class HudStamina : MonoBehaviour {
	
	GameObject player = null;
	float st_max;
	float st, st_old;
	float[] data;
	float tmp;
	
	public void GetInfo(GameObject pl)
	{
		player = pl;
		data = new float[] {guiTexture.pixelInset.x, guiTexture.pixelInset.y, guiTexture.pixelInset.height};
		st_max = guiTexture.pixelInset.width;
		st = player.GetComponent<CharacterMotor>().stamina;
		st_old = st;
	}
	
	public void ChangeValue(float input)
	{
		st = input;
		if(st_old != st)
		{
			tmp = st / 1000 * st_max;
			guiTexture.pixelInset = new Rect(data[0], data[1], tmp, data[2]);
		}
		st_old = st;
	}
}
