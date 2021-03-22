﻿using System.Collections.Generic;
using Assets.Scripts.Enums;
using FluffyUnderware.Curvy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Runtime/GameData",order = 0)]
    public class RD_GameData : SerializedScriptableObject
    {
        [Title("Game Stats")] 
        public GameStatus Status;
        
        [Title("Runtime Map")] 
        [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.CollapsedFoldout)]
        public Dictionary<SplineDirType,CurvySpline> Splines = new Dictionary<SplineDirType, CurvySpline>();
    }
}
