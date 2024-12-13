using System;
using Catch.Services;
using UnityEngine;

namespace Catch.Game
{
    public class Box : MonoBehaviour
    {
        #region Events

        public static event Action<Box> OnCreated;
        public static event Action<Box> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void Update()
        {
            if (PauseService.Instance.IsPaused || GameService.Instance.IsGameOver)
            {
                return;
            }
            
            MoveWithMouse();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                SetXPosition(worldPosition.x);
            }

            // Vector3 mousePosition = Input.mousePosition;
            // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //
            // SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = x;
            transform.position = currentPosition;
        }

        #endregion
    }
}