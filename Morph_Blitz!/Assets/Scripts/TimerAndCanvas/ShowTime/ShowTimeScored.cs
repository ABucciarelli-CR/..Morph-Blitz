using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimeScored : MonoBehaviour 
{

	public int level;
	public Text showTime;

	private GlobalVariables globalVariables;
	private GameObject _global;

	void Awake()
	{
		_global = GameObject.Find("_GlobalVariables");
		globalVariables = _global.GetComponent<GlobalVariables> ();
	}


	void Start () 
	{
		showTime.text = globalVariables.LevelTimeDone[level].ToString("0.00");
	}
}
