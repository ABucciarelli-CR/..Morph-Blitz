using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGlobal : MonoBehaviour 
{
	[HideInInspector]public GameObject EnemyActivator;//define the enemy activator
	[HideInInspector]public GameObject Player;//define the player
	[HideInInspector]public GameObject Enemy;//define the enemy

	private Rigidbody _rb;

	void Awake ()
	{
		
	}
	// Use this for initialization
	void Start () 
	{

	}
}
