using Assets.Scripts.Data.Vo;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using DG.Tweening;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class BuildSystemCommand : Command
    {
        [Inject] public IGameModel GameModel { get; set; }
        
        [Inject] public IBuildModel BuildModel { get; set; }
        [Inject] public ScreenSignals ScreenSignals { get; set; }

        private float durationFactor = 0.05f;
        private float duration = 2.5f;

        private int index;

        public override void Execute()
        {
            index = 0;
            var value = (GameModel.GameData.CollectedList.Count * 100f) / BuildModel.BuildData.list.Count;
            BuildModel.BuildData.ProcessValue = value;
            ScreenSignals.OpenPanel.Dispatch(new PanelVo()
            {
                Layer = 0,
                PanelName = GameScreen.Success.ToString()
            });
            foreach (var collectedObject in GameModel.GameData.CollectedList)
            {
                collectedObject.transform.parent = BuildModel.BuildData.BuildBase.transform;
                collectedObject.transform.DOLocalMove(BuildModel.BuildData.list[index].Position,duration).SetEase(Ease.Linear);
                collectedObject.transform.rotation = BuildModel.BuildData.list[index].Rotation;
                index++;
                duration -= durationFactor;
            }
        }
    }
}