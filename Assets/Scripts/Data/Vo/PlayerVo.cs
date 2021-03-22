using System.Collections.Generic;
using Assets.Scripts.Enums;
using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

namespace Assets.Scripts.Data.Vo
{
    [System.Serializable]
    public class PlayerVo
    {
        public CurvySpline SplinePath;
        public float Speed;
    }
}