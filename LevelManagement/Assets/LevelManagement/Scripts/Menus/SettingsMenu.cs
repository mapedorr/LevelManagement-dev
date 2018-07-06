using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
	public class SettingsMenu : Menu
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		// reference to this singleton's class
		static SettingsMenu _instance;
		public static SettingsMenu Instance { get { return _instance; } }

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			if (_instance != null)
			{
				Destroy (gameObject);
			}
			else
			{
				_instance = this;
			}
		}

		/// <summary>
		/// This function is called when the MonoBehaviour will be destroyed.
		/// </summary>
		void OnDestroy ()
		{
			if (_instance == this)
			{
				_instance = null;
			}
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();

			// TODO: add extra logic
		}
	}
}