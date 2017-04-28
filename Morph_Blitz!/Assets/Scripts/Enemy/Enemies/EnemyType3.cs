using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : EnemyGlobal
{
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.Find ("Catalizer");
		_rb = GetComponent<Rigidbody> ();
		EnemyActivator = GameObject.Find ("EnemySpawnController");
	}

	// Update is called once per frame
	void Update ()
	{
		if (transform.parent != null) 
		{
			if (!EnemyActivator.gameObject.CompareTag ("EnemyType3ON")) 
			{
				_rb.isKinematic = false;
				gameObject.layer = 9;
			}
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Body" && transform.parent == null) 
		{
			if (EnemyActivator.gameObject.CompareTag ("EnemyType3ON")) 
			{
				transform.parent = Player.transform;
				_rb.isKinematic = true;
				gameObject.layer = 11;
			}
		}
	}
}