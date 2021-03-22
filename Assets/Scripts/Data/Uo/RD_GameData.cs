using Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Runtime/GameData",order = 0)]
    public class RD_GameData : SerializedScriptableObject
    {
        [Title("Game Stats")] 
        public GameStatus Status;
    }
}
