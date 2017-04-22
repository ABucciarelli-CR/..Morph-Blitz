﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : EnemyGlobal
{
	private Rigidbody _rb;

	void Awake ()
	{
		Enemy = GameObject.Find ("EN2");
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
			if (!EnemyActivator.gameObject.CompareTag ("EnemyType2ON")) 
			{
				Enemy.transform.parent = null;
				Rigidbody _rb = Enemy.AddComponent<Rigidbody> ();
				_rb.mass = 1;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "Body" && transform.parent == null)
		{
			if (EnemyActivator.gameObject.CompareTag ("EnemyType2ON")) 
			{
				Enemy.transform.parent = Player.transform;
				Destroy(_rb);
			}
		}
	}
}