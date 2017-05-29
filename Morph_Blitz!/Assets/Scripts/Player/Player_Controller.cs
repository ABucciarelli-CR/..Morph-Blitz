using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player_Change))]

public class Player_Controller : MonoBehaviour 
{
	/// player power down variables//////////////////////////////////
	[HideInInspector]public GameObject catalizer;//define the catalizer

	private RaycastHit _hit;

	//private Collider _colType1;
	//private Collider _colType2;
	//private Collider _colType3;

	//private Player_Change _plyerCng;//define the player_change script

	private int _childNum = 0;//counter of child

	[Header("Gravity")]
	[SerializeField] private float _Gravity = 700;

	[Header("Enemy Depotentation")]
	//enemy type1 PowerDown modifier
	[Header("Enemy Type1")]
	[SerializeField] private float _BlueDepoweredMaxVelocity = 0; //depower the velocity
	[SerializeField] private float _BlueDepoweredMaxAngularVelocity = 0.3f;//depower the angularvelocity
	[SerializeField] private float _BlueDepoweredAdherence = 0;//depower the edherence

	[Header("Enemy Type2")]
	//enemy type2 PowerDown modifier
	[SerializeField] private float _YellowDepoweredMaxVelocity = 4; //depower the velocity
	[SerializeField] private float _YellowDepoweredMaxAngularVelocity = 0;//depower the angularvelocity
	[SerializeField] private float _YellowDepoweredAdherence = 0;//depower the edherence

	[Header("Enemy Type3")]
	//enemy type3 PowerDown modifier
	[SerializeField] private float _RedDepoweredMaxVelocity = 3; //depower the velocity
	[SerializeField] private float _RedDepoweredMaxAngularVelocity = 0;//depower the angularvelocity
	[SerializeField] private float _RedDepoweredAdherence = 0.5f;//depower the edherence
	/////////////////////////////////////////////////////////////////

	[Header("Don't touch, it's MINE!")]
	public GameObject PrincipalBody;//define the principalBody
	public GameObject EnemySpawn; //define the enemy controller

	private Rigidbody _Rigidbody;//define rigidbody
	private Collider _col;//define the collider
	private float maxDistToGround = 2f;

	//---------------------[Header("Smooth Power, simply :D")]
	//---------------------[SerializeField] private float _SmoothPower = 0.97f; // The power of smooth

	[Header("Minimal Valor of Player's attribute")]
	public float MinVelocity = 0;
	public float MinAngularVelocity = 0;
	public float MinAdherence = 0;

	//player modificator with enemy attached
	[HideInInspector]public float velocityModifier = 0;//the modifier of velocity with the enemy
	[HideInInspector]public float angularVelocityModifier = 0;//the modifier of angular velocity with the enemy
	[HideInInspector]public float adherenceModifier = 0;//the modifier of adherence with the enemy

	//1st form
	[Header("Variable of 1st Form")]
	[SerializeField] private float _MovePower = 6; // The force added to move
	[SerializeField] private float _RotatePower = 8f; // The force added to rotate
	public float MaxVelocity = 22; // The max velocity the player can do
	public float MaxAngularVelocity = 0.8f; // The maximum velocity the player can rotate at.
	public float PlayerAdherence = 1f; // The Adherence of the player

	[Header("Variable of 2nd Form")]
	//2nd form
	[SerializeField] private float _YellowMovePower = 9; // The force added to move in 2nd mode
	[SerializeField] private float _YellowRotatePower = .1f; // The force added to rotate in 2nd mode
	public float YellowMAXVelocity = 45; // The max velocity in 2nd mode
	public float YellowMaxAngularVelocity = .2f; // The maximum velocity the player can rotate at in 2nd mode
	public float YellowMAXAdherence = 1; // The max Adherence in 2nd mode

	[Header("Variable of 3rd Form")]
	//3rd form
	[SerializeField] private float _RedMovePower = 5; // The force added to move in 3rd mode
	[SerializeField] private float _RedRotatePower = 3; // The force added to rotate in 3rd mode
	public float RedMAXVelocity = 15; // The max velocity in 3rd mode
	public float RedMAXAngularVelocity = 1; // The maximum velocity the player can rotate at in 3rd mode
	public float RedMAXAdherence = 2.8f; // The max Adherence in 3rd mode


	private float _rotate = 0;//the rotation power of the player
	private float _velocity = 0;//the velocity of the player
	[HideInInspector]public float maxRotate = 0;//the max rotation of the player
	[HideInInspector]public float maxVelocity = 0;//the max velocity of the player
	[HideInInspector]public float adherence = 0;//the adherence of the player

	private void Awake()
	{
		PrincipalBody = GameObject.Find ("Body");

		//_colType1 = _plyerCng.Body1.GetComponent<Collider> ();
		//_colType2 = _plyerCng.Body2.GetComponent<Collider> ();
		//_colType3 = _plyerCng.Body3.GetComponent<Collider> ();

		EnemySpawn = GameObject.Find ("EnemySpawnController");
	}

	private void Start()
	{
		_Rigidbody = PrincipalBody.GetComponent<Rigidbody> ();
		_col = PrincipalBody.GetComponent<Collider> ();

		//playerPowerDown
		catalizer = GameObject.Find ("Catalizer");
	}

	private bool isGrounded()
	{
		Physics.Raycast (PrincipalBody.transform.position, PrincipalBody.transform.TransformDirection(Vector3.down), out _hit, Mathf.Infinity);
		if ( _hit.distance >= maxDistToGround)
		{
			return false;
		} 
		else 
		{
			return true;
		}
	}
/*
	private void ChangeCollider()
	{
		if(PrincipalBody.gameObject.CompareTag("PlayerMod1"))
		{
			_col = _colType1;
		}

		else if(PrincipalBody.gameObject.CompareTag("PlayerMod2"))
		{
			_col = _colType2;
		}

		else if(PrincipalBody.gameObject.CompareTag("PlayerMod3"))
		{
			_col = _colType3;
		}
	}*/

	public void Update()
	{
		
	}

	public void FixedUpdate()
	{
		//ChangeCollider ();//change collider if player is changed
		//DontTouchTerrain ();
		///if player IsGrounded

		if (!isGrounded ())
		{
			//Debug.Log ("I'm GROUNDED!");
			_Rigidbody.AddRelativeForce (0, -_Gravity, 0);
		}

		//playerPowerDown-----------------------------------------------------------------------------------------------------------------------
		_childNum = catalizer.transform.childCount;

		//if mod1 ON
		if (PrincipalBody.gameObject.CompareTag ("PlayerMod1")) 
		{
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				if ((PlayerAdherence - (_childNum * _BlueDepoweredAdherence)) > MinAdherence) 
				{
					//Debug.Log ("boh1");
					adherence = PlayerAdherence - (_childNum * _BlueDepoweredAdherence);
				}
				else
				{
					//Debug.Log ("boh2");
					adherence = MinAdherence;
				}

				if ((MaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					//Debug.Log ("boh3");
					maxRotate = MaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity);
				}
				else
				{
					//Debug.Log ("boh4");
					maxRotate = MinAngularVelocity;
				}

				if ((MaxVelocity - (_childNum * _BlueDepoweredMaxVelocity)) > MinVelocity) 
				{
					//Debug.Log ("boh5");
					maxVelocity = MaxVelocity - (_childNum * _BlueDepoweredMaxVelocity);
				}
				else
				{
					//Debug.Log ("boh6");
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				if ((PlayerAdherence - (_childNum * _YellowDepoweredAdherence)) > MinAdherence) 
				{
					adherence = PlayerAdherence - (_childNum * _YellowDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((MaxAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = MaxAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((MaxVelocity - (_childNum * _YellowDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = MaxVelocity - (_childNum * _YellowDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				if ((PlayerAdherence - (_childNum * _RedDepoweredAdherence)) > MinAdherence) 
				{
					adherence = PlayerAdherence - (_childNum * _RedDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((MaxAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = MaxAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((MaxVelocity - (_childNum * _RedDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = MaxVelocity - (_childNum * _RedDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}
				
			//if AllEnemyOFF
			else
			{
				//Debug.Log ("'Ncul!");

				adherence = PlayerAdherence;
				maxRotate = MaxAngularVelocity;
				maxVelocity = MaxVelocity;
			}

			//end playermod1Modifier
		}

		//if mod2 ON
		else if (PrincipalBody.gameObject.CompareTag ("PlayerMod2")) 
		{
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				if ((YellowMAXAdherence - (_childNum * _BlueDepoweredAdherence)) > MinAdherence) 
				{
					adherence = YellowMAXAdherence - (_childNum * _BlueDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((YellowMaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = YellowMaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((YellowMAXVelocity - (_childNum * _BlueDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = YellowMAXVelocity - (_childNum * _BlueDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				if ((YellowMAXAdherence - (_childNum * _YellowDepoweredAdherence)) > MinAdherence) 
				{
					adherence = YellowMAXAdherence - (_childNum * _YellowDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((YellowMaxAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = YellowMaxAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((YellowMAXVelocity - (_childNum * _YellowDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = YellowMAXVelocity - (_childNum * _YellowDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				if ((YellowMAXAdherence - (_childNum * _RedDepoweredAdherence)) > MinAdherence) 
				{
					adherence = YellowMAXAdherence - (_childNum * _RedDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((YellowMaxAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = YellowMaxAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((YellowMAXVelocity - (_childNum * _RedDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = YellowMAXVelocity - (_childNum * _RedDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if AllEnemyOFF
			else
			{
				adherence = YellowMAXAdherence;
				maxRotate = YellowMaxAngularVelocity;
				maxVelocity = YellowMAXVelocity;
			}

			//end playermod2Modifier
		}

		//if mod3 ON
		else if (PrincipalBody.gameObject.CompareTag ("PlayerMod3")) 
		{
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				if ((RedMAXAdherence - (_childNum * _BlueDepoweredAdherence)) > MinAdherence) 
				{
					adherence = RedMAXAdherence - (_childNum * _BlueDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((RedMAXAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = RedMAXAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((RedMAXVelocity - (_childNum * _BlueDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = RedMAXVelocity - (_childNum * _BlueDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				if ((RedMAXAdherence - (_childNum * _YellowDepoweredAdherence)) > MinAdherence) 
				{
					adherence = RedMAXAdherence - (_childNum * _YellowDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((RedMAXAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = RedMAXAngularVelocity - (_childNum * _YellowDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((RedMAXVelocity - (_childNum * _YellowDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = RedMAXVelocity - (_childNum * _YellowDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				if ((RedMAXAdherence - (_childNum * _RedDepoweredAdherence)) > MinAdherence) 
				{
					adherence = RedMAXAdherence - (_childNum * _RedDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((RedMAXAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = RedMAXAngularVelocity - (_childNum * _RedDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}

				if ((RedMAXVelocity - (_childNum * _RedDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = RedMAXVelocity - (_childNum * _RedDepoweredMaxVelocity);
				}
				else
				{
					maxVelocity = MinVelocity;
				}
			}

			//if AllEnemyOFF
			else
			{
				adherence = RedMAXAdherence;
				maxRotate = RedMAXAngularVelocity;
				maxVelocity = RedMAXVelocity;
			}

			//end playermod2Modifier
		}

	}

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

		//Move Player
		if (_move != 0) 
		{
			_Rigidbody.AddRelativeForce (0, 0, _velocity);
			if (_Rigidbody.velocity.magnitude > maxVelocity) 
			{
				_Rigidbody.velocity = _Rigidbody.velocity.normalized * maxVelocity;
			} 
		} 

		//player Adherence
		_Rigidbody.AddRelativeForce (0, -adherence, 0);
	}



	/*
	void OnCollisionExit(Collision col)
	{
		
		_Rigidbody.AddRelativeForce (0, -_Gravity, 0);
		
	}*/

}

