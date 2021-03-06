﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// namespace that helps us to get Type information at runtime
using System.Reflection;

namespace LevelManagement
{
	public class MenuManager : MonoBehaviour
	{
		// ════════════════════════════════════════════════════════════ PUBLICS ════
		[SerializeField]
		MainMenu _mainMenuPrefab;
		[SerializeField]
		SettingsMenu _settingsMenuPrefab;
		[SerializeField]
		CreditsMenu _creditsMenuPrefab;
		[SerializeField]
		GameMenu _gameMenuPrefab;
		[SerializeField]
		PauseMenu _pauseMenuPrefab;
		[SerializeField]
		WinMenu _winMenuPrefab;

		/*
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		// container for all the menus (to keep things organized in the hierarchy)
		Transform _menusParent;
		public Transform MenusParent { get { return _menusParent; } }
		*/
		// reference to this singleton's class
		static MenuManager _instance;
		public static MenuManager Instance { get { return _instance; } }

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		// stack of openned menus
		Stack<Menu> _menusStack = new Stack<Menu> ();
		// container for all the menus (to keep things organized in the hierarchy)
		Transform _menusParent;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			// make this manager a singleton
			if (_instance != null)
			{
				Destroy (gameObject);
			}
			else
			{
				_instance = this;
				InitializeMenus ();
				// make this manager to persist between scenes
				DontDestroyOnLoad (this.gameObject);
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

		/// <summary>
		/// Initializes all the menus of the game and put them inside a container element.
		/// It also makes active only the main menu.
		/// </summary>
		void InitializeMenus ()
		{
			if (_menusParent == null)
			{
				// create an empty main object for grouping all the menus if there's no
				// one defined
				GameObject menuContainer = new GameObject ("Menus");
				_menusParent = menuContainer.transform;
			}

			// make the container of all the menus persist between scenes
			DontDestroyOnLoad (_menusParent.gameObject);

			/* 
			// this array will be used to instantiate all the menus for the game inside
			// a loop
			Menu[] menuPrefabs = {
				_mainMenuPrefab,
				_settingsMenuPrefab,
				_creditsMenuPrefab,
				_gameMenuPrefab,
				_pauseMenuPrefab,
				_winMenuPrefab
			};
			*/

			// store a reference to the MenuManager type
			System.Type myType = this.GetType ();
			// set the enums that will be used to search through the reflection
			BindingFlags myFlags = BindingFlags.Instance |
				BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
			// get the fields that match the conditions we're looking for
			FieldInfo[] fields = myType.GetFields (myFlags);

			foreach (FieldInfo field in fields)
			{
				// ???
				Menu prefab = field.GetValue (this) as Menu;

				// create an instance of the menu if it was defined in the Inspector
				if (prefab != null)
				{
					Menu menuInstance = Instantiate (prefab, _menusParent);

					// check if the current instantiated prefab is the MainMenu
					if (prefab != _mainMenuPrefab)
					{
						// by default, only the main menu should be active
						menuInstance.gameObject.SetActive (false);
					}
					else
					{
						OpenMenu (menuInstance);
					}
				}
			}
		}

		public void OpenMenu (Menu menuInstance)
		{
			// prevent trying to open null menus
			if (menuInstance == null)
			{
				Debug.LogWarning ("MenuManager.OpenMenu ERROR: no menu specified");
				return;
			}

			// close the menus in the stack
			if (_menusStack.Count > 0)
			{
				foreach (Menu menu in _menusStack)
				{
					menu.gameObject.SetActive (false);
				}
			}

			// show the menu and add it to the stack
			menuInstance.gameObject.SetActive (true);
			_menusStack.Push (menuInstance);
		}

		/// <summary>
		/// Closes the first menu on the stack (that means, the last opened menu)
		/// </summary>
		public void CloseMenu ()
		{
			if (_menusStack.Count == 0)
			{
				Debug.LogWarning ("MenuManager.CloseMenu ERROR: there's no menu to close");
				return;
			}

			// remove and "close" the menu on the top of the stack
			_menusStack.Pop ().gameObject.SetActive (false);

			if (_menusStack.Count > 0)
			{
				// make the next menu in the stack visible
				_menusStack.Peek ().gameObject.SetActive (true);
			}

		}
	}
}