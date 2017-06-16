using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailAppears : MonoBehaviour 
{
	public TrailController trailcontroller;

	public float TrailLifetime = .5f;

	private GameObject _trails;
	private GameObject _playerBody;
	private Rigidbody _rb;

	// Use this for initialization
	void Start ()
	{
		switch(gameObject.name)
		{
		case "VisibleBody_1":

			Debug.Log ("Body 1");
			_trails = GameObject.Find ("Body1Trail");
			break;

		case "VisibleBody_2":

			Debug.Log ("Body 2");
			_trails = GameObject.Find ("Body2Trail");
			break;

		case "VisibleBody_3":

			Debug.Log ("Body 3");
			_trails = GameObject.Find ("Body2Trail");
			break;

		default:
			Debug.Log ("Nothing Body");
			break;
			
		}

		_playerBody = GameObject.Find ("Body");

		_rb = _playerBody.GetComponent<Rigidbody> ();

		foreach (TrailRenderer tr in trailcontroller.trail)
		{
			tr.time = 0;
		}
		//trailcontroller.trailLife. = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_rb.velocity.magnitude >= 20)
		{
			foreach (TrailRenderer tr in trailcontroller.trail)
			{
				tr.time = TrailLifetime;
			}
		} 
		else 
		{
			foreach (TrailRenderer tr in trailcontroller.trail)
			{
				if (tr.time > 0) 
				{
					tr.time -= .1f * (Time.deltaTime * 10);
				}
			}
		}
	}
}
