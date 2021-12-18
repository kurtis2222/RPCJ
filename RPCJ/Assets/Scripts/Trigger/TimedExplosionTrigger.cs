using UnityEngine;
using System.Collections;

public class TimedExplosionTrigger : MonoBehaviour
{
	public GameObject[] tr_obj;
	public float waittime = 5.0f;
	public float waittime2 = 10.0f;
	
	void Start()
	{
		StartCoroutine(Wait());
		StartCoroutine(Wait2());
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(waittime);
		foreach(GameObject g in tr_obj)
		{
			g.SetActiveRecursively(true);
			g.particleEmitter.emit = true;
		}
	}
	
	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(waittime2);
		foreach(GameObject g in tr_obj)
			g.particleEmitter.emit = false;
	}
}