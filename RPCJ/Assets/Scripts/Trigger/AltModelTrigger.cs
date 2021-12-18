using UnityEngine;
using System.Collections;

public class AltModelTrigger : MonoBehaviour
{
	public Mesh alt_mesh;
	
	public void DoTrigger()
	{
		GetComponent<MeshFilter>().mesh = alt_mesh;
	}
}