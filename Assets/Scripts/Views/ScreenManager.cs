using System.Collections.Generic;
using Assets.Scripts.Data.Uo;
using Assets.Scripts.Data.Vo;
using Assets.Scripts.Extensions;
using Sirenix.OdinInspector;
using strange.extensions.mediation.impl;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class ScreenManager : View
    {

        public List<Transform> Layer;
        public GameObject MainScreen;
       

        public void OpenPanel(PanelVo vo)
        {
            Layer[vo.Layer].DestroyChildren();
            GameObject go = Resources.Load<GameObject>("Screen/"+vo.PanelName);
            //GameObject go = Screens.Dictionary[vo.PanelName];
            GameObject screen = Instantiate(go,Layer[vo.Layer]);
            screen.transform.localPosition = Vector3.zero;
        }

        public void ClearPanel(int layer)
        {
            Layer[layer].DestroyChildren();
        }
       
    }
}