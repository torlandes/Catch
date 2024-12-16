using Catch.Services;
using UnityEngine;

namespace Catch.Game
{
    public class DeathZone : MonoBehaviour
    {
        #region Variables
        
        [Header("Settings")]
        [SerializeField] private bool _isActive = true;
        
        [Header("Audio")]
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioClip _audioFallClip;
        
        [Header("VFX")]
        [SerializeField] private GameObject _vfxPrefab;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive)
            {
                return;
            }

            if (other.CompareTag(Tag.GoodPickUp))
            {
                GameService.Instance.ChangeLife(-1);
                AudioService.Instance.PlaySfx(_audioClip);
                if (_vfxPrefab != null)
                {
                    Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
                }
            }

            else if (other.CompareTag(Tag.OtherPickUp))
            {
                AudioService.Instance.PlaySfx(_audioFallClip);
                Destroy(other.gameObject);
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}