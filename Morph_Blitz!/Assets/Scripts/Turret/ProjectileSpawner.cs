using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject spawnPoint;
	public GameObject EnemySpawn; //define the enemy controller
	public float ShootingRange = 10000f;

	private float spawnTime = .35f;

	public RaycastHit _hit;
	public GameObject _EN;
	private float _comparedTime = 0.1f;
	/*[SerializeField]*/private float _shootPower = 4000f;

	void Start()
	{
		EnemySpawn = GameObject.Find ("EnemySpawnController");
	}

	void Update () 
	{
		if (Shoot ()) 
		{
			if (gameObject.CompareTag ("TowerType1") && EnemySpawn.CompareTag ("EnemyType1ON") || gameObject.CompareTag ("TowerType2") && EnemySpawn.CompareTag ("EnemyType2ON") || gameObject.CompareTag ("TowerType3") && EnemySpawn.CompareTag ("EnemyType3ON")) 
			{
				//Debug.Log ("Christiana Capotondi");
				if (_comparedTime <= 0) 
				{
					_EN = Instantiate (enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
					_EN.GetComponent<Rigidbody> ().AddRelativeForce (transform.forward * _shootPower);
					_comparedTime = spawnTime;
				}
				_comparedTime -= Time.deltaTime;
			}
		}
			


	
	}

	public bool Shoot ()
	{
		Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity);
		Debug.DrawLine (spawnPoint.transform.position, _hit.point);

		//Debug.Log (_hit.collider.gameObject.tag);

		if (_hit.transform.CompareTag("Player") && _hit.distance <= ShootingRange)
		{
			return true;
		}
		else 
		{
			return false;
		}
	}


}
