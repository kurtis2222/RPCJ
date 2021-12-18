using UnityEngine;
using System.Collections;

public class Heat : MonoBehaviour
{
	public Transform hand;
	public AudioClip aquafit_snd;
	public float waittime = 5.0f;
	bool first = false;
	bool isdown = false;
	bool dir = false;
	Vector3 hand_norm, hand_punch;
	
	void Awake()
	{
		hand_norm = hand.localPosition;
		hand_punch = hand_norm + new Vector3(0f,0f,0.4f);
		StartCoroutine(EnableTimer());
	}
	
	void FixedUpdate ()
	{
		if(Input.GetButton("Fire1"))
		{
			if(!isdown)
			{
				if(!first)
				{
					audio.PlayOneShot(aquafit_snd);
					first = true;
				}
				isdown = true;
				dir = true;
			}
		}
		if(dir)
		{
			hand.localPosition = Vector3.MoveTowards(hand.localPosition,hand_punch,0.05f);
			if(hand.localPosition == hand_punch)
				dir = false;
		}
		else if(!dir)
		{
			hand.localPosition = Vector3.MoveTowards(hand.localPosition,hand_norm,0.05f);
			if(hand.localPosition == hand_norm)
				isdown = false;
		}
	}
	
	IEnumerator EnableTimer()
	{
		yield return new WaitForSeconds(waittime);
		enabled = true;
	}
}