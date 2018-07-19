using System.Collections;
using System.Collections.Generic;

namespace LevelManagement.Data
{
	public class SaveData
	{
		// ════════════════════════════════════════════════════════════ PUBLICS ════
		public string playerName;
		public float masterVolume;
		public float sfxVolume;
		public float musicVolume;

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		readonly string _defaultPlayerName = "Player";

		// ════════════════════════════════════════════════════════════ METHODS ════
		public SaveData ()
		{
			playerName = _defaultPlayerName;
			masterVolume = 0f;
			sfxVolume = 0f;
			musicVolume = 0f;
		}
	}

}