using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour 
{
	public GlobalVariables globalVariables;
	public SaveManager saveManager;
	public Text TimeToDo;
	public Text TimeDoing;

	public float timeInDoing = 0;//the time we're going to do


	private int Level = 0;//the level we are

	private float[] _levelTimeTodo;
	private float[] _levelTimeDone;

	private GameObject _global;
	private GameObject _save;

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
		Level = SceneManager.GetActiveScene ().buildIndex;

		_global = GameObject.Find("_GlobalVariables");
		globalVariables = _global.GetComponent<GlobalVariables> ();

		_save = GameObject.Find("_SaveManager");
		saveManager = _save.GetComponent<SaveManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SceneManager.GetActiveScene ().buildIndex != 0 && SceneManager.GetActiveScene ().buildIndex != 1)
		{
			TimeToDo.gameObject.SetActive (true);
			TimeDoing.gameObject.SetActive (true);
			TimeToDo.text = globalVariables.LevelTimeToDo [SceneManager.GetActiveScene ().buildIndex].ToString("0.00");
			if (Level != SceneManager.GetActiveScene ().buildIndex && SceneManager.GetActiveScene ().buildIndex != 2)
			{
				Level = SceneManager.GetActiveScene ().buildIndex;

				if(globalVariables.LevelTimeDone [Level - 1] >  Mathf.Round (timeInDoing * 100)/100 || globalVariables.LevelTimeDone [Level - 1] == 0)
				{
					Debug.Log ("SavingTime!");
					globalVariables.LevelTimeDone [Level - 1] = Mathf.Round (timeInDoing * 100)/100;
					saveManager.Save ();
				}

				timeInDoing = 0;
			}
		}
		else
		{
			TimeToDo.gameObject.SetActive (false);
			TimeDoing.gameObject.SetActive (false);
		}

		//time update
		timeInDoing += Time.deltaTime;
		//Debug.Log (_TimeInDoing);
		TimeDoing.text = (Mathf.Round(timeInDoing * 100)/100).ToString ("0.00");
	}
}
