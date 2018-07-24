using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
	public class DataManager : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		SaveData _saveData;
		JsonSaver _jsonSaver;

		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		public string PlayerName
		{
			get { return _saveData.playerName; }
			set { _saveData.playerName = value; }
		}
		public float MasterVolume
		{
			get { return _saveData.masterVolume; }
			set { _saveData.masterVolume = value; }
		}
		public float SFXVolume
		{
			get { return _saveData.sfxVolume; }
			set { _saveData.sfxVolume = value; }
		}
		public float MusicVolume
		{
			get { return _saveData.musicVolume; }
			set { _saveData.musicVolume = value; }
		}

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			GetReferences ();
		}

		/// <summary>
		/// Instantiates SaveData and JsonSaver classes.
		/// </summary>
		public void GetReferences ()
		{
			_saveData = new SaveData ();
			_jsonSaver = new JsonSaver ();
		}

		/// <summary>
		/// Save the data in the object SaveData to disc.
		/// </summary>
		public void Save ()
		{
			if (_jsonSaver != null)
			{
				_jsonSaver.Save (_saveData);
			}
		}

		/// <summary>
		/// Loads the data on disc to the object SaveData.
		/// </summary>
		public void Load ()
		{
			if (_jsonSaver != null)
			{
				_jsonSaver.Load (_saveData);
			}
		}
	}
}