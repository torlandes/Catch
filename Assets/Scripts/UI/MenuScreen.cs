using System.Collections;
using Catch.Game;
using Catch.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Catch.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [Header("Button")]
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _manualButton;
        [SerializeField] private Button _backButton;
        
        [Header("GameObjects")]
        [SerializeField] private GameObject _mainGameObject;
        [SerializeField] private GameObject _manualGameObject;
        
        [Header("Audio")]
        [SerializeField] private AudioClip _tapAudio;
        
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _animationTime = 0.5f;
        private Coroutine _fadeInAnimation;
        private Coroutine _fadeOutAnimation;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
            _manualButton.onClick.AddListener(OnManualButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }
        
        private void Awake()
        {
            _mainGameObject.SetActive(true);
            _manualGameObject.SetActive(false);
            _canvasGroup.alpha = 0;
        }
        
        #endregion

        #region Private methods

        private void OnExitButtonClicked()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            SceneLoaderService.Instance.ExitGame();
        }

        private void OnStartButtonClicked()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            SceneLoaderService.Instance.StartGame();
            PickUpSpawner.Instance.ResetFallSpeed();
        }
        
        private void OnManualButtonClicked()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            _mainGameObject.SetActive(false);
            _manualGameObject.SetActive(true);
            _fadeInAnimation = StartCoroutine(PlayFadeInAnimation());
        }
        
        private void OnBackButtonClicked()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            _mainGameObject.SetActive(true);
            _manualGameObject.SetActive(false);
            _fadeOutAnimation = StartCoroutine(PlayFadeOutAnimation());
        }
        
        private IEnumerator PlayFadeInAnimation()
        {
            _mainGameObject.SetActive(false);
            _manualGameObject.SetActive(true);

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.unscaledDeltaTime / _animationTime;
                yield return null;
            }
        }
        
        private IEnumerator PlayFadeOutAnimation()
        {

            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.unscaledDeltaTime / _animationTime;
                yield return null;
            }

            _manualGameObject.SetActive(false);
            _mainGameObject.SetActive(true);
        }

        #endregion
    }
}