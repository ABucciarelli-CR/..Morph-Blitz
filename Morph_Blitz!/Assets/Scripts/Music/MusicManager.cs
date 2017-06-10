using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Musica
{
	public class MusicManager : MonoBehaviour 
	{
		public AudioClip BG_Menu;
		public AudioClip BG_Tutorial;
		public AudioClip BG_Lv1;
		public AudioClip BG_Lv2;

		public Slider AudioSlider;

		public Toggle OnOffButton;

		private AudioClip[] _MusicList;

		private AudioSource _MusicPlayer;

		private int _musicPlayed;//to check while music we have active

		void Awake()
		{

			DontDestroyOnLoad (gameObject);

			if (FindObjectsOfType (GetType ()).Length > 1)
			{
				Destroy (gameObject);
			}

		}

		void Start()
		{
			_MusicList = new AudioClip[] 
			{
				BG_Menu,
				BG_Tutorial,
				BG_Lv1,
				BG_Lv2
			};

			_MusicPlayer = GetComponent<AudioSource> ();

			_musicPlayed = 100;
		}


		void Update () 
		{
			if(SceneManager.GetActiveScene ().buildIndex == 1)
			{
				if (AudioSlider == null) 
				{
					AudioSlider = Slider.FindObjectOfType<Slider>();
				}

				if(OnOffButton == null)
				{
					OnOffButton = Toggle.FindObjectOfType<Toggle>();
				}

				if (OnOffButton.isOn)
				{
					_MusicPlayer.volume = AudioSlider.value;
				} 
				else
				{
					_MusicPlayer.volume = 0;
				}

			}

			if (CheckIfOk()) 
			{
				if ((SceneManager.GetActiveScene ().buildIndex - 1) <= 0) 
				{
					if (!_MusicPlayer.isPlaying) 
					{
						//Debug.Log ("I'm Play First!");
						_MusicPlayer.clip = _MusicList [0];
						_musicPlayed = 0;
						_MusicPlayer.Play ();
					}
				} 
				else
				{
					//Debug.Log ("I'm Play Second!");
					_MusicPlayer.clip = _MusicList [SceneManager.GetActiveScene ().buildIndex - 1];
					_musicPlayed = SceneManager.GetActiveScene ().buildIndex - 1;
					_MusicPlayer.Play ();
				}
			}
		}

		public bool CheckIfOk()
		{
			//Debug.Log ("I'm Checking!");
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
}
