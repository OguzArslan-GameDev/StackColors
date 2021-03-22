using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Config/LevelData",order = 0)]
    public class CD_LevelData : SerializedScriptableObject
    {
        public List<GameObject> Levels = new List<GameObject>();
    }
}
