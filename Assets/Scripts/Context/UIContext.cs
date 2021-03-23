using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Assets.Scripts.Mediators;
using Assets.Scripts.Views;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Scripts.Context
{
    public class UIContext : MVCSContext
    {
        private ScreenSignals _screenSignals;

        public UIContext (MonoBehaviour view) : base(view)
        {
        }

        public UIContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            injectionBinder.Bind<ScreenSignals>().CrossContext().ToSingleton();
            _screenSignals = injectionBinder.GetInstance<ScreenSignals>();

            // injectionBinder.Bind<IGameModel>().To<GameModel>().CrossContext().ToSingleton();
            mediationBinder.Bind<ScreenManager>().To<ScreenManagerMediator>();
            mediationBinder.Bind<TapToStartView>().To<TapToStartMediator>();
            mediationBinder.Bind<SuccessView>().To<SuccessMediator>();
            //commandBinder.Bind(GameSignals.GameStart).To<TestCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            _screenSignals.OpenPanel.Dispatch(new PanelVo()
            {
                Layer = 0,
                PanelName = GameScreen.TapToStart.ToString()
            });
        }
    }
 
}
