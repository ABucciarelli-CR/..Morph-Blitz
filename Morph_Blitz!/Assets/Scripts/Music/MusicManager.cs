using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour 
{
	public AudioClip BG_Menu;
	public AudioClip BG_Tutorial;
	public AudioClip BG_Lv1;
	public AudioClip BG_Lv2;

	private AudioClip[] _MusicList;

	private AudioSource _MusicPlayer;

	private int _musicPlayed;//to check while music we have active

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		_MusicList = new AudioClip[] 
		{
			BG_Menu,
			BG_Tutorial,
			BG_Lv1,
			BG_Lv2
		};

		_MusicPlayer = GetComponent<AudioSource> ();

		_musicPlayed = 10;
	}


	void Update () 
	{
		if (CheckIfOk()) 
		{
			if ((SceneManager.GetActiveScene ().buildIndex - 1) <= 0) 
			{
				if (!_MusicPlayer.isPlaying) 
				{
					Debug.Log ("I'm Play First!");
					_MusicPlayer.clip = _MusicList [0];
					_musicPlayed = 0;
					_MusicPlayer.Play ();
				}
			} 
			else
			{
				Debug.Log ("I'm Play Second!");
				_MusicPlayer.clip = _MusicList [SceneManager.GetActiveScene ().buildIndex - 1];
				_musicPlayed = SceneManager.GetActiveScene ().buildIndex - 1;
				_MusicPlayer.Play ();
			}
		}

	}

	public bool CheckIfOk()
	{
		Debug.Log ("I'm Checking!");
		if((_musicPlayed != SceneManager.GetActiveScene ().buildIndex - 1) || (_musicPlayed == 0 && SceneManager.GetActiveScene ().buildIndex - 1 <= 0))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

}
