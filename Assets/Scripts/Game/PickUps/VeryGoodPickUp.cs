using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class VeryGoodPickUp : PickUp
    {
        #region Variables

        [Header(nameof(GoodPickUp))]
        [SerializeField] private int _score = 3;
        [SerializeField] private int _lifeChange = 1;
        
        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            GameService.Instance.AddScore(_score);
            GameService.Instance.ChangeLife(_lifeChange);
        }
        
        #endregion
    }
}