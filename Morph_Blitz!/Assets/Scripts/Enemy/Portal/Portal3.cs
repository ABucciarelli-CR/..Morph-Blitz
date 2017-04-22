﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal3 : PortalTriggerGeneral 
{
	[HideInInspector]public GameObject portalON; //define Portal Active
	[HideInInspector]public GameObject portalOFF; //define Portal Dectivate

	// Use this for initialization
	void Start () 
	{
		EnemyActivator = GameObject.Find ("EnemySpawnController");

		portalON = GameObject.Find ("Sphere3On");
		portalOFF = GameObject.Find ("Sphere3Off");

		portalON.SetActive (true);
		portalOFF.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (triggered && !GameObject.FindWithTag("PlayerMod3")) 
		{
			EnemyActivator.gameObject.tag = "EnemyType3ON";
			portalON.SetActive (false);
			portalOFF.SetActive (true);
		}
		else if (triggered && GameObject.FindWithTag ("PlayerMod3")) 
		{
			EnemyActivator.gameObject.tag = "Untagged";
			portalOFF.SetActive (false);
			portalON.SetActive (true);
		}
	}
}