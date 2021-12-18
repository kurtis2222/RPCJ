using UnityEngine;
using System.Collections;

public class MortyrDrunk : MonoBehaviour
{
	public GUITexture hud;
	
	public void DoDrink()
	{
		hud.color = new Color(0.5f,0.5f,0.5f,hud.color.a+0.031f);
	}
}