using UnityEngine;

public interface ITriggered
{
    public void OnEnter(MonoBehaviour triggerObject);
    public void OnExit(MonoBehaviour triggerObject);
}