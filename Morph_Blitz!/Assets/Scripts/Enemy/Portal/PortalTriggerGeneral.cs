using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PortalTriggerGeneral : MonoBehaviour 
{
	[HideInInspector]public bool triggered = false;
	[HideInInspector]public GameObject EnemyActivator;//define the enemy activator
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	void OnTriggerEnter(Collider other)
	{
		triggered = true;
	}

	void OnTriggerExit(Collider other)
	{
		triggered = false;
	}
}
