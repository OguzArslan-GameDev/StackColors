using System;
using Assets.Scripts.Data.Uo;
using Assets.Scripts.Data.Vo;
using Assets.Scripts.Entity;
using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using FluffyUnderware.Curvy.Controllers;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Views
{
    public class PlayerManager : View
    {
        public event UnityAction<Transform> onLoadedPlayer;
        public event UnityAction<TriggerIdentity> onCorrect;
        public event UnityAction<ColorType> onChangeColor;

        public event UnityAction onWrong;

        private Transform Player;
        private Transform PlayerHolder;
        public Transform Forklift;
        private ColorType ColorType;
        [SerializeField] private Animator Animator;
        [SerializeField] private SplineController splineController;
        [SerializeField] private CD_ColorData ColorData;

        public void InitPlayer(GameObject playerObject,ColorType colorType)
        {
            this.transform.DestroyChildren();
            var go = GameObject.Instantiate(playerObject, this.transform.position, Quaternion.identity);
            go.transform.parent = this.transform;
            PlayerHolder = go.transform;
            Player = go.transform.FindInChildrenWithName("Player");
            if(Player != null)
                onLoadedPlayer?.Invoke(Player);
            Animator = Player.GetComponentInChildren<Animator>();
            splineController = PlayerHolder.GetComponent<SplineController>();
            Forklift = GetComponentInChildren<BoxCollider>().transform;
            ColorType = colorType;
        }

        public void Move(PlayerVo vo)
        {
            splineController.enabled = true;
            splineController.Spline = vo.SplinePath;
            splineController.Speed = vo.Speed;
            Animator.SetTrigger("DORun");
        }
        
        public void Swipe(float position)
        {
            Player.transform.position = new Vector3(position,Player.transform.position.y,Player.transform.position.z);
        }

        public void OnTrigger(Collider obj)
        {
            var triggerIdentity = obj.GetComponent<TriggerIdentity>();
            if (triggerIdentity.Type == TriggerType.Block)
            {
                if(ColorType == triggerIdentity.Color)
                    onCorrect?.Invoke(triggerIdentity);
                else
                    onWrong?.Invoke();
            }
            else if(triggerIdentity.Type == TriggerType.Shifter)
            {
                onChangeColor?.Invoke(triggerIdentity.Color);
            }
        }
        public void SetColorType(ColorType colorType)
        {
            ColorType = colorType;
            SetMaterial();
        }
        public void SetMaterial()
        {
            var color = ColorData.list[ColorType];
            var characterMesh = PlayerHolder.GetComponentInChildren<SkinnedMeshRenderer>();
            var meshRenderer = PlayerHolder.GetComponentsInChildren<MeshRenderer>();
            characterMesh.material.SetColor("_BaseColor",color);
            foreach (var obj in meshRenderer)
            {
                obj.material.SetColor("_BaseColor",color);
            }
        }
    }
    
}
