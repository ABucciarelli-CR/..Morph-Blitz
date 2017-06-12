using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDepotentiator
{
	public abstract class EnemyGlobal : MonoBehaviour 
	{
		[HideInInspector]public GameObject EnemyActivator;//define the enemy activator
		[HideInInspector]public GameObject Player;//define the player
		[HideInInspector]public Rigidbody _rb;//define rigidbody

		[HideInInspector]public float CountDownForNormalLayer = .1f;
		[HideInInspector]public string EnemyType = "Nothing";

		// Use this for initialization
		void Start () 
		{
			Player = GameObject.Find ("Catalizer");
			_rb = GetComponent<Rigidbody> ();
			EnemyActivator = GameObject.Find ("EnemySpawnController");
			_rb.useGravity = false;
		}

		void Update ()
		{
			CountDownForNormalLayer -= Time.deltaTime;
			//Debug.Log (CountDownForNormalLayer);
			if (CountDownForNormalLayer <= 0) 
			{
				//Debug.Log ("Entered");
				if (gameObject.layer == 8) 
				{
					gameObject.layer = 0;
				}

				if (transform.parent != null) 
				{
					if (!EnemyActivator.gameObject.CompareTag (EnemyType)) 
					{
						transform.parent = null;
						_rb.isKinematic = false;
						gameObject.layer = 9;
					}
				}
			}

			if (!EnemyActivator.gameObject.CompareTag (EnemyType))
			{
				gameObject.SetActive (false);
			}
		}

		void OnCollisionEnter (Collision other)
		{
			_rb.useGravity = true;
			if (other.gameObject.name == "Body" && transform.parent == null) 
			{
				if (EnemyActivator.gameObject.CompareTag (EnemyType)) 
				{
					transform.parent = Player.transform;
					_rb.isKinematic = true;
					gameObject.layer = 11;
				}
			}
		}
	}
}