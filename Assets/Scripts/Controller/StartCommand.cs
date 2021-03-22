using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class StartCommand : Command
    {
        [Inject] public ScreenSignals ScreenSignals { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }
        [Inject] public IGameModel GameModel { get; set; }

        public override void Execute()
        {
            Debug.Log("/StartCommand/ --> Execute");
            ScreenSignals.ClearPanel.Dispatch(0);
            GameSignals.PlayerMove.Dispatch();
            GameModel.GameData.Status = GameStatus.InGame;

        }
    }
}