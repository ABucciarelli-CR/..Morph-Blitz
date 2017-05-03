using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour 
{
	public GameObject enemySpawner;//define the spawner controller
	public GameObject playerSpawner;//define the player spawner
	public GameObject player;//define the player

	// Use this for initialization
	void Start () 
	{
		enemySpawner = GameObject.Find ("EnemySpawnController");
		playerSpawner = GameObject.Find ("PlayerSpawn");
		player = GameObject.Find ("Player(Clone)");
	}

	void Update()
	{
		if (player == null)
		{
			player = GameObject.Find ("Player(Clone)");
		}
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Bananosoh");
		enemySpawner.gameObject.tag = "Untagged";
		player.gameObject.SetActive(false);
		player= null;
		//player.gameObject.transform.position = playerSpawner.gameObject.transform.position;
		//player.gameObject.transform.rotation = playerSpawner.gameObject.transform.rotation;
	}
}
