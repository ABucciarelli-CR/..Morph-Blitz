using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{

	public TrailRenderer[] trail;

	// Use this for initialization
	void Awake () 
	{
		trail = GetComponentsInChildren<TrailRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
