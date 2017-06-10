using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour 
{
	public AudioClip enemyShootSound;

	// Use this for initialization
	void Awake () 
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}
	}

	public AudioClip Clip()
	{
		return enemyShootSound;
	}

}
