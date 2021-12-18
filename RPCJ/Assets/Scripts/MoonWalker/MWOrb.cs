using UnityEngine;
using System.Collections;

public class MWOrb : MonoBehaviour
{
	public GameObject end_gate;
	public Transform player;
	public GUITexture[] hud_orb;
	public Transform[] orbs;
	int count = 0;
	int i = 0;
	
	void FixedUpdate()
	{
		for(i = 0; i < 6; i++)
		{
			if(orbs[i] != null && Vector3.Distance(player.position,orbs[i].position) < 1.0f)
			{
				Destroy(orbs[i].gameObject);
				hud_orb[count].enabled = true;
				count++;
				if(count == 6)
				{
					Destroy(end_gate);
					Destroy(this);
				}
			}
		}
	}
}