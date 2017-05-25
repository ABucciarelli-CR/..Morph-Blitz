using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject player;

	//[SerializeField]private float _lerp = 3f;//the lerp of the camera

	[SerializeField]private float _height = 2f;//the height of the camera
	[SerializeField]private float _behindPlayer = 4f;//the distance of the camera from the player

	//how much dump
	[SerializeField]private float _heightDumping = 3f;
	[SerializeField]private float _rotationDumping = 3f;
	[SerializeField]private float _behindDumping = 10f;

	//the valor we wont (?)
	//----player
	private float _wantedRotationAngle;
	private float _wantedHeight;
	private float _wantedBehind;

	//----camera
	private float _currentRotationAngle;
	private float _currentHeight;
	private float _currentBehind;

	//the max valors
//	[SerializeField]private float _maxBehind = 7f;

	private Quaternion _currentRotation;


	// Use this for initialization
	void Start () 
	{

	}
	

	void FixedUpdate ()
	{
		if (!player) 
		{
			return;
		}

		//calcolate the correct rotation angles
		_wantedRotationAngle = player.transform.eulerAngles.y;
		_wantedHeight = player.transform.position.y + _height;
		_wantedBehind = player.transform.position.z - _behindPlayer;

		_currentRotationAngle = transform.eulerAngles.y;
		_currentHeight = transform.position.y;
		_currentBehind = transform.position.z;

		//damp rotation around axes y
		_currentRotationAngle = Mathf.LerpAngle (_currentRotationAngle, _wantedRotationAngle, _rotationDumping * Time.deltaTime);

		//damp the height
		_currentHeight = Mathf.LerpAngle (_currentHeight, _wantedHeight, _heightDumping * Time.deltaTime);

		//damp the behind
		_currentBehind = Mathf.LerpAngle (_currentBehind, _wantedBehind, _behindDumping * Time.deltaTime);

		//convert angle into rotation
		_currentRotation = Quaternion.Euler (0, _currentRotationAngle, 0);

		//set position of the camera
		//set distance
		transform.position = player.transform.position;
		transform.position -= _currentRotation * Vector3.forward * _behindPlayer;

		//set height & behind
		transform.position = new Vector3(transform.position.x, _currentHeight, _currentBehind);

		//always look player
		transform.LookAt (player.transform);
	}

}
