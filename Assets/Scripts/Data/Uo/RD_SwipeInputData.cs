using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Runtime/SwipeInputData",order = 2)]
    public class RD_SwipeInputData : SerializedScriptableObject
    {
        public float LeftLimit;
        public float RightLimit;
        public float Sensivity;

        public float SwipeValue;
    }
}
