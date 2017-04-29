using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyType1ON
/*
[RequireComponent(typeof (Player_Controller))]
public class Player_PowerDown : Player_Controller 
{

/// <summary>
	/// PrincipalBody <--- Body
	/// EnemySpawn <--- EnemySpawnController
/// </summary>
	
	[HideInInspector]public GameObject catalizer;//define the catalizer

	private int _childNum = 0;//counter of child

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
		catalizer = GameObject.Find ("Catalizer");
	}

	// Update is called once per frame
	void Update () 
	{
		_childNum = catalizer.transform.childCount;
	}

	public override void Modifier()
	{
		//if mod1 ON
		if (PrincipalBody.gameObject.CompareTag ("PlayerMod1")) 
		{
			Debug.Log ("boh");
			//if ENEMYTYPE1ON
			if (EnemySpawn.gameObject.CompareTag ("EnemyType1ON")) 
			{
				if ((PlayerAdherence - (_childNum * _BlueDepoweredAdherence)) > MinAdherence) 
				{
					adherence = PlayerAdherence - (_childNum * _BlueDepoweredAdherence);
				}
				else
				{
					adherence = MinAdherence;
				}

				if ((MaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity)) > MinAngularVelocity) 
				{
					maxRotate = MaxAngularVelocity - (_childNum * _BlueDepoweredMaxAngularVelocity);
				}
				else
				{
					maxRotate = MinAngularVelocity;
				}
					
				if ((MaxVelocity - (_childNum * _BlueDepoweredMaxVelocity)) > MinVelocity) 
				{
					maxVelocity = MaxVelocity - (_childNum * _BlueDepoweredMaxVelocity);
				}
				else
				{
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
				adherence = PlayerAdherence;
				maxRotate = MaxAngularVelocity;
				maxVelocity = MaxVelocity;
			}

			//end playermod1Modifier
		}

		//if mod2 ON
		if (PrincipalBody.gameObject.CompareTag ("PlayerMod2")) 
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
		if (PrincipalBody.gameObject.CompareTag ("PlayerMod3")) 
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
}
*/