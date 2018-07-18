using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
	// this class derives from a Generic Menu base class
	public class MainMenu : Menu<MainMenu>
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		TransitionFader _startTransitionPrefab;

		[SerializeField]
		float _playDelay = 0.5f;

		// ════════════════════════════════════════════════════════════ METHODS ════
		public void OnPlayPressed ()
		{
			StartCoroutine (OnPlayPressedRoutine ());
		}

		IEnumerator OnPlayPressedRoutine ()
		{
			// start the transition between scenes
			if (_startTransitionPrefab != null)
			{
				TransitionFader.CreateAndPlayTransition (_startTransitionPrefab);
			}

			// load the first level
			if (GameManager.Instance != null)
			{
				LevelLoader.LoadNextLevel ();
			}

			// wait a couple of seconds before hiding this menu and openning the game
			// menu
			yield return new WaitForSeconds (_playDelay);

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