using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
	public class DataManager : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════════ PROPERTIES ════
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
			get { return _saveData.masterVolume; }
			set { _saveData.masterVolume = value; }
		}

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		SaveData _saveData;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			_saveData = new SaveData ();
		}
	}
}