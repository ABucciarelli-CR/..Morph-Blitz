using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : EnemyGlobal
{
	private Rigidbody _rb;

	void Awake ()
	{
		Enemy = GameObject.Find ("EN3");
	}
	// Use this for initialization
	void Start () 
	{
		_rb = GetComponent<Rigidbody> ();
		Player = GameObject.Find ("Body");
		EnemyActivator = GameObject.Find ("EnemySpawnController");
	}

	// Update is called once per frame
	void Update ()
	{
		if (transform.parent != null) 
		{
			if (!EnemyActivator.gameObject.CompareTag ("EnemyType3ON")) 
			{
				Enemy.transform.parent = null;
				Rigidbody _rb = Enemy.AddComponent<Rigidbody> ();
				_rb.mass = 1;
			}
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Body" && transform.parent == null)
		{
			if (EnemyActivator.gameObject.CompareTag ("EnemyType3ON")) 
			{
				Enemy.transform.parent = Player.transform;
				Destroy(_rb);
			}
		}
	}
}
