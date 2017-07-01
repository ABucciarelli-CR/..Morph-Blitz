using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Musica
{
	public class LastLevelPortal : MonoBehaviour 
	{

		public GameObject OnOffBlueScreen;

		private SaveManager saveManager;
		private GameObject _save;

		private MusicManager musicManager;
		private GameObject _mscManager;

		private GlobalVariables globalVariables;
		private GameObject _globalVar;

		//private bool _wait = false;

		void Awake()
		{
			_save = GameObject.Find("_SaveManager");
			saveManager = _save.GetComponent<SaveManager> ();

			_mscManager = GameObject.Find ("_MusicManager");
			musicManager = _mscManager.GetComponent<MusicManager> ();

			_globalVar = GameObject.Find("_GlobalVariables");
			globalVariables = _globalVar.GetComponent<GlobalVariables> ();

			OnOffBlueScreen.SetActive (false);
		}

		public void OnTriggerEnter()
		{
			saveManager.Save ();
			globalVariables.noPause = true;
			OnOffBlueScreen.SetActive (true);
			musicManager.ChangeForLast = true;
			StartCoroutine (TimeToClose());
			//_wait = true;
			Time.timeScale = 0;

		}

		IEnumerator TimeToClose()
		{
			yield return new WaitForSecondsRealtime (10);
			//Debug.Log ("FINE!");
			Application.Quit();
			
		}
	}
}
