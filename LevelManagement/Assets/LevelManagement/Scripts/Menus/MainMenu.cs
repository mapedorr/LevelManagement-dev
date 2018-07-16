using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
	// this class derives from a Generic Menu base class
	public class MainMenu : Menu<MainMenu>
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		public void OnPlayPressed ()
		{
			if (GameManager.Instance != null)
			{
				LevelLoader.LoadNextLevel ();
			}

			// open the game menu (the one with the button that allows the player
			// to pause the game)
			GameMenu.Open ();
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
			SettingsMenu.Open ();
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
			CreditsMenu.Open ();
			// └───────────────────────────────────────────────────────────────┘
		}

		public override void OnBackPressed ()
		{
			Application.Quit ();
		}
	}
}