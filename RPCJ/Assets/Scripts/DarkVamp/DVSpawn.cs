using UnityEngine;
using System.Collections;

public class DVSpawn : MonoBehaviour
{
	public float waittime = 5.0f;
	int spawns = 6;
	public GameObject spawnobject;
	System.Random rnd = new System.Random();
	
	public Material[] textures; 
	public Transform target;
	public Transform[] points;
	GameObject tmp;
	
	void Awake()
	{
		StartCoroutine(Wait());
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(waittime);
		StartCoroutine(SpawnTimer());
	}
	
	IEnumerator SpawnTimer()
	{
		do
		{
			yield return new WaitForSeconds(Random.Range(4,8));
			for(int i = 0; i < points.Length; i++)
			{
				tmp = (GameObject)GameObject.Instantiate(spawnobject,points[i].position,points[i].rotation);
				tmp.name = "dv_enemy";
				tmp.renderer.material = textures[rnd.Next(0,textures.Length)];
				tmp.GetComponent<DVveg>().Init(target);
			}
			tmp = null;
			spawns--;
		}
		while(spawns > 0);
		Destroy(gameObject);
	}
}