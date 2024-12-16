using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class LifePickUp : PickUp
    {
        #region Variables

        [Header(nameof(LifePickUp))]
        [SerializeField] private int _lifeChange = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeLife(_lifeChange);
        }

        #endregion
    }
}