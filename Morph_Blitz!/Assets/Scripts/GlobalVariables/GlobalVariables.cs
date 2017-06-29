using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour 
{
	//music
	public float audioVolume = .5f;

	public bool audioOn = true;

	public int changeMusicValue = 0;

	//time
	[Header("Go Away From This Two >:(")]
	public float[] LevelTimeToDo;//the time to do on each level
	public float[] LevelTimeDone;//the time we had do on each level

	//the time of all the piste
	[Header("Time in seconds")]
	public float t_Tutorial = 60f;
	public float t_Level1 = 60f;
	public float t_Level2 = 60f;
	public float t_Level3 = 60f;
	public float t_Level4 = 60f;


	void Awake()
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}
	}

	void Start()
	{
		LevelTimeToDo = new float[]
		{
			0,
			0,
			t_Tutorial,
			t_Level1,
			t_Level2,
			t_Level3,
			t_Level4

		};

		LevelTimeDone = new float[] 
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}
}