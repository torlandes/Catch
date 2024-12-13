using System;
using Catch.Utility;
using UnityEngine;

namespace Catch.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Events

        public event Action<bool> OnChanged;

        #endregion
        
        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Public methods

        public void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            OnChanged?.Invoke(IsPaused);
        }

        #endregion
    }
}