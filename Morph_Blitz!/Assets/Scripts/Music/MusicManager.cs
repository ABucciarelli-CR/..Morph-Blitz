using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Musica
{
	public class MusicManager : MonoBehaviour 
	{
		[Header("Boring Music")]
		// musicList 1
		public AudioClip BG_Menu;
		public AudioClip BG_Tutorial;
		public AudioClip BG_Lv1;
		public AudioClip BG_Lv2;

		[Header("ULTRA EPIK FUNKY MUSIKKKK")]
		//musicList 2
		public AudioClip BG_MenuFM;
		public AudioClip BG_TutorialFM;
		public AudioClip BG_Lv1FM;
		public AudioClip BG_Lv2FM;

		[Header("Other")]
		public AudioSource _MusicPlayer;

		public Slider AudioSlider;

		public Toggle OnOffButton;

		public Dropdown ChangeMusic;

		private int _changeMusicValue;

		private AudioClip[] _MusicList1;
		private AudioClip[] _MusicList2;

		private bool _changeTipeOfMusic = false;
		private int _afterChangeMusicValue = 1;//the value of ChangeMusic before the change of the music

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
			_MusicList1 = new AudioClip[] 
			{
				BG_Menu,
				BG_Tutorial,
				BG_Lv1,
				BG_Lv2
			};

			_MusicList2 = new AudioClip[] 
			{
				BG_MenuFM,
				BG_TutorialFM,
				BG_Lv1FM,
				BG_Lv2FM
			};

			_MusicPlayer = GetComponent<AudioSource> ();

			_musicPlayed = 100;
		}


		void Update () 
		{
			if(SceneManager.GetActiveScene ().buildIndex == 1)
			{
				/*
				if (_MusicPlayer.volume != .5f) 
				{
					AudioSlider.value = _MusicPlayer.volume;
				}*/

				if (AudioSlider == null) 
				{
					AudioSlider = Slider.FindObjectOfType<Slider>();
				}

				if(OnOffButton == null)
				{
					OnOffButton = Toggle.FindObjectOfType<Toggle>();
				}

				if(ChangeMusic == null)
				{
					ChangeMusic = Dropdown.FindObjectOfType<Dropdown>();
				}

				if(ChangeMusic != null)
				{
					_changeMusicValue = ChangeMusic.value;
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
				//Debug.Log ("_musicPlayed = " + _musicPlayed);
				//Debug.Log ("Active Scenes = " + SceneManager.GetActiveScene ().buildIndex);
				/*
				if(_musicPlayed != SceneManager.GetActiveScene ().buildIndex - 1)
				{
					_changeTipeOfMusic = true;
				}*/
					
				if(_afterChangeMusicValue != _changeMusicValue)
				{
					_changeTipeOfMusic = true;
				}

				if(!_MusicPlayer.isPlaying || (_musicPlayed != SceneManager.GetActiveScene ().buildIndex - 1 && SceneManager.GetActiveScene ().buildIndex - 1 >= 0))
				{
					//Debug.Log ("Change!");
					_changeTipeOfMusic = true;
				}
					
				if (_changeMusicValue == 0) 
				{
					//Debug.Log ("Music1");
					_afterChangeMusicValue = 0;

					DoMusic (_MusicList1);
				}
				else if (_changeMusicValue == 1) 
				{
					//Debug.Log ("Music2");
					_afterChangeMusicValue = 1;

					DoMusic (_MusicList2);
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

		public void DoMusic(AudioClip[] MusicList)
		{
			//Debug.Log ("IfPlay");

			if (!_MusicPlayer.isPlaying || _changeTipeOfMusic == true) 
			{
				Debug.Log ("Play");
				switch (SceneManager.GetActiveScene ().buildIndex) 
				{
				case 0:
					//Debug.Log ("Case 0");
					_changeTipeOfMusic = false;
					_musicPlayed = 0;
					_MusicPlayer.clip = MusicList [0];
					_MusicPlayer.Play ();
					break;

				default:
					//Debug.Log ("Default");
					_changeTipeOfMusic = false;
					_musicPlayed = SceneManager.GetActiveScene ().buildIndex - 1;
					_MusicPlayer.clip = MusicList [SceneManager.GetActiveScene ().buildIndex - 1];
					_MusicPlayer.Play ();
					break;
				}
			}

			/*
			if ((SceneManager.GetActiveScene ().buildIndex - 1) <= 0) 
			{
				if (!_MusicPlayer.isPlaying || _changeTipeOfMusic == true) 
				{
					//Debug.Log ("I'm Play First!");
					_changeTipeOfMusic = false;
					_MusicPlayer.clip = MusicList [0];
					_musicPlayed = 0;
					_MusicPlayer.Play ();
				}
			} 
			else 
			{
				if (!_MusicPlayer.isPlaying || _changeTipeOfMusic == true) 
				{
					Debug.Log ("I'm Play Second!");
					_changeTipeOfMusic = false;
					_MusicPlayer.clip = MusicList [SceneManager.GetActiveScene ().buildIndex - 1];
					_musicPlayed = SceneManager.GetActiveScene ().buildIndex - 1;
					_MusicPlayer.Play ();
				}
			}*/
		}
	}
}
