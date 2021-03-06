using UnityEngine;
using System.Collections;

public class MenuLoad : MonoBehaviour
{
	int stage = 0;
	
	string[] badpcgames =
	{
		"PC",
		"játékok",
		"sorozat"
	};
	
	void Awake()
	{
		if(!GameObject.Find("cfgloader"))
			new GameObject("cfgloader").AddComponent<OptionLoader>();
	}
	
	void Start()
	{
		StartCoroutine(ChangeText());
		Screen.showCursor = true;
		Screen.lockCursor = false;
	}
	
	IEnumerator ChangeText()
	{
		while(stage < 3)
		{
			yield return new WaitForSeconds(1.0f);
			GetComponent<TextMesh>().text += "\n" + badpcgames[stage];
			stage++;
		}
	}
}