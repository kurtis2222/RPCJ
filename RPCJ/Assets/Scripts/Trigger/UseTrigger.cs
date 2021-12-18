using UnityEngine;
using System.Collections;

public class UseTrigger : MonoBehaviour
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
	bool otherdel = false;
	
	public Action TriggerAction = Action.Nothing;
	
	public void DoTrigger(GameObject sender)
	{
		collider.enabled = false;
		if(sound != null)
			sender.audio.PlayOneShot(sound);
		//Triggers
		if(GetComponent<SaberTrigger>())
			GetComponent<SaberTrigger>().DoTrigger(sender);
		if(GetComponent<DeathTrigger>())
			GetComponent<DeathTrigger>().DoTrigger(sender);
		if(GetComponent<ImageTrigger>())
			GetComponent<ImageTrigger>().DoTrigger();
		if(GetComponent<TeleportTrigger>())
			GetComponent<TeleportTrigger>().DoTrigger(sender);
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
				Destroy(gameObject);
		}
		else
		{
			if(sender.GetComponent<CharacterMotor>())
				sender.GetComponent<CharacterMotor>().canControl = false;
			else if(sender.GetComponent<FPSWalkerEnhanced>())
				sender.GetComponent<FPSWalkerEnhanced>().can_control = false;
			StartCoroutine(DoFreeze(sender));
		}
	}
	
	IEnumerator DoFreeze(GameObject sender)
	{
		yield return new WaitForSeconds(waittime);
		if(TriggerAction == Action.DoFreeze && levelid != -1)
			Application.LoadLevel(levelid);
		else if(TriggerAction == Action.DoUnfreeze)
		{
			if(sender.GetComponent<CharacterMotor>())
				sender.GetComponent<CharacterMotor>().canControl = true;
			else if(sender.GetComponent<FPSWalkerEnhanced>())
				sender.GetComponent<FPSWalkerEnhanced>().can_control = true;
		}
		if(!otherdel)
			Destroy(gameObject);
	}
	
	IEnumerator DoChange()
	{
		yield return new WaitForSeconds(waittime);
		Application.LoadLevel(levelid);
	}
}