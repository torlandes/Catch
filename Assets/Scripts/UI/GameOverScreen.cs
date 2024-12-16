using System.Collections;
using Catch.Game;
using Catch.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Catch.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables
        
        [Header("UI")]
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private AudioClip _overAudioClip;

        [Header("Buttons")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private AudioClip _tapAudio;
        
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _animationTime = 1f;
        private Coroutine _fadeInAnimation;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonClickedCallback);
            _menuButton.onClick.AddListener(MenuButtonClickedCallback);
            
            _gameOverPanel.SetActive(false);
            _canvasGroup.alpha = 0;
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

        #region Public methods

        public void GameOverCallback()
        {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(true);
                _scoreLabel.text = $"{GameService.Instance.Score}";
                AudioService.Instance.PlaySfx(_overAudioClip);
                PauseService.Instance.TogglePause();

                _fadeInAnimation = StartCoroutine(PlayFadeInAnimation());
            }
        }

        #endregion

        #region Private methods
        
        private void RestartButtonClickedCallback()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            PauseService.Instance.TogglePause();
            GameService.Instance.GameRestart();
            PickUpSpawner.Instance.ResetFallSpeed();
        }
        
        private void MenuButtonClickedCallback()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            PauseService.Instance.TogglePause();
            GameService.Instance.Reset();
            SceneManager.LoadScene("MenuScene");
        }
        
        private IEnumerator PlayFadeInAnimation()
        {
            _gameOverPanel.SetActive(true);

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.unscaledDeltaTime / _animationTime;
                yield return null;
            }
        }

        #endregion
    }
}