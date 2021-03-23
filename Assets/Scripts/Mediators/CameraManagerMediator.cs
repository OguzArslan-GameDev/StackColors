using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class CameraManagerMediator : Mediator
    {
        [Inject] public CameraManager view{ get; set;}
        [Inject] public GameSignals GameSignals{ get; set;}
        [Inject] public IPlayerModel PlayerModel{ get; set;}

        public override void OnRegister()
        {
            base.OnRegister();
            GameSignals.CharacterLoaded.AddListener(SetCameraProperties);
            GameSignals.Success.AddListener(OpenCamera);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GameSignals.CharacterLoaded.RemoveListener(SetCameraProperties);
            GameSignals.Success.RemoveListener(OpenCamera);

        }

        private void SetCameraProperties()
        {
            view.SetCamProperties(PlayerModel.GetCharacter());
        }
        private void OpenCamera()
        {
            view.OpenCam(VCameraType.Finish);
        }
    }    
}

