using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour
{
	public Light intro_light;
	float anim_length = 665;
	float currtime;
	
	float[] frames =
	{
		60f,
		220f,
		260f
	};
	
	bool[] state =
	{
		false,
		false,
		false
	};
	
	int i;
	
	void Awake()
	{
		for(i = 0; i < 3; i++)
			frames[i] /= anim_length;
		StartCoroutine(NextLevel());
	}
	
	void Update()
	{
		currtime = animation["Intro"].normalizedTime;
		for(i = 0; i < 3; i++)
			if(frames[i] <= currtime && !state[i])
			{
				if(i == 2)
					enabled = false;
				intro_light.enabled = !intro_light.enabled;
				state[i] = true;
				break;
			}
	}
	
	IEnumerator NextLevel()
	{
		yield return new WaitForSeconds(animation.clip.length);
		Application.LoadLevel(2);
	}
}