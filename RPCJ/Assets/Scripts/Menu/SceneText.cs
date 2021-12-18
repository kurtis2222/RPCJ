using UnityEngine;
using System.Collections;
using System.IO;

public class SceneText : MonoBehaviour
{
	int scene = 1;
	int scene_max;
	
	const string filename = "password";
	StreamReader sr;
	char[] tmp;
	
	void Awake()
	{
		if(File.Exists(filename))
		{
			sr = new StreamReader(filename,System.Text.Encoding.Default);
			tmp = sr.ReadToEnd().ToCharArray();
			sr.Close();
		}
		
		int i;
		for(i = 0; i < tmp.Length; i++)
			if(tmp[i] == 0)
				break;
		
		i+=1;
		if(i > Application.levelCount-1)
			i = Application.levelCount;
		else if(i < 1)
			i = 1;
		scene_max = i;
	}
	
	public void SceneNumber(bool inc)
	{
		if(scene_max > 1)
		{
			if(inc)
			{
				if(scene == scene_max-1) scene = 1;
				else scene++;
			}
			else
			{
				if(scene == 1) scene = scene_max-1;
				else scene--;
			}
		}
		GetComponent<TextMesh>().text = scene.ToString();
	}
}