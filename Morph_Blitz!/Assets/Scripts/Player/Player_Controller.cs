using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player_Change))]

public class Player_Controller : MonoBehaviour 
{
	/// player power down variables//////////////////////////////////
	[HideInInspector]public GameObject catalizer;//define the catalizer

	[Header("Don't touch, it's MINE!")]
	public GameObject PrincipalBody;//define the principalBody
	public GameObject EnemySpawn; //define the enemy controller

	private Rigidbody _Rigidbody;//define rigidbody
	private Collider _col;//define the collider
	private float maxDistToGround = 5f;

	private bool _addExtraGravity;//if player don't collide add it

	private bool _distanceToGround;// the distance to the ground


	//private Collider _colType1;
	//private Collider _colType2;
	//private Collider _colType3;

	//private Player_Change _plyerCng;//define the player_change script

	private int _childNum = 0;//counter of child

	private float _smoothMaxVelocity = 0f;// the smoother of MAXVelocity

	[Header("Smooth the deceleration, simply :D")]
	[SerializeField] private float _DecelerationSmooth = 100f; // The power of the acceleration smooth

	[Header("Gravity")]
	[SerializeField] private float _Gravity = 60;

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
	/*
	private bool isGrounded()
	{

		Physics.Raycast (PrincipalBody.transform.position, PrincipalBody.transform.TransformDirection(Vector3.down), out _hit, maxDistToGround);
		if (_hit.transform.com) 
		{

		}
		return _distanceToGround;
	}*/
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
		/*
		if (isGrounded ())
		{
			Debug.Log ("Tua madre sollevata");
			_Rigidbody.AddRelativeForce (0, -_Gravity, 0);
		}*/

		if(_addExtraGravity)
		{
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
				Depowerator (PlayerAdherence, MaxAngularVelocity, MaxVelocity, _BlueDepoweredAdherence, _BlueDepoweredMaxAngularVelocity, _BlueDepoweredMaxVelocity);
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				Depowerator (PlayerAdherence, MaxAngularVelocity, MaxVelocity, _YellowDepoweredAdherence, _YellowDepoweredMaxAngularVelocity, _YellowDepoweredMaxVelocity);
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				Depowerator (PlayerAdherence, MaxAngularVelocity, MaxVelocity, _RedDepoweredAdherence, _RedDepoweredMaxAngularVelocity, _RedDepoweredMaxVelocity);
			}
				
			//if AllEnemyOFF
			else
			{
				//Debug.Log ("'Ncul!");

				Depowerator (PlayerAdherence, MaxAngularVelocity, MaxVelocity, 0, 0, 0);
				/*
				adherence = PlayerAdherence;
				maxRotate = MaxAngularVelocity;
				maxVelocity = MaxVelocity;*/
			}

			//end playermod1Modifier
		}

		//if mod2 ON
		else if (PrincipalBody.gameObject.CompareTag ("PlayerMod2")) 
		{
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				Depowerator (YellowMAXAdherence, YellowMaxAngularVelocity, YellowMAXVelocity, _BlueDepoweredAdherence, _BlueDepoweredMaxAngularVelocity, _BlueDepoweredMaxVelocity);
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				Depowerator (YellowMAXAdherence, YellowMaxAngularVelocity, YellowMAXVelocity, _YellowDepoweredAdherence, _YellowDepoweredMaxAngularVelocity, _YellowDepoweredMaxVelocity);
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				Depowerator (YellowMAXAdherence, YellowMaxAngularVelocity, YellowMAXVelocity, _RedDepoweredAdherence, _RedDepoweredMaxAngularVelocity, _RedDepoweredMaxVelocity);
			}

			//if AllEnemyOFF
			else
			{
				Depowerator (YellowMAXAdherence, YellowMaxAngularVelocity, YellowMAXVelocity, 0, 0, 0);
				/*
				adherence = YellowMAXAdherence;
				maxRotate = YellowMaxAngularVelocity;
				maxVelocity = YellowMAXVelocity;*/
			}

			//end playermod2Modifier
		}

		//if mod3 ON
		else if (PrincipalBody.gameObject.CompareTag ("PlayerMod3")) 
		{
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				Depowerator (RedMAXAdherence, RedMAXAngularVelocity, RedMAXVelocity, _BlueDepoweredAdherence, _BlueDepoweredMaxAngularVelocity, _BlueDepoweredMaxVelocity);
			}

			//if ENEMYTYPE2ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType2ON")) 
			{
				Depowerator (RedMAXAdherence, RedMAXAngularVelocity, RedMAXVelocity, _YellowDepoweredAdherence, _YellowDepoweredMaxAngularVelocity, _YellowDepoweredMaxVelocity);
			}

			//if ENEMYTYPE3ON
			else if (EnemySpawn.gameObject.CompareTag ("EnemyType3ON")) 
			{
				Depowerator (RedMAXAdherence, RedMAXAngularVelocity, RedMAXVelocity, _RedDepoweredAdherence, _RedDepoweredMaxAngularVelocity, _RedDepoweredMaxVelocity);
			}

			//if AllEnemyOFF
			else
			{
				Depowerator (RedMAXAdherence, RedMAXAngularVelocity, RedMAXVelocity, 0, 0, 0);
				/*
				adherence = RedMAXAdherence;
				maxRotate = RedMAXAngularVelocity;
				maxVelocity = RedMAXVelocity;*/
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

			_rotate = _rot * (_YellowRotatePower * 10);
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
			Debug.Log ("La mamma puttana che si ruota");
			_Rigidbody.AddRelativeTorque(0, _rotate, 0);
			if (_Rigidbody.angularVelocity.magnitude > maxRotate) 
			{
				_Rigidbody.angularVelocity = _Rigidbody.angularVelocity.normalized * maxRotate;
			} 
		}

		//Move Player
		if (_move != 0) 
		{
			/*
			Debug.Log ("First of IsMoreSlowThanBefore");
			if(IsMoreSlowThanBefore(_velocity))
			{
				Debug.Log ("In IsMoreSlowThanBefore");
				VelocitySmoother (_velocity);
			}*/
			Debug.Log ("La mamma puttana che si muove");
			_Rigidbody.AddRelativeForce (0, 0, _velocity);
			if (_Rigidbody.velocity.magnitude > maxVelocity) 
			{
				_Rigidbody.velocity = _Rigidbody.velocity.normalized * maxVelocity;
			} 
		} 

		//player Adherence
		_Rigidbody.AddRelativeForce (0, -adherence, 0);
	}

	//do the power-down of the player
	public void Depowerator(float plyrAdherence, float plyrAngularVelocity,float plyrVelocity, float depAdherence, float depAngularVelocity, float depVelocity)
	{
		Debug.Log ("My vel = " + plyrVelocity);
		if ((plyrAdherence - (_childNum * depAdherence)) > MinAdherence) 
		{
			adherence = plyrAdherence - (_childNum * depAdherence);
		}
		else
		{
			adherence = MinAdherence;
		}

		if ((plyrAngularVelocity - (_childNum * depAngularVelocity)) > MinAngularVelocity) 
		{
			maxRotate = plyrAngularVelocity - (_childNum * depAngularVelocity);
		}
		else
		{
			maxRotate = MinAngularVelocity;
		}

		if ((VelocitySmoother(plyrVelocity) - (_childNum * depVelocity)) > MinVelocity) 
		{
			maxVelocity = VelocitySmoother(plyrVelocity) - (_childNum * depVelocity);
		}
		else
		{
			maxVelocity = MinVelocity;
		}
	}

	public float VelocitySmoother(float maxVel)
	{
		//float _supp_smoothMaxVelocity; //support variable to _smoothMaxVelocity

		if (IsMoreSlowThanBefore (maxVel)) 
		{
			//Debug.Log (_smoothMaxVelocity);
			_smoothMaxVelocity -= (_DecelerationSmooth * (Time.deltaTime * 10));
		} 
		return _smoothMaxVelocity;
	}

	public bool IsMoreSlowThanBefore(float maxVel)
	{
		// check if the maxVel of the player is minor than before
		if (_smoothMaxVelocity >= maxVel)
		{
			//Debug.Log (_smoothMaxVelocity + " true");
			return true;
		}
		else 
		{
			//Debug.Log (_smoothMaxVelocity + " false");
			_smoothMaxVelocity = maxVel;
			return false;
		}
	}


	public void OnCollisionExit()
	{
		Debug.Log ("Tua madre sollevata");
		_addExtraGravity = true;
		//_Rigidbody.AddForce (0, -_Gravity, 0);
	}

	public void OnCollisionStay()
	{
		Debug.Log ("Tua madre atterrata");
		_addExtraGravity = false;
		//_Rigidbody.AddForce (0, -_Gravity, 0);
	}
		
}

