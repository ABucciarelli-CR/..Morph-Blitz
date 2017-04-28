using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGlobal : MonoBehaviour 
{
	[HideInInspector]public GameObject EnemyActivator;//define the enemy activator
	[HideInInspector]public GameObject Player;//define the player
	[HideInInspector]public Rigidbody _rb;//define rigidbody

	void Awake ()
	{
		
	}
	// Use this for initialization
	void Start () 
	{
		_rb = GetComponent<Rigidbody> ();
	}
}
