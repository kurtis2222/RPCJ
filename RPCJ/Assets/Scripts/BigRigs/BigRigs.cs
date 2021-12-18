using UnityEngine;
using System.Collections;

public class BigRigs : MonoBehaviour
{
	float hor, ver;
	int dir = 1;
	public Behaviour[] blight;
	public GameObject speed_meter;
	public Transform needle;
	public TextMesh mph, miles;
	public GUIText lap, pnt, time;
	float speed = 0.0f;
	
	//Checkpoint hud
	public Transform check_parent;
	public Texture check_texture;
	GameObject[] checks = new GameObject[13];
	int ch_count = 0;
	
	void Start()
	{
		rigidbody.drag = 0.2f;
		speed_meter.SetActiveRecursively(true);
		lap.material.color = Color.yellow;
		time.material.color = Color.yellow;
		pnt.material.color = Color.red;
		for(int i = 0; i < checks.Length; i++)
		{
			checks[i] = new GameObject(i.ToString("00"),typeof(GUITexture));
			checks[i].layer = 1;
			checks[i].transform.position = new Vector3(0f,1f,1f);
			checks[i].transform.localScale = new Vector3(0f,0f,0f);
			checks[i].guiTexture.pixelInset = new Rect(20+i*10,-137,8,16);
			checks[i].guiTexture.color = Color.red;
			checks[i].guiTexture.texture = check_texture;
			checks[i].transform.parent = check_parent;
		}
		checks[0].guiTexture.color = Color.green;
		mph.renderer.material.color = Color.black;
		miles.renderer.material.color = Color.black;
	}
	
	public void FixedUpdate()
	{
		ver = Input.GetAxis("Vertical");
		hor = Input.GetAxis("Horizontal");
		rigidbody.angularVelocity = transform.TransformDirection(0.0f,2.0f*hor,0.0f);
		//Brake lights
		blight[0].enabled = ver < 0 && dir == 1;
		blight[1].enabled = blight[0].enabled;
		if(ver < 0)
		{
			rigidbody.velocity = transform.TransformDirection(0,0,rigidbody.velocity.magnitude*dir);
			rigidbody.AddForce(transform.forward*20.0f*ver);
			if(rigidbody.velocity.magnitude < 0.1f && dir == 1)
			{
				dir = -1;
			}
		}
		else if(dir == -1 && ver != -1)
		{
			rigidbody.velocity = Vector3.zero;
			dir = 1;
		}
		else
		{
			rigidbody.velocity = transform.TransformDirection(0,0,rigidbody.velocity.magnitude);
			rigidbody.AddForce(transform.forward*5.0f*ver);
		}
		speed = rigidbody.velocity.magnitude*50.0f;
		needle.localRotation = Quaternion.Euler(0.0f,0.0f,-126.0f+speed);
		mph.text = (speed*0.64f).ToString("0000.0");
	}
	
	public void AddCheck(int id)
	{
		checks[id].guiTexture.color = Color.green;
		ch_count++;
	}
	
	public int GetChecks()
	{
		return ch_count;
	}
}