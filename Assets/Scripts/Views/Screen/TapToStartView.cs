using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class TapToStartView : View
    {
        private float SliderValue;
        [SerializeField] private Slider Slider;
        protected override void Start()
        {
            base.Start();
            HandAnim();
            
        }
        private void HandAnim(int endValue = 1)
        {
            DOTween.To(() => SliderValue, x => SliderValue = x, endValue, 1.5f).OnUpdate(SetSliderValue)
                .OnComplete(()=>HandAnimBack());
        }
        private void HandAnimBack(int endValue = 0)
        {
            DOTween.To(() => SliderValue, x => SliderValue = x, endValue, 1.5f).OnUpdate(SetSliderValue)
                .OnComplete(()=>HandAnim());
        }
        private void SetSliderValue()
        {
            Slider.value = SliderValue;
        }
    }
    
}
