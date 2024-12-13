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

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnExitButtonClicked()
        {
            SceneLoaderService.Instance.ExitGame();
        }

        private void OnStartButtonClicked()
        {
            SceneLoaderService.Instance.StartGame();
        }

        #endregion
    }
}