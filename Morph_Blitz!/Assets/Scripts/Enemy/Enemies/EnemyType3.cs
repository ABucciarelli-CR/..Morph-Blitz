using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDepotentiator
{
	public class EnemyType3 : EnemyGlobal
	{
		void Awake () 
		{
			gameObject.layer = 8;
			EnemyType = "EnemyType3ON";
		}

	}
}