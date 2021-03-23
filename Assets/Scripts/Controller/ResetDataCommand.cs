using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class ResetDataCommand : Command
    {
        [Inject] public IInputModel InputModel { get; set; }
        [Inject] public IGameModel GameModel { get; set; }
        [Inject] public IPlayerModel PlayerModel { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
            InputModel.Reset();
            GameModel.Reset();
            PlayerModel.Reset();
            GameSignals.RuntimeDataReset.Dispatch();
        }
    }
}