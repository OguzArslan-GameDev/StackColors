using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class GameModel : IGameModel
    {
        private RD_GameData _gameData;

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
    }   
}
