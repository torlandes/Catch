﻿using Catch.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [Header("Text settings")]
        [SerializeField] private TMP_Text _scoreLabel;

        [Header("Game object settings")]
        [SerializeField] private GameObject[] _hearts;
        [SerializeField] private GameObject LoseHP;

        [Header("Buttons")]
        [SerializeField] private Button _pauseButton;
        [SerializeField] private AudioClip _tapAudio;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _pauseButton.onClick.AddListener(PauseButtonClickedCallback);
        }

        private void Start()
        {
            GameService.Instance.OnScoreChanged += ScoreChangedCallback;
            GameService.Instance.OnLiveChanged += UpdateHearts;
            UpdateHearts(GameService.Instance.Lives);
            UpdateScore();
        }

        private void OnDestroy()
        {
            GameService.Instance.OnScoreChanged -= ScoreChangedCallback;
            GameService.Instance.OnLiveChanged -= UpdateHearts;
        }

        #endregion

        #region Private methods

        private void PauseButtonClickedCallback()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            PauseService.Instance.TogglePause();
        }

        private void ScoreChangedCallback(int i)
        {
            UpdateScore();
        }

        private void UpdateHearts(int lives)
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].SetActive(i < lives);
            }
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"EYES: {GameService.Instance.Score}";
        }

        #endregion
    }
}