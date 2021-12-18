using UnityEngine;
using System.Collections;

public class DVveg : MonoBehaviour
{
	Transform target;
	
	public void Init(Transform target)
	{
		this.target = target;
		transform.LookAt(target);
		enabled = true;
	}
	
	void FixedUpdate()
	{
		transform.position += transform.forward * 0.05f;
		if(Vector3.Distance(transform.position,target.position) < 0.25f)
		{
			target.GetComponent<DarkVamp>().DoDamage();
			Destroy(gameObject);
		}
	}
}