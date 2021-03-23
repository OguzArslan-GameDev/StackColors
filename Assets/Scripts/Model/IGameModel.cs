using Assets.Scripts.Data.Uo;
using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public interface IGameModel
    { 
        RD_GameData GameData { get; set; }
        void AddCollectedObject(TriggerIdentity ti);
        TriggerIdentity RemoveCollectedObject();
        Vector3 GetLastPosition();
        void Reset();

    }   
}
