using UnityEngine;
using System.Collections;

public class SlideTrigger : MonoBehaviour {
	
	public Transform obj;
	public Vector3 move_pos;
	public float speed;
	bool destr;
	
	public void DoTrigger(bool destr)
	{
		enabled = true;
		move_pos = obj.transform.position + move_pos;
		this.destr = destr;
	}
	
	public void FixedUpdate()
	{
		obj.transform.position = Vector3.MoveTowards(obj.position,move_pos,speed/10);
		if(obj.transform.position == move_pos)
			if(destr)
				Destroy(gameObject);
	}
}