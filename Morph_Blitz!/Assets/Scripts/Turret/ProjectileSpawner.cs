using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject spawnPoint;
	public float spawnTime = 3f;

	private GameObject _EN;
	private float _comparedTime = 3f;
	[SerializeField]private float _shootPower = 50f;

	void Update () 
	{
		if (_comparedTime <=0) 
		{
			_EN = Instantiate (enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
			_EN.GetComponent<Rigidbody> ().AddRelativeForce (transform.forward * _shootPower);
			_comparedTime = spawnTime;
		}
		_comparedTime -= Time.deltaTime;
	}

}
