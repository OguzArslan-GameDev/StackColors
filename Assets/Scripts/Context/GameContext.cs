using Assets.Scripts.Enums;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Assets.Scripts.Views;
using Assets.Scripts.Mediators;
using Assets.Scripts.Model;

namespace Assets.Scripts.Context
{
    public class GameContext : MVCSContext
    {
        private GameSignals _gameSignals;
        public GameContext (MonoBehaviour view) : base(view)
        {
        }

        public GameContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            //*** Signals injection bind
            injectionBinder.Bind<GameSignals>().CrossContext().ToSingleton();
            _gameSignals = injectionBinder.GetInstance<GameSignals>();
            
            //*** Data injection bind
            injectionBinder.Bind<IGameModel>().To<GameModel>().CrossContext().ToSingleton();
            injectionBinder.Bind<IPlayerModel>().To<PlayerModel>().CrossContext().ToSingleton();
            injectionBinder.Bind<ILevelModel>().To<LevelModel>().CrossContext().ToSingleton();

            //*** Mediator & View bind
            mediationBinder.Bind<LevelManager>().To<LevelManagerMediator>();

            //*** Command bind
            //commandBinder.Bind(_gameSignals.Init).To<TestCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            Application.targetFrameRate = 60;
            _gameSignals.Init.Dispatch();
        }
    }
 
}
