using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public interface ILevelModel
    { 
        CD_LevelData LevelData { get; set; }
        GameObject GetLevel(int currentLevel);

    }   
}
