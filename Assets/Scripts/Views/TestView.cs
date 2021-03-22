using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Views
{
    public class TestView : View
    {
        public event UnityAction<string> onTestEvent; 
        protected override void Start()
        {
            base.Start();
            Debug.Log("*** START ***");
            onTestEvent?.Invoke("View Start");
        }
    }
    
}
