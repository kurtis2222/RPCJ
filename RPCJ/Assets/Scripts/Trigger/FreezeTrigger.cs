using UnityEngine;
using System.Collections;

public class FreezeTrigger : MonoBehaviour
{
	public float waittime = 5.0f;
	
	public void DoTrigger(GameObject sender)
	{
		sender.GetComponent<CharacterMotor>().canControl = false;
		StartCoroutine(DoWait(sender));
	}
	
	IEnumerator DoWait(GameObject sender)
	{
		yield return new WaitForSeconds(waittime);
		sender.GetComponent<CharacterMotor>().canControl = true;
	}
}