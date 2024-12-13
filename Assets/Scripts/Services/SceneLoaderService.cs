using Catch.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Catch.Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Public methods

        public void ExitGame()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}