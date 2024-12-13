using Catch.Services;
using UnityEngine;

namespace Catch.Game.PickUps
{
    public class GoodPickUp : PickUp
    {
        #region Variables

        [Header(nameof(GoodPickUp))]
        [SerializeField] private int _score = 1;

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

// using Catch.Services;
// using UnityEngine;
//
// namespace Catch.Game.PickUps
// {
//     public class GoodPickUp : PickUp
//     {
//         #region Variables
//
//         [SerializeField] private int _scoreValue = 8;
//         [SerializeField] private int _livesPenalty = -1;
//
//         #endregion
//
//         #region Unity lifecycle
//
//         private void OnTriggerEnter2D(Collider2D other)
//         {
//             if (other.CompareTag(Tag.Box))
//             {
//                 PerformCatchedActions();
//                 Destroy(gameObject);
//             }
//             
//             if (other.CompareTag(Tag.DeathZone))
//             {
//                 PerformMissedActions();
//                 Destroy(gameObject);
//             }
//         }
//
//         #endregion
//
//         #region Protected methods
//
//         protected override void PerformCatchedActions()
//         {
//             base.PerformCatchedActions();
//             GameService.Instance.AddScore(_scoreValue);
//         }
//
//         protected override void PerformMissedActions()
//         {
//             base.PerformMissedActions();
//             GameService.Instance.ChangeLife(_livesPenalty);
//         }
//
//         #endregion
//     }
// }
//
// // using Services;
// // using UnityEngine;
// //
// // namespace Game.PickUps
// // {
// //     public class GoodPickUp : PickUps
// //     {
// //         #region Variables
// //
// //         [Header(nameof(GoodPickUp))]
// //         [SerializeField] private int _maxPoints = 10;
// //
// //         #endregion
// //
// //         #region Protected methods
// //
// //         protected override void PerformActions()
// //         {
// //             base.PerformActions();
// //             GameService.Instance.AddScore(_maxPoints);
// //         }
// //
// //         #endregion
// //     }
// // }