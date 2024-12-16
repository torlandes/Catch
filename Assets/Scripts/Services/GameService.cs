using System;
using Catch.Utility;
using UnityEngine;

namespace Catch.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _maxLives = 3;

        [Header("Stats")]
        [SerializeField] private int _score;
        [SerializeField] private int _lives;

        #endregion

        #region Events

        public event Action OnGameOver;

        public event Action<int> OnLiveChanged;

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public bool IsGameOver { get; set; }
        public int Lives => _lives;
        public int Score => _score;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            _lives = _maxLives;
        }

        public void Reset()
        {
            _lives = _maxLives;
            _score = 0;
        }

        #endregion

        #region Public methods

        public void AddScore(int points)
        {
            if (IsGameOver)
            {
                return;
            }
            
            _score += points;
            OnScoreChanged?.Invoke(_score);
        }

        public void ChangeLife(int value)
        {
            if (IsGameOver)
            {
                return;
            }

            _lives += value;
            _lives = Mathf.Clamp(_lives, 0, _maxLives);
            OnLiveChanged?.Invoke(_lives);
            CheckGameEnd();
        }

        public void GameRestart()
        {
            IsGameOver = false;
            Reset();
            SceneLoaderService.Instance.StartGame();
        }

        #endregion

        #region Private methods

        private void CheckGameEnd()
        {
            if (_lives <= 0)
            {
                OnGameOver?.Invoke();
            }
        }

        #endregion
    }
}