using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Musica
{
	public class LevelSelection : MonoBehaviour 
	{
		// Update is called once per frame
		public void GoToLevel (int lastLevel)
		{
			SceneManager.LoadScene (lastLevel);
		}
	}
}
