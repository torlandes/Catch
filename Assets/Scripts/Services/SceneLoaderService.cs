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
        }

        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}