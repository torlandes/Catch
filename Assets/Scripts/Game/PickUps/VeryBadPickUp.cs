using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class VeryBadPickUp : PickUp
    {
        #region Variables

        [Header(nameof(BadPickUp))]
        [SerializeField] private int _score = -5;
        [SerializeField] private int _lifeChange = -1;
        
        [Header("VFX")]
        [SerializeField] private GameObject _vfxPrefab;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            GameService.Instance.AddScore(_score);
            GameService.Instance.ChangeLife(_lifeChange);
            
            if (_vfxPrefab != null)
            {
                Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
            }
        }
        
        #endregion
    }
}