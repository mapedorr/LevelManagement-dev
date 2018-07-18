using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader
{
	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	[SerializeField]
	float _transitionTime;

	[SerializeField]
	float _delay;
	public float Delay { get { return _delay; } }

	// ══════════════════════════════════════════════════════════════ METHODS ════
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		_transitionTime = Mathf.Clamp (_transitionTime, FadeOffDuration + FadeOnDuration + _delay, 10f);
	}

	IEnumerator PlayTransitionRoutine ()
	{
		SetAlpha (_clearAlpha);
		yield return new WaitForSeconds (_delay);

		FadeOn ();
		float onTime = _transitionTime - (FadeOffDuration + _delay);
		yield return new WaitForSeconds (onTime);

		FadeOff ();
		Destroy (gameObject, FadeOffDuration);
	}

	public void PlayTransition ()
	{
		StartCoroutine (PlayTransitionRoutine ());
	}

	/// <summary>
	/// Method used to allow any GameObject on the scene to drop off a transition
	/// into it
	/// </summary>
	/// <param name="transitionFaderPrefab"></param>
	public static void CreateAndPlayTransition (TransitionFader transitionFaderPrefab)
	{
		if (transitionFaderPrefab != null)
		{
			TransitionFader instance = Instantiate (transitionFaderPrefab, Vector3.zero, Quaternion.identity);
			instance.PlayTransition ();
		}
	}
}