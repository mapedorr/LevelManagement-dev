using System.Collections;
using System.Collections.Generic;
using LevelManagement.Data;
using SampleGame;
using UnityEngine;
using UnityEngine.UI;

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

		[SerializeField]
		InputField _playerNameInputField;

		DataManager _dataManager;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		public override void Awake ()
		{
			base.Awake ();

			_dataManager = GameObject.FindObjectOfType<DataManager> ();
			_dataManager.GetReferences ();
		}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start ()
		{
			LoadData ();
		}

		/// <summary>
		/// Loads the player name saved on disc.
		/// </summary>
		void LoadData ()
		{
			if (_dataManager != null && _playerNameInputField != null)
			{
				_dataManager.Load ();
				_playerNameInputField.text = _dataManager.PlayerName;
			}
		}

		/// <summary>
		/// Called when the player clicks on Play.
		/// </summary>
		public void OnPlayPressed ()
		{
			StartCoroutine (OnPlayPressedRoutine ());
		}

		/// <summary>
		/// Routine that starts the transition between the Main menu and the game loading
		/// the first level on the scenes in build.
		/// </summary>
		/// <returns>An IEnumerator ready to be used as a Coroutine.</returns>
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

		/// <summary>
		/// Called when the player clicks on the Settings option.
		/// </summary>
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

		/// <summary>
		/// Called when the player clicks on the Credits option.
		/// </summary>
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

		/// <summary>
		/// Called when the player clicks on the Quit option.
		/// </summary>
		public override void OnBackPressed ()
		{
			Application.Quit ();
		}

		/// <summary>
		/// Updates the name to store every time the player changes it on the PlayerNameInputField.
		/// </summary>
		public void OnPlayerNameChanged (string name)
		{
			if (_dataManager != null)
			{
				_dataManager.PlayerName = name;
			}
		}

		/// <summary>
		/// Stores the name of the player after it finishes its edition.
		/// </summary>
		public void OnPlayerNameEndEdit ()
		{
			if (_dataManager != null)
			{
				_dataManager.Save ();
			}
		}
	}
}