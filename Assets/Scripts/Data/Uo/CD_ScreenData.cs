using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Config/ScreenData",order = 1)]
    public class CD_ScreenData : SerializedScriptableObject
    { 
        [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.CollapsedFoldout)]
        public Dictionary<string,GameObject> Dictionary = new Dictionary<string, GameObject>();
    }
}
