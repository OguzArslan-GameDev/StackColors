using Assets.Scripts.Data.Uo;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class PlayerModel : IPlayerModel
    {
        private RD_PlayerData _playerData;

        #region PostConstruct

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
        
        #endregion

        #region Func

        public int GetCurrentLevel()
        {
            return _playerData.CurrentLevel;
        }

        public void SetCharacter(Transform transform)
        {
            _playerData.PlayerCharacter = transform;
        }
        public Transform GetCharacter()
        {
            return _playerData.PlayerCharacter;
        }
        public void Reset()
        {
            _playerData.ColorType = ColorType.Yellow;
        }
        #endregion
    }   
}
