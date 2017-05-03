using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Timer : MonoBehaviour 
{

	[SerializeField]private float LevelTestTime = 10;//seconds of test-level
	[SerializeField]private float LevelTutorial = 250;//seconds of Tutorial
	[SerializeField]private float LevelOne = 250;//seconds of 1st level
	[SerializeField]private float LevelTwo = 250;//seconds of 2nd level
	[SerializeField]private float LevelThree = 250;//seconds of 3rd level

	private float timer;

	Scene scene;


	void Start () 
	{
		scene = SceneManager.GetActiveScene ();
		if(scene.name == "TestLevel")
		{
			timer = LevelTestTime;
		}
		else if(scene.name == "Tutorial")
		{
			timer = LevelTutorial;
		}
		else if(scene.name == "LV1")
		{
			timer = LevelOne;
		}
		else if(scene.name == "LV2")
		{
			timer = LevelTwo;
		}
		else if(scene.name == "LV3")
		{
			timer = LevelThree;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			Debug.Log ("END");
		}
	}
}
