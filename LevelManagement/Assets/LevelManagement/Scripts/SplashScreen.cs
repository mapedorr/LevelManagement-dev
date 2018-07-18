using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
	[RequireComponent (typeof (ScreenFader))]
	public class SplashScreen : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		ScreenFader _screenFader;

		[SerializeField]
		float _delay = 0.5f;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			_screenFader = GetComponent<ScreenFader> ();
		}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start ()
		{
			_screenFader.FadeOn ();
		}

		public void FadeAndLoad ()
		{
			StartCoroutine (FadeAndLoadRoutine ());
		}

		IEnumerator FadeAndLoadRoutine ()
		{
			yield return new WaitForSeconds (_delay);
			_screenFader.FadeOff ();
			LevelLoader.LoadMainMenuLevel ();

			// destroy the splash screen after the fade off effect finishes
			Destroy (gameObject, _screenFader.FadeOffDuration);
		}
	}
}