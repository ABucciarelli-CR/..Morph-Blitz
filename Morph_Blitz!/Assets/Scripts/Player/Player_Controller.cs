using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour 
{
	private Player_PowerDown _playerPowerDown;//create a reference to powerDownScript

	[SerializeField] private float _SmoothPower = 0.97f; // The power of smooth

	//1st form
	[Header("Variable of 1st Form")]
	[SerializeField] private float _MovePower = 9; // The force added to move
	[SerializeField] private float _MaxVelocity = 100; // The max velocity the player can do
	[SerializeField] private float _RotatePower = 11.5f; // The force added to rotate
	[SerializeField] private float _MaxAngularVelocity = 1.5f; // The maximum velocity the player can rotate at.
	[SerializeField] private float _PlayerAdherence = 0; // The Adherence of the player

	[Header("Variable of 2nd Form")]
	//2nd form
	[SerializeField] private float _YellowMovePower = 15; // The force added to move in 2nd mode
	[SerializeField] private float _YellowMAXVelocity = 150; // The max velocity in 2nd mode
	[SerializeField] private float _YellowRotatePower = .1f; // The force added to rotate in 2nd mode
	[SerializeField] private float _YellowMaxAngularVelocity = .2f; // The maximum velocity the player can rotate at in 2nd mode
	[SerializeField] private float _YellowMAXAdherence = 1; // The max Adherence in 2nd mode

	[Header("Variable of 3rd Form")]
	//3rd form
	[SerializeField] private float _RedMovePower = 3; // The force added to move in 3rd mode
	[SerializeField] private float _RedMAXVelocity = 60; // The max velocity in 3rd mode
	[SerializeField] private float _RedRotatePower = 9; // The force added to rotate in 3rd mode
	[SerializeField] private float _RedMAXAngularVelocity = 1; // The maximum velocity the player can rotate at in 3rd mode
	[SerializeField] private float _RedMAXAdherence = 2; // The max Adherence in 3rd mode

	private float _rotate = 0;//the rotation power of the player
	private float _velocity = 0;//the velocity of the player
	private float _maxRotate = 0;//the max rotation of the player
	private float _maxVelocity = 0;//the max velocity of the player
	private float _adherence = 0;//the adherence of the player

	//player modificator with enemy attached
	private float _velocityModifier = 0;//the modifier of velocity with the enemy
	private float _angularVelocityModifier = 0;//the modifier of angular velocity with the enemy
	private float _adherenceModifier = 0;//the modifier of adherence with the enemy

	public GameObject PrincipalBody;//define the principalBody
	public GameObject EnemySpawn; //define the enemy controller

	public GameObject EN1;//define the enemy 1
	//public GameObject EN2;//define the enemy 2
	//public GameObject EN3;//define the enemy 3

	private Rigidbody _Rigidbody;

	private void Awake()
	{
		PrincipalBody = GameObject.Find ("Body");
		EnemySpawn = GameObject.Find ("EnemySpawnController");
		_Rigidbody = GetComponent<Rigidbody>();


		//ignore the collision with enemy
		Physics.IgnoreCollision (EN1.GetComponent<Collider>(), GetComponent<Collider>());
	}

	private void Update()
	{
		if (EnemySpawn.CompareTag ("EnemyType1ON")) 
		{
			_adherence = _PlayerAdherence;

			_maxRotate = _MaxAngularVelocity;
			_maxVelocity = _MaxVelocity;
		} 
		else if (EnemySpawn.CompareTag ("EnemyType2ON")) 
		{
			_adherence = _PlayerAdherence;

			_maxRotate = _MaxAngularVelocity;
			_maxVelocity = _MaxVelocity;
		} 
		else if (EnemySpawn.CompareTag ("EnemyType3ON")) 
		{
			_adherence = _PlayerAdherence;

			_maxRotate = _MaxAngularVelocity;
			_maxVelocity = _MaxVelocity;
		} 
		else 
		{

			_velocityModifier = 0;
			_angularVelocityModifier = 0;
			_adherenceModifier = 0;

			_adherence = _PlayerAdherence;

			_maxRotate = _MaxAngularVelocity;
			_maxVelocity = _MaxVelocity;
		}
	}
		
	public void Move( float _move, float _rot)
	{
		//compare the tag for see what kind we have
		if(PrincipalBody.gameObject.CompareTag("PlayerMod1"))
		{
			_adherence = _PlayerAdherence;

			_maxRotate = _MaxAngularVelocity;
			_maxVelocity = _MaxVelocity;

			_rotate = _rot * (_RotatePower * 10);
			_velocity = _move * (_MovePower * 10);
		}
		else if(PrincipalBody.gameObject.CompareTag("PlayerMod2"))
		{
			_adherence = _YellowMAXAdherence;

			_maxRotate = _YellowMaxAngularVelocity;
			_maxVelocity = _YellowMAXVelocity;

			_rotate = _rot * (_YellowRotatePower * 5);
			_velocity = _move * (_YellowMovePower * 10);
		}
		else if(PrincipalBody.gameObject.CompareTag("PlayerMod3"))
		{
			_adherence = _RedMAXAdherence;

			_maxRotate = _RedMAXAngularVelocity;
			_maxVelocity = _RedMAXVelocity;

			_rotate = _rot *(_RedRotatePower * 10);
			_velocity = _move *(_RedMovePower * 10);
		}

		//Rotate player
		if (_rot != 0) 
		{
			_Rigidbody.AddRelativeTorque(0, _rotate, 0);
			if (_Rigidbody.angularVelocity.magnitude > _maxRotate) 
			{
				_Rigidbody.angularVelocity = _Rigidbody.angularVelocity.normalized * _maxRotate;
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
			if (_Rigidbody.velocity.magnitude > _maxVelocity) 
			{
				_Rigidbody.velocity = _Rigidbody.velocity.normalized * _maxVelocity;
			} 
		}
		else
		{
			_Rigidbody.velocity *= _SmoothPower;
		}

		//player Adherence
		_Rigidbody.AddRelativeForce (0, -_adherence, 0);
	}

}

