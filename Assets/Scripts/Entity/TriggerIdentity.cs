using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class TriggerIdentity : MonoBehaviour
    {
        public TriggerType Type;
        public ColorType Color;

        public void Collect(Transform parent,Vector3 position)
        {
            transform.parent = parent;
            transform.localPosition = position;
        }
        public void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }
}
