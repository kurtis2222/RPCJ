using UnityEngine;
using System.Collections;

public class CartScript : MonoBehaviour
{
	public Transform end_trans;
	Vector3 start_point, end_point;
	bool ismoving = false;
	bool dir = false;
	
	void Awake()
	{
		start_point = transform.position;
		end_point = end_trans.position;
	}
	
	void FixedUpdate()
	{
		if(ismoving)
		{
			transform.position = Vector3.MoveTowards(transform.position, dir ? end_point : start_point, 0.05f);
			if(transform.position == (dir ? end_point : start_point))
				ismoving = false;
		}
	}
	
	public void DoMove()
	{
		if(!ismoving)
		{
			ismoving = true;
			dir = !dir;
		}
	}
}