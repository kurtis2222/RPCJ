using UnityEngine;
using System.Collections;

public class JumppadScript : MonoBehaviour
{
	FPSWalkerEnhanced fpsw;
	GameObject[] jumppad;
	
	void Awake()
	{
		jumppad = GameObject.FindGameObjectsWithTag("Respawn");
		fpsw = GetComponent<FPSWalkerEnhanced>();
	}
	
	void Update()
	{
		foreach(GameObject c in jumppad)
			if(c.collider.bounds.Intersects(transform.collider.bounds))
				fpsw.Jumppad();
	}
}
