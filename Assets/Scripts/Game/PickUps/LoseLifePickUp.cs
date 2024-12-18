using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class LoseLifePickUp : PickUp
    {
        #region Variables

        [Header(nameof(LifePickUp))]
        [SerializeField] private int _lifeChange = -1;
        [SerializeField] private GameObject _vfxPrefab;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeLife(_lifeChange);
            
            if (_vfxPrefab != null)
            {
                Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
            }
        }

        #endregion
    }
}