using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour
{
	public void Start()
	{
		StartCoroutine(RotTimer());
	}
	
	IEnumerator RotTimer()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.05f);
			transform.RotateAround(transform.forward,20.0f);
		}
	}
}