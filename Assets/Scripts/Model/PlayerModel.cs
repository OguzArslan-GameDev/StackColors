using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class PlayerModel : IPlayerModel
    {
        private RD_PlayerData _playerData;

        public RD_PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                    OnPostConstruct();
                return _playerData;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _playerData = Resources.Load<RD_PlayerData>("Data/PlayerData");
        }
    }   
}
