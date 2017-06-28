using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBodyPursuer : MonoBehaviour {

	public GameObject BodyToPursue;//define the body to pursue(lo so che probabilmente sta parola non esiste, ma tanto chissene, lo leggo solo io il codice :D)

	private float _bodyForward = 5f;
	private float _upOnBody = .5f;

	private float inFrontOfThePlayer = 0;

	// Use this for initialization
	void Start () 
	{
		BodyToPursue = GameObject.Find ("Body");
	}

	// Update is called once per frame
	void Update () 
	{
		inFrontOfThePlayer = (BodyToPursue.GetComponent<Rigidbody> ().velocity.magnitude * _bodyForward) * (Time.deltaTime);
		transform.localPosition = new Vector3 (0, .5f, inFrontOfThePlayer);
		//Debug.Log ("Pursuing! " + BodyToPursue.transform.position);
		//transform.localRotation = BodyToPursue.transform.localRotation;
	}
}
