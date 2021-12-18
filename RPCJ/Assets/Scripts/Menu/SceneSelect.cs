using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour
{
	public bool isinc = false;
	public GameObject numbobj;
	SceneText tmp;
	
	void Awake()
	{
		tmp = numbobj.GetComponent<SceneText>();
	}
	
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
		tmp.SceneNumber(isinc);
	}
}
