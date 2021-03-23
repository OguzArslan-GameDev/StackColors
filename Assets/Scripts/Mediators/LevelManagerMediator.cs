using Assets.Scripts.Data.Vo;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
using FluffyUnderware.Curvy.Controllers;
using Sirenix.OdinInspector;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class LevelManagerMediator : Mediator
    {
        [Inject] public LevelManager view{ get; set;}
        [Inject] public GameSignals GameSignals { get; set;}
        [Inject] public IPlayerModel PlayerModel { get; set;}
        [Inject] public ILevelModel LevelModel { get; set;}
        [Inject] public IGameModel GameModel { get; set;}
        [Inject] public IBuildModel BuildModel { get; set;}

        public override void OnRegister()
        {
            base.OnRegister();
            view.onSetSpline += SetSpline;
            view.onSetBuildBase += SetBuildBase;

            GameSignals.Init.AddListener(Init);            
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.onSetSpline -= SetSpline;
            view.onSetBuildBase -= SetBuildBase;

            GameSignals.Init.RemoveListener(Init);
        }

        [Button("** LOAD LEVEL **")]
        private void Init()
        {
            view.InitLevel(LevelModel.GetLevel(PlayerModel.GetCurrentLevel()));
        }
        
        private void SetSpline(SplineVo vo)
        {
            GameModel.GameData.Splines = vo.Dictionary;
        }
        private void SetBuildBase(Transform transform)
        {
            BuildModel.BuildData.BuildBase = transform.gameObject;
        }
    }    
}

