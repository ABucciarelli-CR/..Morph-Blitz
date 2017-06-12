using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDepotentiator
{
	public class EnemyType2 : EnemyGlobal
	{

		void  Awake () 
		{
			gameObject.layer = 8;
			EnemyType = "EnemyType2ON";
		}
	}
}