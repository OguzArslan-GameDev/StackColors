using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class TapToStartMediator : Mediator
    {
        [Inject] public TapToStartView view{ get; set;}
        [Inject] public IGameModel GameModel{ get; set;}

        public override void OnRegister()
        {
            base.OnRegister();
            GameModel.GameData.Status = GameStatus.InMenu;
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

    }    
}

