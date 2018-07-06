using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
	// curiously recurring template pattern (CRTP)
	//  - https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern
	public abstract class Menu<T> : Menu where T : Menu<T>
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		// reference to this singleton's class
		static T _instance;
		public static T Instance { get { return _instance; } }

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
				_instance = (T) this;
			}
		}

		/// <summary>
		/// This function is called when the MonoBehaviour will be destroyed.
		/// </summary>
		void OnDestroy ()
		{
			_instance = null;
		}
	}

	[RequireComponent (typeof (Canvas))]
	public abstract class Menu : MonoBehaviour
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		public virtual void OnBackPressed ()
		{
			if (MenuManager.Instance != null)
			{
				MenuManager.Instance.CloseMenu ();
			}
		}
	}
}