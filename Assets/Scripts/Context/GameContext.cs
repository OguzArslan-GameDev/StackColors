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
            
            //*** Meditator & View bind
            mediationBinder.Bind<TestView>().To<TestMediator>();

            //*** Command bind
            //commandBinder.Bind(GameSignals.GameStart).To<TestCommand>();
        }

        public override void Launch()
        {
            base.Launch();
        }
    }
 
}
