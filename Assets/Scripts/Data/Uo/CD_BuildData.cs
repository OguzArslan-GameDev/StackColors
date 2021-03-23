using System.Collections.Generic;
using Assets.Scripts.Data.Vo;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Data.Uo
{
    [CreateAssetMenu(menuName = "Oguz/Data/Config/BuildData",order = 1)]
    public class CD_BuildData : SerializedScriptableObject
    {
        public GameObject BuildBase;
        public GameObject prefab;
        public List<BuildVo> list = new List<BuildVo>();
        public float ProcessValue;
        
        [Button("PROCESS BUILD DATA")]
        public void ProcessBuildData()
        {
            for (int i = 0; i < BuildBase.transform.childCount; i++)
            {
                BuildVo vo = new BuildVo();
                vo.Position = BuildBase.transform.GetChild(i).localPosition;
                vo.Rotation = BuildBase.transform.GetChild(i).localRotation;
                list.Add(vo);
            }
        }
        [Button("GENERETE BUILD")]
        public void GenereteBuild()
        {
            foreach (var vo in list)
            {
                var go = GameObject.Instantiate(prefab, BuildBase.transform);
                go.transform.parent = BuildBase.transform;
                go.transform.localPosition = vo.Position;
                go.transform.rotation = new Quaternion(vo.Rotation.x,vo.Rotation.y,vo.Rotation.z,vo.Rotation.w);
            }
        }
    }
}
