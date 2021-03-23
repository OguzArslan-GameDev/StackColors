using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class BuildModel : IBuildModel
    {
        private CD_BuildData _buildData;

        #region PostConstruct

        public CD_BuildData BuildData
        {
            get
            {
                if (_buildData == null)
                    OnPostConstruct();
                return _buildData;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _buildData = Resources.Load<CD_BuildData>("Data/BuildData");
        }
        

        #endregion

    }   
}
