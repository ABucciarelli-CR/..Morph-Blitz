using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUnlockLevel : MonoBehaviour
{
	public int Level;

	private Button button;

	private GlobalVariables globalVariables;
	private GameObject _global; 

	void Awake()
	{
		_global = GameObject.Find("_GlobalVariables");
		globalVariables = _global.GetComponent<GlobalVariables> ();
	}

	void Start () 
	{
		button = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(globalVariables.LevelTimeDone[Level] == 0)
		{
			button.interactable = false;
		}
	}
}
