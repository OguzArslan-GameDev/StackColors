using Assets.Scripts.Context;
using strange.extensions.context.impl;

namespace Assets.Scripts.Root
{
    public class GameRoot : ContextView
    {
        void Awake()
        {
            context = new GameContext(this);
        }
    }

}
