using System.Collections.Generic;
using Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Config/ColorData",order = 2)]
    public class CD_ColorData : SerializedScriptableObject
    {
        public Dictionary<ColorType,Color> list = new Dictionary<ColorType, Color>();
    }
}
