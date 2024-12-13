using UnityEngine;

namespace Catch.Game
{
    public class DeathZone : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _isActive = true;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isActive)
            {
                return;
            }
            Destroy(other.gameObject);
        }

        #endregion
    }
}