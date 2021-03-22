using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class GameModel : IGameModel
    {
        public string data {get;set;}

        /*private CD_GameModel _gameModel;

        public CD_GameModel GameData
        {
            get
            {
                if (_gameModel == null)
                    OnPostConstruct();
                return _gameModel;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _gameModel = Resources.Load<CD_GameModel>("Data/GameModel");
        }*/
    }   
}
