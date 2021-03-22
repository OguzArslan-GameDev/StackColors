using Assets.Scripts.Data.Uo;
using UnityEngine;

namespace Assets.Scripts.Model
{
 
    public class InputModel : IInputModel
    {
        private RD_SwipeInputData _swipeInputData;

        #region PostConstruct

        public RD_SwipeInputData SwipeInputData
        {
            get
            {
                if (_swipeInputData == null)
                    OnPostConstruct();
                return _swipeInputData;
            }
            set { }
        }

        [PostConstruct]
        public void OnPostConstruct()
        {
            _swipeInputData = Resources.Load<RD_SwipeInputData>("Data/SwipeInputData");
        }
        

        #endregion

        #region Func

        public float GetSensivity()
        {
            return _swipeInputData.Sensivity;
        }

        public float GetLeftLimit()
        {
            return _swipeInputData.LeftLimit;
        }

        public float GetRightLimit()
        {
            return _swipeInputData.RightLimit;
        }

        public float GetSwipeValue()
        {
            return _swipeInputData.SwipeValue;
        }

        public void SetSwipeValue(float value)
        {
            _swipeInputData.SwipeValue = value;
        }
        public void Reset()
        {
            _swipeInputData.SwipeValue = 0f;
        }
        #endregion
    }   
}
