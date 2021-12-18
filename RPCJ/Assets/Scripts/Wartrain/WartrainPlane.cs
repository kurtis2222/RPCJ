using UnityEngine;
using System.Collections;

public class WartrainPlane : MonoBehaviour
{
	public Object exp;
	public Transform player;
	Renderer muzzle;
	bool blockfire = false;
	int lives = 4;
	
	void Awake()
	{
		muzzle = transform.Find("muzzle").renderer;
	}
	
	void FixedUpdate()
	{
		transform.position += transform.right * 0.25f;
		if(transform.position.x > 50.0f)
			Destroy(gameObject);
		if(!blockfire && Vector3.Distance(transform.position,player.position) < 20.0f)
		{
			blockfire = true;
			muzzle.enabled = true;
			audio.Play();
			StartCoroutine(ResetMuzzle());
			StartCoroutine(ResetFire());
		}
	}
	
	IEnumerator ResetMuzzle()
	{
		yield return new WaitForSeconds(0.1f);
		muzzle.enabled = false;
	}
	
	IEnumerator ResetFire()
	{
		yield return new WaitForSeconds(0.25f);
		blockfire = false;
	}
	
	public void DoDamage()
	{
		lives--;
		if(lives == 0)
		{
			GameObject.Instantiate(exp, transform.position, new Quaternion(0,0,0,0));
			Destroy(gameObject);
		}
	}
}