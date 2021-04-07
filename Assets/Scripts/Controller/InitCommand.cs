using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using strange.extensions.command.impl;

namespace Assets.Scripts.Controller
{
    public class InitCommand : Command
    {
        [Inject] public ScreenSignals ScreenSignals { get; set; }
        public override void Execute()
        {
            ScreenSignals.OpenPanel.Dispatch(new PanelVo()
            {
                Layer = 0,
                PanelName = GameScreen.TapToStart.ToString()
            });
        }
    }
}