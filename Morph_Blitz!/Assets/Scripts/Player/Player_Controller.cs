using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour 
{
	public Player_PowerDown _playerPowerDown;//create a reference to powerDownScript

	public GameObject PrincipalBody;//define the principalBody
	public GameObject EnemySpawn; //define the enemy controller

	private Rigidbody _Rigidbody;//define rigidbody

	[SerializeField] private float _SmoothPower = 0.97f; // The power of smooth

	[Header("Minimal Valor of Player's attribute")]
	public float MinVelocity = 50;
	public float MinAngularVelocity = .1f;
	public float MinAdherence = 0;

	//player modificator with enemy attached
	[HideInInspector]public float velocityModifier = 0;//the modifier of velocity with the enemy
	[HideInInspector]public float angularVelocityModifier = 0;//the modifier of angular velocity with the enemy
	[HideInInspector]public float adherenceModifier = 0;//the modifier of adherence with the enemy

	//1st form
	[Header("Variable of 1st Form")]
	[SerializeField] private float _MovePower = 9; // The force added to move
	[SerializeField] private float _RotatePower = 11.5f; // The force added to rotate
	public float MaxVelocity = 100; // The max velocity the player can do
	public float MaxAngularVelocity = 1.5f; // The maximum velocity the player can rotate at.
	public float PlayerAdherence = 0; // The Adherence of the player

	[Header("Variable of 2nd Form")]
	//2nd form
	[SerializeField] private float _YellowMovePower = 15; // The force added to move in 2nd mode
	[SerializeField] private float _YellowRotatePower = .1f; // The force added to rotate in 2nd mode
	public float YellowMAXVelocity = 150; // The max velocity in 2nd mode
	public float YellowMaxAngularVelocity = .2f; // The maximum velocity the player can rotate at in 2nd mode
	public float YellowMAXAdherence = 1; // The max Adherence in 2nd mode

	[Header("Variable of 3rd Form")]
	//3rd form
	[SerializeField] private float _RedMovePower = 3; // The force added to move in 3rd mode
	[SerializeField] private float _RedRotatePower = 9; // The force added to rotate in 3rd mode
	public float RedMAXVelocity = 60; // The max velocity in 3rd mode
	public float RedMAXAngularVelocity = 1; // The maximum velocity the player can rotate at in 3rd mode
	public float RedMAXAdherence = 2; // The max Adherence in 3rd mode


	private float _rotate = 0;//the rotation power of the player
	private float _velocity = 0;//the velocity of the player
	[HideInInspector]public float maxRotate = 0;//the max rotation of the player
	[HideInInspector]public float maxVelocity = 0;//the max velocity of the player
	[HideInInspector]public float adherence = 0;//the adherence of the player

	private void Awake()
	{
		PrincipalBody = GameObject.Find ("Body");
		EnemySpawn = GameObject.Find ("EnemySpawnController");
		_Rigidbody = GetComponent<Rigidbody> ();
	}

	private void Update()
	{
	}

	public virtual void Modifier(){}

	public void Move( float _move, float _rot)
	{
		

		//compare the tag for see what kind we have
		if(PrincipalBody.gameObject.CompareTag("PlayerMod1"))
		{
			_rotate = _rot * (_RotatePower * 10);
			_velocity = _move * (_MovePower * 10);
		}
		else if(PrincipalBody.gameObject.CompareTag("PlayerMod2"))
		{

			_rotate = _rot * (_YellowRotatePower * 5);
			_velocity = _move * (_YellowMovePower * 10);
		}
		else if(PrincipalBody.gameObject.CompareTag("PlayerMod3"))
		{

			_rotate = _rot *(_RedRotatePower * 10);
			_velocity = _move *(_RedMovePower * 10);
		}

		//Rotate player
		if (_rot != 0) 
		{
			_Rigidbody.AddRelativeTorque(0, _rotate, 0);
			if (_Rigidbody.angularVelocity.magnitude > maxRotate) 
			{
				_Rigidbody.angularVelocity = _Rigidbody.angularVelocity.normalized * maxRotate;
			} 
		}
		else
		{
			_Rigidbody.angularVelocity *= _SmoothPower;
		}

		//Move Player
		if (_move != 0) 
		{
			_Rigidbody.AddRelativeForce (0, 0, _velocity);
			if (_Rigidbody.velocity.magnitude > maxVelocity) 
			{
				_Rigidbody.velocity = _Rigidbody.velocity.normalized * maxVelocity;
			} 
		}
		else
		{
			_Rigidbody.velocity *= _SmoothPower;
		}

		//player Adherence
		_Rigidbody.AddRelativeForce (0, -adherence, 0);
	}

}

