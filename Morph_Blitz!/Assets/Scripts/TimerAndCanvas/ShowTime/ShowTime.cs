using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour 
{
	public GlobalVariables globalVariables;
	public Text TimeToDo;
	public Text TimeDoing;


	private int Level = 0;//the level we are

	private float _TimeInDoing = 0;//the time we're going to do

	private float[] _levelTimeTodo;
	private float[] _levelTimeDone;

	private GameObject _global;


	void Awake()
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () 
	{
		_global = GameObject.Find("_GlobalVariables");
		Level = SceneManager.GetActiveScene ().buildIndex;
		globalVariables = _global.GetComponent<GlobalVariables> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SceneManager.GetActiveScene ().buildIndex != 0 && SceneManager.GetActiveScene ().buildIndex != 1)
		{
			TimeToDo.gameObject.SetActive (true);
			TimeDoing.gameObject.SetActive (true);
			TimeToDo.text = globalVariables.LevelTimeToDo [SceneManager.GetActiveScene ().buildIndex].ToString();
			if (Level != SceneManager.GetActiveScene ().buildIndex && SceneManager.GetActiveScene ().buildIndex != 2)
			{
				Level = SceneManager.GetActiveScene ().buildIndex;
				globalVariables.LevelTimeDone [Level - 1] = Mathf.Round (_TimeInDoing * 100)/100;
				_TimeInDoing = 0;
			}
		}
		else
		{
			TimeToDo.gameObject.SetActive (false);
			TimeDoing.gameObject.SetActive (false);
		}

		//time update
		_TimeInDoing += Time.deltaTime;
		//Debug.Log (_TimeInDoing);
		TimeDoing.text = (Mathf.Round(_TimeInDoing * 100)/100).ToString ("0.00");
	}
}
