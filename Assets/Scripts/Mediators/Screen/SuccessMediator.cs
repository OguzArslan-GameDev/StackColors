using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using Assets.Scripts.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class SuccessMediator : Mediator
    {
        [Inject] public SuccessView view{ get; set;}
        [Inject] public IBuildModel BuildModel{ get; set;}

        public override void OnRegister()
        {
            base.OnRegister();
            view.SetSlider(BuildModel.BuildData.ProcessValue);
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

    }    
}

