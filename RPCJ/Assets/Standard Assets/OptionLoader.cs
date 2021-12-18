using UnityEngine;
using System.Collections;

public class OptionLoader : MonoBehaviour
{
	FileConfigManager.FCM config;
	const string filename = "config.ini";
	string[] data, val;
	static int[] gfx_data;
	static int tmp_int;
	static float tmp_fl;
	static bool ovrd = false;
	public static float msens = 5.0f;
	public static float ssens = 1.0f;
	static bool loaded = false;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if(loaded) return;
		
		config = new FileConfigManager.FCM();
		config.ReadAllData(filename,out data,out val);
		for(int i = 0; i < data.Length; i++)
		{
            if (data[i] == "OverrideGfx")
                bool.TryParse(val[i], out ovrd);
			else if(data[i] == "MouseSens")
				float.TryParse(val[i],out msens);
			else if(data[i] == "ScopeSens")
				float.TryParse(val[i],out ssens);
			if(data[i] == "Volume")
			{
				float.TryParse(val[i], out tmp_fl);
				AudioListener.volume = tmp_fl;
			}
		}
		if(ovrd)
		{
			gfx_data = new int[6];
			for(int i = 0; i < data.Length; i++)
			{
		        if (data[i] == "PixelLights")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[0] = tmp_int;
		        }
		        else if (data[i] == "Texture")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[1] = 2-tmp_int;
		        }
		        else if (data[i] == "Aniso")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[2] = tmp_int;
		        }
		        else if (data[i] == "AALevel")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[3] = 1 << tmp_int;
		        }
		        else if (data[i] == "BoneQuality")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[4] = tmp_int;
		        }
		        else if(data[i] == "Vsync")
		        {
		            int.TryParse(val[i], out tmp_int);
					gfx_data[5] = tmp_int;
		        }
			}
		}
		tmp_int = default(int);
		config = null;
		loaded = true;
	}
	
	void OnLevelWasLoaded()
	{
		if(ovrd)
		{
			QualitySettings.pixelLightCount = gfx_data[0];
			QualitySettings.masterTextureLimit = gfx_data[1];
			QualitySettings.anisotropicFiltering = (AnisotropicFiltering)gfx_data[2];
			QualitySettings.antiAliasing = gfx_data[3];
			QualitySettings.blendWeights = (BlendWeights)gfx_data[4];
			QualitySettings.vSyncCount = gfx_data[5];
		}
	}
}