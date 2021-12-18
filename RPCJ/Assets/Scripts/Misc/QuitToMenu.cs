using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class QuitToMenu : MonoBehaviour
{
	const string filename = "password";
	BinaryWriter bw;
	
	void Awake()
	{
		if(File.Exists(filename))
		{
			bw = new BinaryWriter(new FileStream(filename,FileMode.Open,FileAccess.Write),Encoding.Default);
			bw.BaseStream.Position = Application.loadedLevel-1;
			bw.Write((char)1);
			bw.Close();
		}
		else
		{
			bw = new BinaryWriter(new FileStream(filename,FileMode.Create,FileAccess.Write),Encoding.Default);
			for(int i = 0; i < 26; i++)
				if(i < Application.loadedLevel)
					bw.Write((char)1);
				else
					bw.Write((char)0);
			bw.Close();
		}
	}
	
	void Start()
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
	
	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.Escape))
			Application.LoadLevel(0);
	}
}