using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour 
{

	[SerializeField] private float _MovePower = 9; // The force added to move
	[SerializeField] private float _SmoothPower = 0.97f; // The power of smooth
	[SerializeField] private float _MaxVelocity = 100; // The time of smooth
	[SerializeField] private float _RotatePower = 9; // The force added to rotate
	[SerializeField] private float _MaxAngularVelocity = 1; // The maximum velocity the player can rotate at.

	private Rigidbody _Rigidbody;

	private void Start()
	{
		_Rigidbody = GetComponent<Rigidbody>();
	}
		
	public void Move( float _move, float _rot)
	{
		//Rotate player
		if (_rot != 0) 
		{
			_Rigidbody.AddRelativeTorque(0, _rot * (_RotatePower * 10), 0);
			if (_Rigidbody.angularVelocity.magnitude > _MaxAngularVelocity) 
			{
				_Rigidbody.angularVelocity = _Rigidbody.angularVelocity.normalized * _MaxAngularVelocity;
			} 
		}
		else
		{
			_Rigidbody.angularVelocity *= _SmoothPower;
		}

		//Move Player
		if (_move != 0) 
		{
			_Rigidbody.AddRelativeForce (0, 0, _move * (_MovePower * 10));
			if (_Rigidbody.velocity.magnitude > _MaxVelocity) 
			{
				_Rigidbody.velocity = _Rigidbody.velocity.normalized * _MaxVelocity;
			} 
		}
		else
		{
			_Rigidbody.velocity *= _SmoothPower;
		}
	}
}

