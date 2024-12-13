// using Catch.Services;
// using UnityEngine;
//
// namespace Catch.Game.PickUps
// {
//     public class LifePickUp : PickUp
//     {
//         #region Variables
//
//         [SerializeField] private int _livesToAdd = 1;
//
//         #endregion
//
//         #region Protected methods
//
//         protected override void PerformCatchedActions()
//         {
//             base.PerformCatchedActions();
//             GameService.Instance.ChangeLife(_livesToAdd);
//         }
//
//         protected override void PerformMissedActions() { }
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
// //     public class LifePickUp : PickUps
// //     {
// //         #region Variables
// //
// //         [Header(nameof(LifePickUp))]
// //         [SerializeField] private int _lifeChange = 1;
// //
// //         #endregion
// //
// //         #region Protected methods
// //
// //         protected override void PerformActions()
// //         {
// //             base.PerformActions();
// //
// //             GameService.Instance.ChangeLife(_lifeChange);
// //         }
// //
// //         #endregion
// //     }
// // }