using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavRotator : MonoBehaviour 
{
	public Player_Move playerMove;

	//in grades
	public float maxRotation = 5f;

	//other
	public float rotationVelocity = .5f;

	private float _rotation;
	//private int _remainSign = 1;
	private float _toleranceToZero = .2f;
	//public float Hor_Haxes;

	private GameObject allVisibleBody;
	private GameObject catalizer;


	void Awake()
	{
		allVisibleBody = GameObject.Find ("BodyCollector");
		catalizer = GameObject.Find ("Catalizer");
	}

	void Update()
	{

	}

	public void Rotate(float Hor_Axes)
	{

		if(Hor_Axes == 0f)
		{
			if( Mathf.Abs(allVisibleBody.transform.localEulerAngles.z) > _toleranceToZero)
			{
				//Debug.Log ("I'm restabilizing!");
				//Debug.Log (allVisibleBody.transform.localRotation.z);

				if (allVisibleBody.transform.localRotation.z < 0)
				{
					//Debug.Log ("First");
					_rotation += (rotationVelocity * (Time.deltaTime * 10));
				} 
				else 
				{
					//Debug.Log ("Second");
					_rotation -= (rotationVelocity * (Time.deltaTime * 10));
				}


			}
			/*
			else
			{
				//Debug.Log ("EulerAngles" + allVisibleBody.transform.localEulerAngles.z);
				//Debug.Log ("I'm stabilized!");
			}*/
		}
		else
		{
			//_remainSign *= (int)Mathf.Sign (Hor_Axes);
			_rotation += Hor_Axes * (rotationVelocity * (Time.deltaTime * 10));
		}
			
		_rotation = Mathf.Clamp (_rotation, -maxRotation, maxRotation);

		allVisibleBody.transform.localEulerAngles = new Vector3 ( 0, 0, _rotation);
		catalizer.transform.localEulerAngles =  new Vector3 ( catalizer.transform.localEulerAngles.x, catalizer.transform.localEulerAngles.y, _rotation);
	}
}
