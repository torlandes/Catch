using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class BadPickUp : PickUp
    {
        #region Variables

        [Header(nameof(BadPickUp))]
        [SerializeField] private int _score = -1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            GameService.Instance.AddScore(_score);
        }
        
        #endregion
    }
}