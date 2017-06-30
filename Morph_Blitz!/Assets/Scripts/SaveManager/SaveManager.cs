using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour 
{

	private int _level = 0;
	private GlobalVariables globalVariables;
	private GameObject _global; 

	void Awake()
	{
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}

		_global = GameObject.Find("_GlobalVariables");
		globalVariables = _global.GetComponent<GlobalVariables> ();
	}

	void Update()
	{
		if (_level != SceneManager.GetActiveScene ().buildIndex)
		{
			//Debug.Log ("I'm Saving!");
			_level = SceneManager.GetActiveScene ().buildIndex;
			SaveAndLoad.Save (globalVariables);
		}
	}
}
