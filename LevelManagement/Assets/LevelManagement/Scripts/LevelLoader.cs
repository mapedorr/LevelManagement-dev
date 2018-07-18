using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
	public class LevelLoader : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		// name of the next level
		private string _nextLevelName;

		[SerializeField]
		// build index of the next level
		private int _nextLevelIndex;

		// the index of the main menu in build settings
		private static int _mainMenuIndex = 1;

		// ════════════════════════════════════════════════════════ METHODS ════
		public static void ReloadLevel ()
		{
			LoadLevel (SceneManager.GetActiveScene ().buildIndex);
		}

		public static void LoadNextLevel ()
		{
			/*
			// ┌ mine ─────────────────────────────────────────────────────────┐
			int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
			if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
			{
			    nextSceneIndex = 0;
			}
			LoadLevel (nextSceneIndex);
			// └───────────────────────────────────────────────────────────────┘
			*/

			// ┌ wilmer lin ───────────────────────────────────────────────────┐
			int nextSceneIndex = (SceneManager.GetActiveScene ().buildIndex + 1) %
				SceneManager.sceneCountInBuildSettings;
			nextSceneIndex = Mathf.Clamp (nextSceneIndex, _mainMenuIndex, nextSceneIndex);
			LoadLevel (nextSceneIndex);
			// └───────────────────────────────────────────────────────────────┘
		}

		public static void LoadLevel (string levelName)
		{
			if (Application.CanStreamedLevelBeLoaded (levelName))
			{
				SceneManager.LoadScene (levelName);
			}
			else
			{
				Debug.LogWarning ("LevelLoader.LoadLevel(string) Error: invalid scene name");
			}
		}

		/// <summary>
		/// Loads a scene by its build index
		/// </summary>
		/// <param name="levelIndex"></param>
		public static void LoadLevel (int levelIndex)
		{
			if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
			{
				// if the scene to load matches the index of the main menu scene,
				// open the main menu
				if (levelIndex == _mainMenuIndex)
				{
					MainMenu.Open ();
				}

				SceneManager.LoadScene (levelIndex);
			}
			else
			{
				Debug.LogWarning ("LevelLoader.LoadLevel(int) Error: invalid scene index");
			}
		}

		public static void LoadMainMenuLevel ()
		{
			LoadLevel (_mainMenuIndex);
		}
	}
}