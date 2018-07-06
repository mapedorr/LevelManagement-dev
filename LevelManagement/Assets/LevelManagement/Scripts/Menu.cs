using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace LevelManagement
{
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