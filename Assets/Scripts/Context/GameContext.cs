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
            injectionBinder.Bind<IBuildModel>().To<BuildModel>().CrossContext().ToSingleton();

            //*** Mediator & View bind
            mediationBinder.Bind<LevelManager>().To<LevelManagerMediator>();
            mediationBinder.Bind<PlayerManager>().To<PlayerManagerMediator>();
            mediationBinder.Bind<CameraManager>().To<CameraManagerMediator>();
            
            //***Inputs View & Mediators
            mediationBinder.Bind<SwipeInputView>().To<SwipeInputMediator>();

            //*** Command bind
            commandBinder.Bind(_gameSignals.Init).To<InitCommand>();
            commandBinder.Bind(_gameSignals.GameStart).InSequence()
                .To<ResetDataCommand>()
                .To<StartCommand>();
            commandBinder.Bind(_gameSignals.Correct).To<CheckCorrectCommand>();
            commandBinder.Bind(_gameSignals.Wrong).To<CheckWrongCommand>();
            commandBinder.Bind(_gameSignals.Success).To<BuildSystemCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            Application.targetFrameRate = 60;
            _gameSignals.Init.Dispatch();
        }
    }
 
}
