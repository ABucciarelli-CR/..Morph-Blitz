using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour 
{
	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		if (!GameObject.Find ("Body")) 
		{
			Instantiate (Player, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
