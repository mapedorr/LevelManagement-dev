using System;
using System.Collections;
using System.Collections.Generic;

namespace LevelManagement.Data
{
	[Serializable]
	public class SaveData
	{
		// ════════════════════════════════════════════════════════════ PUBLICS ════
		public string playerName;
		public float masterVolume;
		public float sfxVolume;
		public float musicVolume;
		public string hashValue;

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		readonly string _defaultPlayerName = "Carenalga";

		// ════════════════════════════════════════════════════════════ METHODS ════
		public SaveData ()
		{
			playerName = _defaultPlayerName;
			masterVolume = 0f;
			sfxVolume = 0f;
			musicVolume = 0f;
			hashValue = String.Empty;
		}
	}

}