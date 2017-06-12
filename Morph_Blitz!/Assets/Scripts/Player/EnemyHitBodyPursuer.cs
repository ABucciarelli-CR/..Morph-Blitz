using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBodyPursuer : MonoBehaviour {

	public GameObject BodyToPursue;//define the body to pursue(lo so che probabilmente sta parola non esiste, ma tanto chissene, lo leggo solo io il codice :D)

	private float _upOnBody = .5f;

	// Use this for initialization
	void Start () 
	{
		BodyToPursue = GameObject.Find ("Body");
	}

	// Update is called once per frame
	void Update () 
	{
		transform.localPosition = new Vector3 (BodyToPursue.transform.localPosition.x, BodyToPursue.transform.localPosition.y + _upOnBody, BodyToPursue.transform.localPosition.z);
		//Debug.Log ("Pursuing! " + BodyToPursue.transform.position);
		transform.localRotation = BodyToPursue.transform.localRotation;
	}
}
