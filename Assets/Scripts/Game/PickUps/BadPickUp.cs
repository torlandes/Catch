// using Catch.Services;
// using UnityEngine;
//
// namespace Catch.Game.PickUps
// {
//     public class BadPickUp : PickUp
//     {
//         #region Variables
//
//         [SerializeField] private int _scoreValue = -32;
//
//         #endregion
//
//         #region Protected methods
//
//         protected override void PerformCatchedActions()
//         {
//             GameService.Instance.AddScore(_scoreValue);
//         }
//
//         protected override void PerformMissedActions() { }
//
//         #endregion
//     }
// }
//
//
// // using Services;
// // using UnityEngine;
// //
// // namespace Game.PickUps
// // {
// //     public class BadPickUp : PickUps
// //     {
// //         #region Variables
// //
// //         [Header(nameof(BadPickUp))]
// //         [SerializeField] private int _minPoints = 5;
// //
// //         #endregion
// //
// //         #region Protected methods
// //
// //         protected override void PerformActions()
// //         {
// //             base.PerformActions();
// //             GameService.Instance.AddScore(-_minPoints);
// //         }
// //
// //         #endregion
// //     }
// // }