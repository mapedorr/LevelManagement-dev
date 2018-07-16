using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
	public class GameMenu : Menu<GameMenu>
	{
		public void OnPausePressed ()
		{
			// stop gameplay
			Time.timeScale = 0;

			// open the pause menu
			PauseMenu.Open ();
		}
	}
}