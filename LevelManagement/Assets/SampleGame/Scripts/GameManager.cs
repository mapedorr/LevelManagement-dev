﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        // ═════════════════════════════════════════════════════ PROPERTIES ════
        private bool _isGameOver;
        public bool IsGameOver { get { return _isGameOver; } }

        // reference to this singleton's class
        static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        // ═══════════════════════════════════════════════════════ PRIVATES ════
        // reference to player
        private ThirdPersonCharacter _player;

        // reference to goal effect
        private GoalEffect _goalEffect;

        // reference to player
        private Objective _objective;

        [SerializeField]
        // name of the next level
        private string _nextLevelName;

        [SerializeField]
        // build index of the next level
        private int _nextLevelIndex;

        // ════════════════════════════════════════════════════════ METHODS ════
        // initialize references
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake ()
        {
            if (_instance != null)
            {
                Destroy (gameObject);
            }
            else
            {
                _instance = this;
                _player = Object.FindObjectOfType<ThirdPersonCharacter> ();
                _objective = Object.FindObjectOfType<Objective> ();
                _goalEffect = Object.FindObjectOfType<GoalEffect> ();
            }
        }

        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
        void OnDestroy ()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        // end the level
        public void EndLevel ()
        {
            if (_player != null)
            {
                // disable the player controls
                ThirdPersonUserControl thirdPersonControl =
                    _player.GetComponent<ThirdPersonUserControl> ();

                if (thirdPersonControl != null)
                {
                    thirdPersonControl.enabled = false;
                }

                // remove any existing motion on the player
                Rigidbody rbody = _player.GetComponent<Rigidbody> ();
                if (rbody != null)
                {
                    rbody.velocity = Vector3.zero;
                }

                // force the player to a stand still
                _player.Move (Vector3.zero, false, false);
            }

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect != null && !_isGameOver)
            {
                _isGameOver = true;
                _goalEffect.PlayEffect ();
                LoadNextLevel ();
            }
        }

        public void ReloadLevel ()
        {
            LoadLevel (SceneManager.GetActiveScene ().buildIndex);
        }

        public void LoadNextLevel ()
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
            LoadLevel (nextSceneIndex);
            // └───────────────────────────────────────────────────────────────┘
        }

        private void LoadLevel (string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded (levelName))
            {
                SceneManager.LoadScene (levelName);
            }
            else
            {
                Debug.LogWarning ("GameManager.LoadLevel(string) Error: invalid scene name");
            }
        }

        /// <summary>
        /// Loads a scene by its build index
        /// </summary>
        /// <param name="levelIndex"></param>
        private void LoadLevel (int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene (levelIndex);
            }
            else
            {
                Debug.LogWarning ("GameManager.LoadLevel(int) Error: invalid scene index");
            }
        }

        // check for the end game condition on each frame
        private void Update ()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel ();
            }
        }

    }
}