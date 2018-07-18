using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
	// this class derives from a Generic Menu base class
	public class PauseMenu : Menu<PauseMenu>
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		public void OnResumePressed ()
		{
			Time.timeScale = 1;
			base.OnBackPressed ();
		}

		public void OnRestartPressed ()
		{
			if (GameManager.Instance != null)
			{
				Time.timeScale = 1;
				LevelLoader.ReloadLevel ();
				base.OnBackPressed ();
			}
		}

		public void OnMainMenuPressed ()
		{
			Time.timeScale = 1;
			LevelLoader.LoadMainMenuLevel ();

			MainMenu.Open ();
		}

		public void OnQuitPressed ()
		{
			Application.Quit ();
		}
	}
}