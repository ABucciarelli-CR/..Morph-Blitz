using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalizer_Body_Pursuer : MonoBehaviour 
{

	public GameObject BodyToPursue;//define the body to pursue(lo so che probabilmente sta parola non esiste, ma tanto chissene, lo leggo solo io il codice :D)

	// Use this for initialization
	void Start () 
	{
		BodyToPursue = GameObject.Find ("Body");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localPosition = BodyToPursue.transform.localPosition;
		//Debug.Log ("Pursuing! " + BodyToPursue.transform.position);
		transform.localRotation = BodyToPursue.transform.localRotation;
	}
}
