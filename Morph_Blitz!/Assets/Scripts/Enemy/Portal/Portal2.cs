using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : PortalTriggerGeneral 
{
	[HideInInspector]public GameObject portalON; //define Portal Active
	[HideInInspector]public GameObject portalOFF; //define Portal Dectivate

	// Use this for initialization
	void Start () 
	{
		portalON = GameObject.Find ("Sphere2On");
		portalOFF = GameObject.Find ("Sphere2Off");

		portalON.SetActive (true);
		portalOFF.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (triggered && !GameObject.FindWithTag("PlayerMod2")) 
		{
			portalON.SetActive (false);
			portalOFF.SetActive (true);
		}
	}
}