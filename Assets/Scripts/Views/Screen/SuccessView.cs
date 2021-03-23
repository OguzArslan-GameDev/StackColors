using DG.Tweening;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class SuccessView : View
    {
        private float SliderValue;
        [SerializeField] private Slider Slider;
        [SerializeField] private TextMeshProUGUI Text;

        public void SetSlider(float value)
        {
            Text.SetText("%"+value.ToString("00"));
            Slider.value = value;
        }
    }
    
}
