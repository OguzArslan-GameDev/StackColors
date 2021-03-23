using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Data.Uo;
using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class GameModel : IGameModel
    {
        private RD_GameData _gameData;

        #region PostConstruct

        public RD_GameData GameData
        {
            get
            {
                if (_gameData == null)
                    OnPostConstruct();
                return _gameData;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _gameData = Resources.Load<RD_GameData>("Data/GameData");
        }

        #endregion

        #region Func

        public void AddCollectedObject(TriggerIdentity ti)
        {
            _gameData.CollectedList.Add(ti);
            _gameData.LastPosition = new Vector3(_gameData.LastPosition.x,_gameData.LastPosition.y + _gameData.HeightFactor,_gameData.LastPosition.z);
        }
        public TriggerIdentity RemoveCollectedObject()
        {
            if (_gameData.CollectedList.Count == 0)
                return null;
            var ti = _gameData.CollectedList[_gameData.CollectedList.Count - 1];
            _gameData.CollectedList.Remove(ti);
            _gameData.LastPosition = new Vector3(_gameData.LastPosition.x,_gameData.LastPosition.y - _gameData.HeightFactor,_gameData.LastPosition.z);
            return ti;
        }
        public void Reset()
        {
            _gameData.CollectedList = new List<TriggerIdentity>();
            _gameData.LastPosition = _gameData.DefaultPosition;
        }

        public Vector3 GetLastPosition()
        {
            return _gameData.LastPosition;
        }

        #endregion
    }   
}
