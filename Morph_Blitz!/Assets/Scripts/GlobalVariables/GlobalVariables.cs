using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour 
{
	public float audioVolume = .5f;

	public bool audioOn = true;

	public int changeMusicValue = 0;

	void Awake()
	{

		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}

	}
}