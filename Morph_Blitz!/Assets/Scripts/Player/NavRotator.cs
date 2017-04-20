using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[RequireComponent(typeof (Player_Controller))]*/
public class NavRotator : MonoBehaviour 
{/*
	[SerializeField] private GameObject _Body; //define Body object
	[SerializeField] private float _RotateVelocity = 1f; //velocity to rotate
	[SerializeField] private float _MaxAngleRotate = 10f; //velocity to rotate
	[SerializeField] private float _MaxAngularVelocity = 500; // The maximum velocity the player can rotate at.

	private float _rotation = 0f;

	//rotate Body
	public void Rotate( float _rot)
	{
		//calcolate rotation
		if (_rot == 0)
		{/*
			if (_rotation < 0) 
			{
				_rotation += _RotateVelocity * Time.unscaledDeltaTime;
				_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

				//Rotate player
				_Body.transform.localEulerAngles = new Vector3( _Body.transform.localEulerAngles.x, _Body.transform.localEulerAngles.y, -_rotation);

			} 
			else if (_rotation > 0) 
			{
				_rotation += _RotateVelocity * Time.unscaledDeltaTime;
				_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

				//Rotate player
				_Body.transform.localEulerAngles = new Vector3( _Body.transform.localEulerAngles.x, _Body.transform.localEulerAngles.y, -_rotation);

			}
		} 
		else 
		{

			//if player rotate, rotate
			/*_rotation += _rot * _RotateVelocity * Time.deltaTime;
			_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

			//Rotate player
			_Body.transform.Rotate(0f, 0f, _rot * _RotateVelocity * Time.deltaTime);
			//_Body.transform.localEulerAngles = new Vector3( _Body.transform.localEulerAngles.x, _Body.transform.localEulerAngles.y, -_rotation);

		}


	}*/

}
