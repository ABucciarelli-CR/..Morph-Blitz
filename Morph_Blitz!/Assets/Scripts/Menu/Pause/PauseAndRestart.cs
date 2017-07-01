using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndRestart : MonoBehaviour
{

	public GameObject HidePause;


	private ShowTime showTime;
	private GameObject _timeCanvas;

	private GlobalVariables globalVariables;
	private GameObject _globalVar;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}

		_timeCanvas = GameObject.Find("Time_Canvas");
		showTime = _timeCanvas.GetComponent<ShowTime> ();

		_globalVar = GameObject.Find("_GlobalVariables");
		globalVariables = _globalVar.GetComponent<GlobalVariables> ();

		HidePause.SetActive (false);
	}

	public void Update()
	{
		bool _pauseButton = Input.GetButtonDown ("Pause");

		if (_pauseButton && SceneManager.GetActiveScene ().buildIndex != 0 && SceneManager.GetActiveScene ().buildIndex != 1 && globalVariables.noPause == false)
		{
			Pause ();
		}
		/*
		if(Input.GetKeyDown("k"))
		{
			Restart();
			Debug.Log ("Rest");
		}*/
	}

	public void Pause()
	{
		Time.timeScale = 0;
		HidePause.SetActive (true);
	}

	public void Restart()
	{
		Time.timeScale = 1;
		HidePause.SetActive (false);
	}
		
	public void GoToThisLevel()
	{
		showTime.timeInDoing = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void GoToLevel (int lastLevel)
	{
		SceneManager.LoadScene (lastLevel);
	}
}
