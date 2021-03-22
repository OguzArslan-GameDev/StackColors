using Assets.Scripts.Data.Uo;

namespace Assets.Scripts.Model
{
    public interface IPlayerModel
    { 
        RD_PlayerData PlayerData { get; set; }
        int GetCurrentLevel();
    }   
}
