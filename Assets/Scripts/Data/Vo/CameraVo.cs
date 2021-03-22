using System.Collections.Generic;
using Assets.Scripts.Enums;
using Cinemachine;
using FluffyUnderware.Curvy;

namespace Assets.Scripts.Data.Vo
{
    [System.Serializable]
    public class CameraVo
    {
        public VCameraType Type;
        public CinemachineVirtualCamera Cam;
        public bool IsFollowCam;
    }
}