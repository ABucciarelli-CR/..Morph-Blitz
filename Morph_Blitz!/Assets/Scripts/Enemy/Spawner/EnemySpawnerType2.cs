using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerType2 : MonoBehaviour 
{
	[HideInInspector]public GameObject EnemyActivator;//define the enemy activator
	[SerializeField]private float _SpawnTime = 0f;

	private float _timer = 0;

	public float WaitingTime = 1;

	public GameObject Enemy;

	// Use this for initialization
	void Awake ()
	{

		EnemyActivator = GameObject.Find ("EnemySpawnController");

	}

	// Update is called once per frame
	void Update () 
	{
		_timer += Time.deltaTime;
		if (EnemyActivator.gameObject.CompareTag ("EnemyType2ON") && _timer >= WaitingTime) 
		{
			_timer = 0;
			InvokeRepeating ("Spawn", _SpawnTime, _SpawnTime);
		}
	}

	void Spawn ()
	{
		Instantiate (Enemy, transform.position + new Vector3 (0, 2, 0), transform.rotation);
	}
}
