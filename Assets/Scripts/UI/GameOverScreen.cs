﻿using Catch.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Catch.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentGameObject;
        [SerializeField] private Button _restartButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonClickedCallback);
        }

        private void Start()
        {
            GameService.Instance.OnGameOver += GameOverCallback;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnGameOver -= GameOverCallback;
        }

        #endregion

        #region Private methods

        private void GameOverCallback()
        {
            _contentGameObject.SetActive(true);
        }

        private void RestartButtonClickedCallback()
        {
            GameService.Instance.GameRestart();
        }

        #endregion
    }
}