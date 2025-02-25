using UnityEngine;

public class BattleShipGame : ArcadeGame
{
    [SerializeField] private float speed;
    [SerializeField] private Transform map;

    private void Start()
    {
        _arcadeGameInput.OnAction += DoAction;
    }

    private void Update()
    {
        map.transform.Translate(new Vector2(_arcadeGameInput.Movement.x * speed, 0));
    }

    private void DoAction()
    {
        Debug.Log("Action!");
    }
}