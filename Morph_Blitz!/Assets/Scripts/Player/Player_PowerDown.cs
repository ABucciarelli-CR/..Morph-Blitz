using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player_Controller))]
public class Player_PowerDown : Player_Controller 
{

	private int _childNum = 0;//counter of child
	private int _initialChild = 4;//counter of initial child

	[Header("Minimal Valor of Player's attribute")]
	[SerializeField] private float _MinVelocity = 50;
	[SerializeField] private float _MinAngularVelocity = .1f;
	[SerializeField] private float _MinAdherence = 0;

	[Header("Enemy Depotentation")]
	//enemy type1 PowerDown modifier
	[Header("Enemy Type1")]
	[SerializeField] private float _BlueDepoweredMaxVelocity = 0; //depower the velocity
	[SerializeField] private float _BlueDepoweredMaxAngularVelocity = 0;//depower the angularvelocity
	[SerializeField] private float _BlueDepoweredAdherence = 0;//depower the edherence

	[Header("Enemy Type2")]
	//enemy type2 PowerDown modifier
	[SerializeField] private float _YellowDepoweredMaxVelocity = 0; //depower the velocity
	[SerializeField] private float _YellowDepoweredMaxAngularVelocity = 0;//depower the angularvelocity
	[SerializeField] private float _YellowDepoweredAdherence = 0;//depower the edherence

	[Header("Enemy Type3")]
	//enemy type3 PowerDown modifier
	[SerializeField] private float _RedDepoweredMaxVelocity = 0; //depower the velocity
	[SerializeField] private float _RedDepoweredMaxAngularVelocity = 0;//depower the angularvelocity
	[SerializeField] private float _RedDepoweredAdherence = 0;//depower the edherence


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO : fare il danneggiamento dai nemici
		_childNum = PrincipalBody.transform.childCount - _initialChild;


	}
}
