using UnityEngine;
using System.Collections;

public class WartrainEnemy : MonoBehaviour
{
	public Object exp;
	public Transform player;
	Renderer muzzle;
	bool blockfire = false;
	int lives = 2;
	
	void Awake()
	{
		muzzle = transform.Find("muzzle").renderer;
	}
	
	void FixedUpdate()
	{
		transform.LookAt(new Vector3(player.position.x,transform.position.y,player.position.z));
		transform.rotation = Quaternion.Euler(
			-90.0f,
			transform.rotation.eulerAngles.z-90,
			transform.rotation.eulerAngles.y
			);
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
		yield return new WaitForSeconds(0.2f);
		muzzle.enabled = false;
	}
	
	IEnumerator ResetFire()
	{
		yield return new WaitForSeconds(1.0f);
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