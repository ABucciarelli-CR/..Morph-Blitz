using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : EnemyGlobal
{
	private Rigidbody _rb;
	public float AdherenceModificator = 1;
	public float MaxVelocityModificator = 1;
	public float MaxAngleVelocityModificator = 1;

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
			if (!EnemyActivator.gameObject.CompareTag ("EnemyType1ON")) 
			{
				_rb.isKinematic = false;
				gameObject.layer = 9;
				/*
				transform.parent = null;
				_rb = gameObject.AddComponent<Rigidbody> ();
				_rb.mass = 0.1f;
				*/
			}
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Body" && transform.parent == null) 
		{
			if (EnemyActivator.gameObject.CompareTag ("EnemyType1ON")) 
			{
				transform.parent = Player.transform;
				_rb.isKinematic = true;
				gameObject.layer = 11;
				//Destroy (_rb);
			}
		}
	}
}
