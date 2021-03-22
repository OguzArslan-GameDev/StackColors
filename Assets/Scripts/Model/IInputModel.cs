using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public interface IInputModel
    { 
        RD_SwipeInputData SwipeInputData { get; set; }
        float GetSensivity();
        float GetLeftLimit();
        float GetRightLimit();
        float GetSwipeValue();
        void SetSwipeValue(float value);
        
        void Reset();

    }   
}
