using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float speed = 100f;
	public GameObject SpiningCube;
	public GameObject explosion;
	private bool entered=false;
	private float currentpos;
	private float maxheight = 3.0f;



	void Awake ()
	{
		currentpos = transform.position.y;
	}


	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		if (entered && transform.position.y < currentpos + maxheight) 
		{
			
			transform.position += Vector3.up * Time.deltaTime;
			//SpiningCube = new Vector3 (SpiningCube.transform.position.x, SpiningCube.transform.position.y += Time.deltaTime, SpiningCube.transform.position.z);
		}

	}

	void OnTriggerEnter (Collider col)
	{
		entered = true;
	}

	void OnCollisionEnter (Collision cubecol)
	{
		if (cubecol.gameObject.CompareTag ("PlayerMod3")) 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
