using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruttibileConRosso : MonoBehaviour
{

	public GameObject explosion;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag ("PlayerMod3"))
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

		}
	}
}