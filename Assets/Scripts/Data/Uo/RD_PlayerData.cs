using Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Runtime/PlayerData",order = 1)]
    public class RD_PlayerData : SerializedScriptableObject
    {
        public int CurrentLevel;
        public int CurrentScore;
        public int HightScore;
        public GameObject PlayerHolder;

        [Title("Properties")] 
        public float MoveSpeed;
        public float TurnSensivity;

        [Title("Runtime")] 
        public Transform PlayerCharacter;
        public ColorType ColorType;

    }
}
