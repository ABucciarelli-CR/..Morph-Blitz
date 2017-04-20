using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player_Controller))]
public class Player_Change : MonoBehaviour 
{
	private Player_Controller m_Player; // the car controller we want to use

	[SerializeField] private GameObject _Body1; //define Body type 1 object
	[SerializeField] private GameObject _Body2; //define Body type 2 object
	[SerializeField] private GameObject _Body3; //define Body type 3 object


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
