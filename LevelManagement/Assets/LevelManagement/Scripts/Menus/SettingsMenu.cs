using System.Collections;
using System.Collections.Generic;
using LevelManagement.Data;
using SampleGame;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
	public class SettingsMenu : Menu<SettingsMenu>
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		Slider _masterVolumeSlider;
		[SerializeField]
		Slider _sfxVolumeSlider;
		[SerializeField]
		Slider _musicVolumeSlider;

		DataManager _dataManager;

		// ════════════════════════════════════════════════════════════ METHODS ════
		public override void Awake ()
		{
			base.Awake ();
			_dataManager = GameObject.FindObjectOfType<DataManager> ();
			LoadPlayerPreferences ();
		}

		public void OnMasterVolumeChanged (float volume)
		{
			/* // send the data to PlayerPrefbs
			PlayerPrefs.SetFloat ("MasterVolume", volume); */
			if (_dataManager != null)
			{
				_dataManager.MasterVolume = volume;
			}
		}

		public void OnSFXVolumeChanged (float volume)
		{
			/* // send the data to PlayerPrefbs
			PlayerPrefs.SetFloat ("SFXVolume", volume); */
			if (_dataManager != null)
			{
				_dataManager.SFXVolume = volume;
			}
		}

		public void OnMusicVolumeChanged (float volume)
		{
			/* // send the data to PlayerPrefbs
			PlayerPrefs.SetFloat ("MusicVolume", volume); */
			if (_dataManager != null)
			{
				_dataManager.MusicVolume = volume;
			}
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();
			/* PlayerPrefs.Save (); */
		}

		public void LoadPlayerPreferences ()
		{
			/* _masterVolumeSlider.value = PlayerPrefs.GetFloat ("MasterVolume");
			_sfxVolumeSlider.value = PlayerPrefs.GetFloat ("SFXVolume");
			_musicVolumeSlider.value = PlayerPrefs.GetFloat ("MusicVolume"); */

			if (_dataManager == null || _masterVolumeSlider == null ||
				_sfxVolumeSlider == null || _musicVolumeSlider == null)
			{
				return;
			}

			_masterVolumeSlider.value = _dataManager.MasterVolume;
			_sfxVolumeSlider.value = _dataManager.SFXVolume;
			_musicVolumeSlider.value = _dataManager.MusicVolume;
		}
	}
}