using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour
{
	FPSWalkerEnhanced fpsw;
	GameObject[] water;
	
	void Awake()
	{
		water = GameObject.FindGameObjectsWithTag("Water");
		fpsw = GetComponent<FPSWalkerEnhanced>();
	}
	
	void Update()
	{
		foreach(GameObject c in water)
			fpsw.isinwater = c.collider.bounds.Contains(transform.position);
	}
}
