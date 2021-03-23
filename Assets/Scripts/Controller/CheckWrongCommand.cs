using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CheckWrongCommand : Command
    {
        [Inject] public IGameModel GameModel { get; set; }
        
        [Inject] public ScreenSignals ScreenSignals { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
           if(GameModel.GameData.CollectedList.Count == 0)
           {
               GameModel.GameData.Status = GameStatus.Blocked;
               ScreenSignals.OpenPanel.Dispatch(new PanelVo()
               {
                   Layer = 1,
                   PanelName = GameScreen.Fail.ToString()
               });
               GameSignals.Fail.Dispatch();
           }
           //Hapticfeedback
           //Vibration.VibratePeek();
               
        }
    }
}