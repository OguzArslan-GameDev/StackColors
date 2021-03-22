using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class LevelModel : ILevelModel
    {
        private CD_LevelData _levelData;

        #region PostConstruct

        public CD_LevelData LevelData
        {
            get
            {
                if (_levelData == null)
                    OnPostConstruct();
                return _levelData;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _levelData = Resources.Load<CD_LevelData>("Data/LevelData");
        }
        

        #endregion

        #region Func

        public GameObject GetLevel(int currentLevel)
        {
            return _levelData.Levels[currentLevel];
        }

        #endregion
    }   
}
