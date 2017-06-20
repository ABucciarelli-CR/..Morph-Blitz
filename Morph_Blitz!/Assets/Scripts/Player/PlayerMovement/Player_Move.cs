using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

[RequireComponent(typeof (Player_Controller))]
[RequireComponent(typeof (NavRotator))]
public class Player_Move : MonoBehaviour 
{

	private Player_Controller m_Player; // the car controller we want to use
	private Player_Change m_PlayerChange; // the change tipe script
	private NavRotator m_NavRotator;//the rotator of player

	private void Awake()
	{
		// get the car script we need
		m_Player = GetComponent<Player_Controller>();
		m_PlayerChange = GetComponent<Player_Change> ();
		m_NavRotator = GetComponent<NavRotator> ();

	}


	private void Update()
	{
		// pass the input to the car
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		bool Jkey = Input.GetButtonDown ("Change1");
		bool Kkey = Input.GetButtonDown ("Change2");
		bool Lkey = Input.GetButtonDown ("Change3");

		m_Player.Move (v, h);
		m_PlayerChange.Changing (Jkey, Kkey, Lkey);
		m_NavRotator.Rotate (h);
	}
}
