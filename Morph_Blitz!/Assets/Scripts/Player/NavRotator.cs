using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[RequireComponent(typeof (Player_Controller))]
public class NavRotator : MonoBehaviour 
{
	[SerializeField] private GameObject _Body; //define Body
	[SerializeField] private GameObject _Body1; //define 1 form Body
	[SerializeField] private GameObject _Body2; //define 2 form Body
	[SerializeField] private GameObject _Body3; //define 3 form Body
	[SerializeField] private float _RotateVelocity = 1f; //velocity to rotate
	[SerializeField] private float _MaxAngleRotate = 10f; //velocity to rotate
	[SerializeField] private float _MaxAngularVelocity = 500; // The maximum velocity the player can rotate at.

	private float _rotation = 0f;

	public void Update()
	{
		Rotate ();
	}

	//rotate Body
	public void Rotate(GameObject body ,float _rot)
	{
		//calcolate rotation
		if (_rot == 0)
		{
			if (_rotation < 0) 
			{
				_rotation += _RotateVelocity * Time.unscaledDeltaTime;
				_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

				//Rotate player
				body.transform.localEulerAngles = new Vector3( body.transform.localEulerAngles.x, body.transform.localEulerAngles.y, -_rotation);

			} 
			else if (_rotation > 0) 
			{
				_rotation += _RotateVelocity * Time.unscaledDeltaTime;
				_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

				//Rotate player
				body.transform.localEulerAngles = new Vector3( body.transform.localEulerAngles.x, body.transform.localEulerAngles.y, -_rotation);

			}
		} 
		else 
		{

			//if player rotate, rotate
			_rotation += _rot * _RotateVelocity * Time.deltaTime;
			_rotation = Mathf.Clamp (_rotation, -_MaxAngleRotate, _MaxAngleRotate);

			//Rotate player
			body.transform.Rotate(0f, 0f, _rot * _RotateVelocity * Time.deltaTime);
			//_Body.transform.localEulerAngles = new Vector3( _Body.transform.localEulerAngles.x, _Body.transform.localEulerAngles.y, -_rotation);

		}


	}

}
*/