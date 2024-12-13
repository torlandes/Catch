using Catch.Utility;
using Catch.Game;

namespace Catch.Services
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        public Box Box { get; private set; }

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            Box.OnCreated += BasketCreatedCallback;
            Box.OnDestroyed += BasketDestroyedCallback;
        }

        private void OnDestroy()
        {
            Box.OnCreated -= BasketCreatedCallback;
            Box.OnDestroyed -= BasketDestroyedCallback;
        }

        #endregion

        #region Private methods

        private void BasketCreatedCallback(Box box)
        {
            Box = box;
        }

        private void BasketDestroyedCallback(Box obj)
        {
            Box = null;
        }

        #endregion
    }
}