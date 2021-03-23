using System.Collections.Generic;
using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using FluffyUnderware.Curvy;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Views
{
    public class LevelManager : View
    {
        public event UnityAction<SplineVo> onSetSpline;
        public event UnityAction<Transform> onSetBuildBase;

        private Dictionary<SplineDirType,CurvySpline> tempDic;
        private Transform BuildBase;
        public void InitLevel(GameObject level)
        {
            tempDic = new Dictionary<SplineDirType, CurvySpline>();
            this.transform.DestroyChildren();
            var go = GameObject.Instantiate(level, this.transform.position, Quaternion.identity);
            go.transform.parent = this.transform;
            BuildBase = go.transform.FindInChildrenWithName("Final").FindInChildrenWithName("BuildBase");
            SetBuildBase();
            SetSplines(go.transform);
        }

        private void SetSplines(Transform level)
        {
            var SplineHolder = level.FindInChildrenWithName("Splines");
            
            var left = SplineHolder.FindInChildrenWithName(SplineDirType.Left.ToString());
            var mid = SplineHolder.FindInChildrenWithName(SplineDirType.Mid.ToString());
            var right = SplineHolder.FindInChildrenWithName(SplineDirType.Right.ToString());
            
            tempDic.Add(SplineDirType.Left,left.GetComponent<CurvySpline>());
            tempDic.Add(SplineDirType.Mid,mid.GetComponent<CurvySpline>());
            tempDic.Add(SplineDirType.Right,right.GetComponent<CurvySpline>());
            
            onSetSpline?.Invoke(new SplineVo()
            {
                Dictionary = tempDic
            });
        } 
        private void SetBuildBase()
        {
            onSetBuildBase?.Invoke(BuildBase);
        } 
       
    }
    
}
