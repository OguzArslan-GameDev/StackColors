using System.Collections.Generic;
using Assets.Scripts.Enums;
using FluffyUnderware.Curvy;

namespace Assets.Scripts.Data.Vo
{
    [System.Serializable]
    public class SplineVo
    {
        public Dictionary<SplineDirType,CurvySpline> Dictionary = new Dictionary<SplineDirType, CurvySpline>();
    }
}