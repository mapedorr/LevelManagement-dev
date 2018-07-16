using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
	public class WinMenu : Menu<WinMenu>
	{
		public void OnNextLevelPressed ()
		{
			// close the menu
			base.OnBackPressed ();
			LevelLoader.LoadNextLevel ();
		}

		public void OnRestartPressed ()
		{
			// close the menu
			base.OnBackPressed ();
			LevelLoader.ReloadLevel ();
		}

		public void OnMainMenuPressed ()
		{
			LevelLoader.LoadMainLevelMenu ();
			MainMenu.Open ();
		}
	}
}