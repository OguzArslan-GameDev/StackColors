using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class TestMediator : Mediator
    {
        [Inject] public TestView view{ get; set;}
        public override void OnRegister()
        {
            base.OnRegister();
            view.onTestEvent += OnTestEvent;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.onTestEvent -= OnTestEvent;
        }

        public void OnTestEvent(string value)
        {
            Debug.Log("*** TEST MEDIATOR START : "+value);
        }
    }    
}

