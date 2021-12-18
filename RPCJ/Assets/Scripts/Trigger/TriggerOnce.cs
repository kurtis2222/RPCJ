using UnityEngine;
using System.Collections;

public class TriggerOnce : MonoBehaviour
{
	public AudioClip sound;
	public enum Action
	{
		Nothing = 0,
		DoFreeze = 1,
		DoUnfreeze = 2
	};
	public float waittime = 1.0f;
	public int levelid = -1;
	public bool delay_destroy = false;
	bool otherdel = false;
	
	public Action TriggerAction = Action.Nothing;
	
	void OnTriggerEnter (Collider col)
	{
		if(col.name == "Player")
		{
			collider.enabled = false;
			if(sound != null)
					col.audio.PlayOneShot(sound);
			//Triggers
			if(GetComponent<SaberTrigger>())
				GetComponent<SaberTrigger>().DoTrigger(col.gameObject);
			if(GetComponent<DeathTrigger>())
				GetComponent<DeathTrigger>().DoTrigger(col.gameObject);
			if(GetComponent<TeleportTrigger>())
				GetComponent<TeleportTrigger>().DoTrigger(col.gameObject);
			if(GetComponent<ImageTrigger>())
				GetComponent<ImageTrigger>().DoTrigger();
			if(GetComponent<SpawnTrigger>())
				GetComponent<SpawnTrigger>().DoTrigger();
			if(GetComponent<DestroyTrigger>())
				GetComponent<DestroyTrigger>().DoTrigger();
			if(GetComponent<EnableTrigger>())
				GetComponent<EnableTrigger>().DoTrigger();
			if(GetComponent<MortyrDrunk>())
				GetComponent<MortyrDrunk>().DoDrink();
			if(GetComponent<SlideTrigger>())
			{
				otherdel = levelid == -1 && TriggerAction == Action.Nothing;
				GetComponent<SlideTrigger>().DoTrigger(otherdel);
			}
			//Triggers end
			if(TriggerAction == Action.Nothing)
			{
				if(levelid != -1)
					StartCoroutine(DoChange());
				else if(!otherdel)
				{
					if(delay_destroy)
						StartCoroutine(DoDestroy());
					else
						Destroy(gameObject);
				}
			}
			else
			{
				if(col.GetComponent<CharacterMotor>())
					col.GetComponent<CharacterMotor>().canControl = false;
				else if(col.GetComponent<FPSWalkerEnhanced>())
					col.GetComponent<FPSWalkerEnhanced>().can_control = false;
				else if(col.GetComponent<AirboneHero>())
				{
					col.GetComponent<AirboneHero>().enabled = false;
					col.rigidbody.velocity = Vector3.zero;
					col.rigidbody.angularVelocity = Vector3.zero;
				}
				else
				{
					col.transform.root.GetComponent<BigRigs>().enabled = false;
					col.transform.root.rigidbody.velocity = Vector3.zero;
					col.transform.root.rigidbody.angularVelocity = Vector3.zero;
				}
				StartCoroutine(DoFreeze(col));
			}
		}
	}
	
	IEnumerator DoFreeze(Collider col)
	{
		yield return new WaitForSeconds(waittime);
		if(TriggerAction == Action.DoFreeze)
			Application.LoadLevel(levelid);
		else if(TriggerAction == Action.DoUnfreeze)
		{
			if(col.GetComponent<CharacterMotor>())
				col.GetComponent<CharacterMotor>().canControl = true;
			else if(col.GetComponent<FPSWalkerEnhanced>())
				col.GetComponent<FPSWalkerEnhanced>().can_control = true;
			else if(col.GetComponent<AirboneHero>())
				col.GetComponent<AirboneHero>().enabled = true;
			else
				col.transform.root.GetComponent<BigRigs>().enabled = true;
		}
		if(!otherdel)
			Destroy(gameObject);
	}
	
	IEnumerator DoChange()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
	
	IEnumerator DoDestroy()
	{
		yield return new WaitForSeconds(waittime);
		Destroy(gameObject);
	}
}