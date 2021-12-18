using UnityEngine;
using System.Collections;

public class OldFPSControl : MonoBehaviour
{
	public float speed = 0.5f;
	public float turn_speed = 2.0f;
	public float jump_speed = 2.0f;
	public float gravity = 10.0f;
	float hor, ver;
	CharacterController control;
	Vector3 move_dir = new Vector3(0f,0f,0f);
	bool grounded = false;
	bool run = false;
	
	void Awake()
	{
		control = GetComponent<CharacterController>();
	}
	
	void FixedUpdate()
	{
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");
		run = Input.GetButton("Run/Sprint");
		if(run)
		{
			hor *= 2.0f;
			ver *= 2.0f;
		}
		transform.Rotate(0f, hor * turn_speed, 0f);
		move_dir.z = ver * speed;
		move_dir.y -= gravity * Time.deltaTime;
		if(Input.GetButton("Jump") && grounded)
			move_dir.y = jump_speed;
		control.Move(transform.TransformDirection(move_dir));
		grounded = (control.Move(move_dir * Time.deltaTime) & CollisionFlags.Below) != 0;
	}
}