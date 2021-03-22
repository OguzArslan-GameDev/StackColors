using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Views.Inputs
{
    public class SwipeInputView : View
    {
        public event UnityAction<float> onSwipeValueChange;
        public event UnityAction onTap;

        private float firstPoint;
        private float lastPoint; 
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPoint = Input.mousePosition.x;
                onTap?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                lastPoint = Input.mousePosition.x;
                onSwipeValueChange?.Invoke((lastPoint-firstPoint));
                firstPoint = lastPoint;
            }

        }
    }
    
}
