using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour
{
	public Transform player;
	Transform[] tmp;
	Transform[] objs;
	
	void Awake()
	{
		int i2 = 0;
		tmp = GetComponentsInChildren<Transform>();
		objs = new Transform[tmp.Length-1];
		for(int i = 0; i < tmp.Length; i++)
		{
			objs[i2] = tmp[i];
			if(tmp[i] != transform)
				i2++;
		}
		tmp = null;
		i2 = default(int);
	}
	
	void FixedUpdate()
	{
		foreach(Transform t in objs)
				t.LookAt(player);
	}
}