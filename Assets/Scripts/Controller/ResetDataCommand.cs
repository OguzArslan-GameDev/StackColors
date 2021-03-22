using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class ResetDataCommand : Command
    {
        [Inject] public IInputModel InputModel { get; set; }

        public override void Execute()
        {
            InputModel.Reset();

        }
    }
}