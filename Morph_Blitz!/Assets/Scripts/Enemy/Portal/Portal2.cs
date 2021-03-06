﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : PortalTriggerGeneral 
{
	public GameObject portalON; //define Portal Active
	public GameObject portalOFF; //define Portal Dectivate

	// Use this for initialization
	void Start () 
	{
		EnemyActivator = GameObject.Find ("EnemySpawnController");

		portalON.SetActive (true);
		portalOFF.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (triggered && !GameObject.FindWithTag("PlayerMod2")) 
		{
			EnemyActivator.gameObject.tag = "EnemyType2ON";
			gameObject.SetActive (false);
			portalON.SetActive (false);
			portalOFF.SetActive (true);
		}
		else if (triggered && GameObject.FindWithTag ("PlayerMod2")) 
		{
			EnemyActivator.gameObject.tag = "Untagged";
			portalOFF.SetActive (false);
			portalON.SetActive (true);
		}
	}
}