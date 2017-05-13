using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject spawnPoint;
	public GameObject EnemySpawn; //define the enemy controller

	public float spawnTime = 3f;

	private GameObject _EN;
	private float _comparedTime = 3f;
	[SerializeField]private float _shootPower = 50f;

	void Start()
	{
		EnemySpawn = GameObject.Find ("EnemySpawnController");
	}

	void Update () 
	{

		if (gameObject.CompareTag ("TowerType1") && EnemySpawn.CompareTag ("EnemyType1ON") || gameObject.CompareTag ("TowerType2") && EnemySpawn.CompareTag ("EnemyType2ON") || gameObject.CompareTag ("TowerType3") && EnemySpawn.CompareTag ("EnemyType3ON")) 
		{
			Debug.Log ("Christiana Capotondi");
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
