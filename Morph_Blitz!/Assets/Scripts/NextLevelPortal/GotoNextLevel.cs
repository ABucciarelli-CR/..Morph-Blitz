using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour 
{
	private int _nextSceneIndex;
	/*
	private AssetBundle myLoadedAssetBundle;
	[SerializeField]private string[] scenePaths;

	// Use this for initialization
	void Start () 
	{
		myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/_Scenes");
		scenePaths = myLoadedAssetBundle.GetAllScenePaths();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
*/

	void Awake()
	{
		_nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Anthareh!");
		//if (SceneManager.sceneCount > _nextSceneIndex) 
		//{
			SceneManager.LoadScene(_nextSceneIndex + 1);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		//}

		/*
		if (other.gameObject.CompareTag ("Player")) 
		{
			SceneManager.LoadScene(scenePaths[2], LoadSceneMode.Single);
			//Application.LoadLevel(Application.loadedLevel + 1);
		}*/
	}
}
