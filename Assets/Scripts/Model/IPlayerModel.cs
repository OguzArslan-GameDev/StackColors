using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public interface IPlayerModel
    { 
        RD_PlayerData PlayerData { get; set; }
        int GetCurrentLevel();
        void SetCharacter(Transform transform);
        Transform GetCharacter();
        void Reset();

    }   
}
