using Assets.Scripts.Controller;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Assets.Scripts.Views;
using Assets.Scripts.Mediators;
using Assets.Scripts.Mediators.Inputs;
using Assets.Scripts.Model;
using Assets.Scripts.Views.Inputs;

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
            injectionBinder.Bind<IInputModel>().To<InputModel>().CrossContext().ToSingleton();

            //*** Mediator & View bind
            mediationBinder.Bind<LevelManager>().To<LevelManagerMediator>();
            mediationBinder.Bind<PlayerManager>().To<PlayerManagerMediator>();
            mediationBinder.Bind<CameraManager>().To<CameraManagerMediator>();
            
            //***Inputs View & Mediators
            mediationBinder.Bind<SwipeInputView>().To<SwipeInputMediator>();

            //*** Command bind
            commandBinder.Bind(_gameSignals.GameStart).InSequence()
                .To<ResetDataCommand>()
                .To<StartCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            Application.targetFrameRate = 60;
            _gameSignals.Init.Dispatch();
        }
    }
 
}
