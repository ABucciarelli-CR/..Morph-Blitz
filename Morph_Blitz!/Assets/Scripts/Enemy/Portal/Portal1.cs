using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : PortalTriggerGeneral 
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
		if (triggered && !GameObject.FindWithTag ("PlayerMod1")) 
		{
			EnemyActivator.gameObject.tag = "EnemyType1ON";
			gameObject.SetActive (false);
			portalON.SetActive (false);
			portalOFF.SetActive (true);
		} 
		else if (triggered && GameObject.FindWithTag ("PlayerMod1") && !EnemyActivator.gameObject.CompareTag ("EnemyType1ON")) 
		{
			EnemyActivator.gameObject.tag = "Untagged";
			portalOFF.SetActive (false);
			portalON.SetActive (true);
		}
	}
}
