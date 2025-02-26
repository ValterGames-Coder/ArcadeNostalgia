using UnityEngine;

namespace BattleShipGame
{
    public class BattleShipGame : ArcadeGame
    {
        [SerializeField] private float speed;
        [SerializeField] private RectTransform canvas;
        [SerializeField] private RectTransform map;
        [SerializeField] private ShipSpawner shipSpawner;

        private float _maxMoveX;

        private void Start()
        {
            _arcadeGameInput.OnAction += DoAction;
            _maxMoveX = (map.rect.width - canvas.rect.width) / 2;
        }

        private void Update()
        {
            map.transform.Translate(new Vector2(_arcadeGameInput.Movement.x * speed, 0));
            Vector3 clampPosition = map.localPosition;
            clampPosition.x = Mathf.Clamp(clampPosition.x, -_maxMoveX, _maxMoveX);
            map.localPosition = clampPosition;
        }

        private void DoAction()
        {
            shipSpawner.StartMove();
        }
    }
}