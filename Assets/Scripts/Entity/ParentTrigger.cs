using Assets.Scripts.Views;
using UnityEngine;

public class ParentTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        var parentView = GetComponentInParent<PlayerManager>();
        parentView.OnTrigger(other);
    }
}
