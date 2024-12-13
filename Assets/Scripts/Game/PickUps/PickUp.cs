using Catch.Services;
using Catch.Game;
using UnityEngine;

namespace Catch.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _pickUpVfxPrefab;
        [SerializeField] private AudioClip _pickUpAudio;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Box))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            AudioService.Instance.PlaySfx(_pickUpAudio);
            if (_pickUpVfxPrefab != null)
            {
                Instantiate(_pickUpVfxPrefab, transform.position, Quaternion.identity);
            }
        }

        #endregion
    }
}