using Assets.Scripts.Data.Vo;
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
        private Transform Player;
        private Transform PlayerHolder;
        [SerializeField] private Animator Animator;
        [SerializeField] private SplineController splineController;

        public void InitPlayer(GameObject playerObject)
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
    }
    
}
