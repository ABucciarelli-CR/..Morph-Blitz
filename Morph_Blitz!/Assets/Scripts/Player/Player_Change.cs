using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player_Move))]
public class Player_Change : MonoBehaviour 
{
	private Player_Controller m_Player; // the car controller we want to use

	[HideInInspector] public bool typeForm1;//define of the 1st form of player
	[HideInInspector] public bool typeForm2;//define of the 2nd form of player
	[HideInInspector] public bool typeForm3;//define of the 3rd form of player

	public GameObject PrincipalBody;//define the principalBody
	public GameObject Body1; //define Body type 1 object
	public GameObject Body2; //define Body type 2 object
	public GameObject Body3; //define Body type 3 object


	// Use this for initialization
	void awake()
	{
		//Body1 = GameObject.Find ("VisibleBody_1");
		//Body2 = GameObject.Find ("VisibleBody_2");
		//Body3 = GameObject.Find ("VisibleBody_3");
	}

	void Start () 
	{

		PrincipalBody = GameObject.Find ("Body");

		PrincipalBody.gameObject.tag = "PlayerMod1";
		Body1.SetActive (true);
		Body2.SetActive (false);
		Body3.SetActive (false);
	}
	
	// Update is called once per frame
	public void FixedUpdate ()
	{
		
	}

	public void Changing (bool JKey, bool Kkey, bool Lkey)
	{
		if (JKey && !Kkey && !Lkey) 
		{
			PrincipalBody.gameObject.tag = "PlayerMod1";

			typeForm1 = true;
			typeForm2 = false;
			typeForm3 = false;

			Body2.SetActive (false);
			Body3.SetActive (false);
			Body1.SetActive (true);
		}
		else if (!JKey && Kkey && !Lkey) 
		{
			PrincipalBody.gameObject.tag = "PlayerMod2";

			typeForm1 = false;
			typeForm2 = true;
			typeForm3 = false;

			Body1.SetActive (false);
			Body3.SetActive (false);
			Body2.SetActive (true);
		}
		else if (!JKey && !Kkey && Lkey) 
		{
			PrincipalBody.gameObject.tag = "PlayerMod3";

			typeForm1 = false;
			typeForm2 = false;
			typeForm3 = true;

			Body1.SetActive (false);
			Body2.SetActive (false);
			Body3.SetActive (true);
		}
	}
}
