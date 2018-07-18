using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
	// ═══════════════════════════════════════════════════════════ PROPERTIES ════
	[SerializeField]
	protected float _fadeOffDuration = 1f;
	public float FadeOffDuration { get { return _fadeOffDuration; } }

	[SerializeField]
	protected float _fadeOnDuration = 1f;
	public float FadeOnDuration { get { return _fadeOnDuration; } }

	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	[SerializeField]
	protected float _solidAlpha = 1f;

	[SerializeField]
	protected float _clearAlpha = 0f;

	[SerializeField]
	MaskableGraphic[] _uiElementsToFade;

	// ═══════════════════════════════════════════════════ METHODS (private) ════
	protected void SetAlpha (float targetAlpha)
	{
		foreach (MaskableGraphic uiElement in _uiElementsToFade)
		{
			if (uiElement != null)
			{
				uiElement.canvasRenderer.SetAlpha (targetAlpha);
			}
		}
	}

	void Fade (float targetAlpha, float duration)
	{
		foreach (MaskableGraphic uiElement in _uiElementsToFade)
		{
			if (uiElement != null)
			{
				// change the alpha of the element
				// in the game pauses, continue changing the alpha (that's what the third
				// parameter does)
				uiElement.CrossFadeAlpha (targetAlpha, duration, true);
			}
		}
	}

	// ═════════════════════════════════════════════════════ METHODS (public) ════
	public void FadeOff ()
	{
		SetAlpha (_solidAlpha);
		Fade (_clearAlpha, FadeOffDuration);
	}

	public void FadeOn ()
	{
		SetAlpha (_clearAlpha);
		Fade (_solidAlpha, FadeOnDuration);
	}
}