using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views.Inputs;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators.Inputs
{
    public class SwipeInputMediator : Mediator
    {
        [Inject] public SwipeInputView view{ get; set;}
        [Inject] public IGameModel GameModel { get; set;}
        [Inject] public IInputModel InputModel { get; set;}

        [Inject] public GameSignals GameSignals { get; set;}

        public override void OnRegister()
        {
            base.OnRegister();
            view.onSwipeValueChange += OnSwipeValueChange;
            view.onTap += OnTap;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.onSwipeValueChange -= OnSwipeValueChange;
            view.onTap -= OnTap;
        }

        private void OnSwipeValueChange(float value)
        {
            if(GameModel.GameData.Status == GameStatus.Blocked || GameModel.GameData.Status == GameStatus.InMenu)
                return;

            float diff = value * InputModel.GetSensivity();
            float swipeValue = InputModel.GetSwipeValue();
            swipeValue = (swipeValue + diff) < InputModel.GetLeftLimit() ? InputModel.GetLeftLimit() : ((swipeValue + diff) > InputModel.GetRightLimit() ? InputModel.GetRightLimit() : (swipeValue + diff));
            InputModel.SetSwipeValue(swipeValue);
            GameSignals.SwipeChanged.Dispatch();
        }
        private void OnTap()
        {
            if(GameModel.GameData.Status == GameStatus.InMenu)
               GameSignals.GameStart.Dispatch();
        }
    }    
}

