using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Scripts.Context
{
    public class UIContext : MVCSContext
    {
        public UIContext (MonoBehaviour view) : base(view)
        {
        }

        public UIContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            // injectionBinder.Bind<IGameModel>().To<GameModel>().CrossContext().ToSingleton();
            // mediationBinder.Bind<TesterView>().To<TesterMediator>();
            //commandBinder.Bind(GameSignals.GameStart).To<TestCommand>();
        }

        public override void Launch()
        {
            base.Launch();
        }
    }
 
}
