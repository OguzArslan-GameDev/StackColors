using Assets.Scripts.Data.Vo;
using Assets.Scripts.Entity;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
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
        public override void OnRegister()
        {
            base.OnRegister();
            view.onLoadedPlayer += OnLoadedPlayer;
            view.onCorrect += OnCorrect;
            view.onWrong += OnWrong;
            view.onChangeColor += OnChangeColor;
            view.onFinish += OnFinish;

            GameSignals.Init.AddListener(Init);    
            GameSignals.PlayerMove.AddListener(OnMove);
            GameSignals.SwipeChanged.AddListener(OnSwipeChanged);
            GameSignals.Fail.AddListener(OnFail);
            GameSignals.RuntimeDataReset.AddListener(OnRuntimeDataReset);

        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.onLoadedPlayer -= OnLoadedPlayer;
            view.onCorrect -= OnCorrect;
            view.onWrong -= OnWrong;
            view.onChangeColor -= OnChangeColor;
            view.onFinish -= OnFinish;

            GameSignals.Init.RemoveListener(Init);
            GameSignals.PlayerMove.RemoveListener(OnMove);
            GameSignals.SwipeChanged.RemoveListener(OnSwipeChanged);
            GameSignals.Fail.RemoveListener(OnFail);
            GameSignals.RuntimeDataReset.RemoveListener(OnRuntimeDataReset);

        }

        [Button("** LOAD PLAYER **")]
        private void Init()
        {
            view.InitPlayer(PlayerModel.PlayerData.PlayerHolder,PlayerModel.PlayerData.ColorType);
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
        private void OnFail()
        {
            view.Move(new PlayerVo()
            {
                Speed = 0f,
                SplinePath = GameModel.GameData.Splines[SplineDirType.Mid]
            });
            
        }
        private void OnFinish()
        {
            view.Move(new PlayerVo()
            {
                Speed = 0f,
                SplinePath = GameModel.GameData.Splines[SplineDirType.Mid]
            });
            GameSignals.Success.Dispatch();
        }
        private void OnSwipeChanged()
        {
            view.Swipe(InputModel.GetSwipeValue());
            
        }
        private void OnCorrect(TriggerIdentity ti)
        {
            if (view.Forklift == null)
                return;
            GameModel.AddCollectedObject(ti);
            ti.Collect(view.Forklift,GameModel.GetLastPosition());
            GameSignals.Correct.Dispatch();
        }
        private void OnWrong()
        {
            if (view.Forklift == null)
                return;
            var ti = GameModel.RemoveCollectedObject();
            GameSignals.Wrong.Dispatch();
            if (ti == null)
                return;
            ti.DestroySelf();
        }
        private void OnChangeColor(ColorType colorType)
        {
            PlayerModel.PlayerData.ColorType = colorType;
            view.SetColorType(colorType);
        }
        private void OnRuntimeDataReset()
        {
            view.SetColorType(PlayerModel.PlayerData.ColorType);
        }
    }    
}

