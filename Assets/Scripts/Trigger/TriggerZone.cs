using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ITriggered trigger))
            trigger.OnEnter(this);
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ITriggered trigger))
            trigger.OnExit(this);
    }
}