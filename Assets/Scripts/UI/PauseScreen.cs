using System.Collections;
using Catch.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Catch.UI
{
    public class PauseScreen : MonoBehaviour
    {
        #region Variables

        [Header("Buttons")]
        [SerializeField] private GameObject _contentGameObject;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private AudioClip _tapAudio;
        
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _animationTime = 1f;
        private Coroutine _fadeInAnimation;
        private Coroutine _fadeOutAnimation;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _continueButton.onClick.AddListener(ContinueButtonClickedCallback);
            _menuButton.onClick.AddListener(MenuButtonClickedCallback);
            
            _contentGameObject.SetActive(false);
            _canvasGroup.alpha = 0;
        }

        private void Start()
        {
            PauseService.Instance.OnChanged += PauseChangedCallback;
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnChanged -= PauseChangedCallback;
        }

        #endregion

        #region Private methods

        private void ContinueButtonClickedCallback()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            PauseService.Instance.TogglePause();
        }
        
        private void MenuButtonClickedCallback()
        {
            AudioService.Instance.PlaySfx(_tapAudio);
            PauseService.Instance.TogglePause();
            GameService.Instance.Reset();
            SceneManager.LoadScene("MenuScene");
        }

        private void PauseChangedCallback(bool isPaused)
        {
            if (isPaused)
            {
                if (_fadeOutAnimation != null)
                {
                    StopCoroutine(_fadeOutAnimation);
                }

                _fadeInAnimation = StartCoroutine(PlayFadeInAnimation());
            }
            else
            {
                if (_fadeInAnimation != null)
                {
                    StopCoroutine(_fadeInAnimation);
                }

                _fadeOutAnimation = StartCoroutine(PlayFadeOutAnimation());
            }
        }
        
        private IEnumerator PlayFadeInAnimation()
        {
            _contentGameObject.SetActive(true);

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

            _contentGameObject.SetActive(false);
        }

        #endregion
    }
}