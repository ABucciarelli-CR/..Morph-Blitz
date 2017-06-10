using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Musica
{
	public class SliderScript : MonoBehaviour 
	{

		public Slider AudioSlider;

		public MusicManager musicManager;

		//private AudioSource _AudioSource;

		// Use this for initialization
		void Awake () 
		{
			//AudioSlider = GetComponent<Slider> ();
			if (musicManager._MusicPlayer.volume != .5f) 
			{
				AudioSlider.value = musicManager._MusicPlayer.volume;
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		public float ChangeVolume()
		{
			return AudioSlider.value;
		}
	}
}
