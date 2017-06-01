using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruttibileConRosso : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider col)
		{
		if (col.gameObject.CompareTag ("PlayerMod3") || col.gameObject.GetComponent<Rigidbody> ().mass == 0.01f) {
			//Destroy (gameObject);
			gameObject.GetComponent<Rigidbody> ().mass = 0.01f;

		} else 
		{
			gameObject.GetComponent<Rigidbody> ().mass = 10f;
		}

		}
}