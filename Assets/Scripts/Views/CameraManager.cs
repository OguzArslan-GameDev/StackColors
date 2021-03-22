using System.Collections.Generic;
using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Views
{
    public class CameraManager : View
    {
        [SerializeField] private List<CameraVo> list = new List<CameraVo>();
        
        public void SetCamProperties(Transform character)
        {
            foreach (var vo in list)
            {
                if (vo.IsFollowCam)
                {
                    vo.Cam.Follow = character;
                    vo.Cam.LookAt = character;
                }
            }
        }
    }
    
}
