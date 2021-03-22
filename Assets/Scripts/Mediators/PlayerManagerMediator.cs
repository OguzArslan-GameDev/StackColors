using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
using FluffyUnderware.Curvy;
using Sirenix.OdinInspector;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class PlayerManagerMediator : Mediator
    {
        [Inject] public PlayerManager view{ get; set;}
        [Inject] public GameSignals GameSignals { get; set;}
        [Inject] public IPlayerModel PlayerModel { get; set;}
        [Inject] public IInputModel InputModel { get; set;}

        [Inject] public IGameModel GameModel { get; set;}
        public CurvySpline splineTEST;
        public override void OnRegister()
        {
            base.OnRegister();
            view.onLoadedPlayer += OnLoadedPlayer;
            
            GameSignals.Init.AddListener(Init);    
            GameSignals.PlayerMove.AddListener(OnMove);
            GameSignals.SwipeChanged.AddListener(OnSwipeChanged);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.onLoadedPlayer -= OnLoadedPlayer;

            GameSignals.Init.RemoveListener(Init);
            GameSignals.PlayerMove.RemoveListener(OnMove);
            GameSignals.SwipeChanged.RemoveListener(OnSwipeChanged);
        }

        [Button("** LOAD PLAYER **")]
        private void Init()
        {
            view.InitPlayer(PlayerModel.PlayerData.PlayerHolder);
        }
        
        private void OnLoadedPlayer(Transform transform)
        {
            PlayerModel.SetCharacter(transform);
            GameSignals.CharacterLoaded.Dispatch();
        }
        
        [Button("** PLAYER MOVE **")]
        private void OnMove()
        {
            view.Move(new PlayerVo()
            {
                Speed = PlayerModel.PlayerData.MoveSpeed,
                SplinePath = GameModel.GameData.Splines[SplineDirType.Mid]
            });
            
        }
        private void OnSwipeChanged()
        {
            view.Swipe(InputModel.GetSwipeValue());
            
        }
    }    
}

