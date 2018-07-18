using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		// make the Game Object to be on top of the hierarchy
		transform.SetParent (null);
		// mark the Game Object as not destroyable on load
		DontDestroyOnLoad (gameObject);
	}
}