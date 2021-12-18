using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour
{
	public AudioClip snd;
	public GUITexture winner;
	public int levelid;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player" && col.transform.root.GetComponent<BigRigs>().GetChecks() == 12)
		{
			col.transform.root.GetComponent<BigRigs>().enabled = false;
			col.transform.root.rigidbody.velocity = new Vector3(0f,0f,0f);
			col.transform.root.rigidbody.angularVelocity = new Vector3(0f,0f,0f);
			col.audio.PlayOneShot(snd);
			StartCoroutine(Wait());
			StartCoroutine(Wait2());
		}
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f);
		winner.enabled = true;
	}
	
	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(11.0f);
		Application.LoadLevel(levelid);
	}
}