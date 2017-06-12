using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDepotentiator
{
	public class EnemyType1 : EnemyGlobal
	{
		void Awake () 
		{
			gameObject.layer = 8;
			EnemyType = "EnemyType1ON";
		}

	}
}
