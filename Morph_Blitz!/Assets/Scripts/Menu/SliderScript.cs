using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Musica
{
	public class SliderScript : MonoBehaviour 
	{

		public Slider AudioSlider;

		//private AudioSource _AudioSource;

		// Use this for initialization
		void Start () 
		{
			//AudioSlider = GetComponent<Slider> ();
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
