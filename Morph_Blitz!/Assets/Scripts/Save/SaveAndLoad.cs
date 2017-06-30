using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoad
{ 

	public static void Save(GlobalVariables globalVariables)
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file =  new FileStream (Application.persistentDataPath + "/MorpfSaves.txt", FileMode.Create);

		DataToSave data = new DataToSave (globalVariables);

		//Debug.Log ("GV Volume = " + globalVariables.audioVolume);

		bf.Serialize (file, data);

		file.Close();

	}

	public static int LoadChangeMusic()
	{
		if (File.Exists (Application.persistentDataPath + "/MorpfSaves.txt")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = new FileStream (Application.persistentDataPath + "/MorpfSaves.txt", FileMode.Open);

			DataToSave data = bf.Deserialize (file) as DataToSave;

			file.Close();

			//Debug.Log ("CNG MSC = " + data.changeMusicValue);
			return data.changeMusicValue;
		}
		else
		{
			return 0;
		}
	}

	public static bool LoadAudio()
	{
		if (File.Exists (Application.persistentDataPath + "/MorpfSaves.txt")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = new FileStream (Application.persistentDataPath + "/MorpfSaves.txt", FileMode.Open);

			DataToSave data = bf.Deserialize (file) as DataToSave;

			file.Close();

			//Debug.Log ("Audio ON = " + data.audioOn);
			return data.audioOn;
		}
		else
		{
			return false;
		}
	}

	public static float LoadVolume()
	{
		if (File.Exists (Application.persistentDataPath + "/MorpfSaves.txt")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = new FileStream (Application.persistentDataPath + "/MorpfSaves.txt", FileMode.Open);

			DataToSave data = bf.Deserialize (file) as DataToSave;

			file.Close();

			//Debug.Log ("Volume = " + data.volume);
			return data.volume;
		}
		else
		{
			return 0f;
		}
	}

	public static float[] LoadLevelTimeDone()
	{
		if (File.Exists (Application.persistentDataPath + "/MorpfSaves.txt")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = new FileStream (Application.persistentDataPath + "/MorpfSaves.txt", FileMode.Open);

			DataToSave data = bf.Deserialize (file) as DataToSave;

			file.Close();

			return data.timeDone;
		}
		else
		{
			return new float[7];
		}
	}

}

[Serializable]
public class DataToSave
{
	public bool audioOn;

	public int changeMusicValue;

	public float volume;
	public float[] timeDone;

	public DataToSave (GlobalVariables globalVariables)
	{

		//Debug.Log ("GV Volume = " + globalVariables.audioVolume);

		changeMusicValue = globalVariables.changeMusicValue;

		audioOn = globalVariables.audioOn;

		volume = globalVariables.audioVolume;

		timeDone = globalVariables.LevelTimeDone;
	}
}