using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	public bool isquit = false;
	public TextMesh scenetext;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.blue;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.black;
	}
	
	void OnMouseDown()
	{
		if(!isquit)
		{
			int tmp = 1;
			int.TryParse(scenetext.text,out tmp);
			Application.LoadLevel(tmp);
			tmp = default(int);
		}
		else Application.Quit();
	}
}