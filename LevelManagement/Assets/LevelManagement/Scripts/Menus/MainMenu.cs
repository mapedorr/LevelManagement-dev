using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
	public class MainMenu : Menu
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		// reference to this singleton's class
		static MainMenu _instance;
		public static MainMenu Instance { get { return _instance; } }

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

		public void OnPlayPressed ()
		{
			if (GameManager.Instance != null)
			{
				GameManager.Instance.LoadNextLevel ();
			}
		}

		public void OnSettingsPressed ()
		{
			/*
			// ┌ mine ─────────────────────────────────────────────────────────┐
			MenuManager menuManager = GameObject.FindObjectOfType<MenuManager> ();
			if (menuManager != null)
			{
				// get the instance of the settings menu
				Transform settingsMenu = menuManager.MenusParent.Find ("SettingsMenu(Clone)");

				// open the settings menu
				menuManager.OpenMenu (settingsMenu.GetComponent<Menu> ());
			}
			// └───────────────────────────────────────────────────────────────┘
			*/

			// ┌ wilmer lin ───────────────────────────────────────────────────┐
			if (MenuManager.Instance != null && SettingsMenu.Instance != null)
			{
				// open the settings menu
				MenuManager.Instance.OpenMenu (SettingsMenu.Instance);
			}
			// └───────────────────────────────────────────────────────────────┘
		}

		public void OnCreditsPressed ()
		{
			/*
			// ┌ mine ─────────────────────────────────────────────────────────┐
			MenuManager menuManager = GameObject.FindObjectOfType<MenuManager> ();
			if (menuManager != null)
			{
				// get the instance of the settings menu
				Transform settingsMenu = menuManager.MenusParent.Find ("CreditsMenu(Clone)");

				// open the settings menu
				menuManager.OpenMenu (settingsMenu.GetComponent<Menu> ());
			}
			// └───────────────────────────────────────────────────────────────┘
			*/

			// ┌ wilmer lin ───────────────────────────────────────────────────┐
			if (MenuManager.Instance != null && CreditsMenu.Instance != null)
			{
				// open the settings menu
				MenuManager.Instance.OpenMenu (CreditsMenu.Instance);
			}
			// └───────────────────────────────────────────────────────────────┘
		}

		public override void OnBackPressed ()
		{
			Application.Quit ();
		}
	}
}