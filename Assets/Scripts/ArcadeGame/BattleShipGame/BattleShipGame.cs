using UnityEngine;

namespace BattleShipGame
{
    public class BattleShipGame : ArcadeGame
    {
        [SerializeField] private float speed;
        [SerializeField] private RectTransform canvas;
        [SerializeField] private RectTransform map;
        [SerializeField] private ShipSpawner shipSpawner;
        [SerializeField] private Torpedo torpedo;
        private Ship _currentShip;

        private float _maxMoveX;
        private int _points;

        private void Start()
        {
            _currentShip = shipSpawner.GetShip();
            _arcadeGameInput.OnAction += () => torpedo.Shoot(_currentShip);
            _arcadeGameInput.OnExit += () => shipSpawner.StopMove();
            _maxMoveX = (map.rect.width - canvas.rect.width) / 2;
        }

        public override void StartGame()
        {
            base.StartGame();
            shipSpawner.StartMove();
        }

        private void Update()
        {
            map.transform.Translate(new Vector2(_arcadeGameInput.Movement.x * speed * Time.deltaTime, 0));
            var clampPosition = map.localPosition;
            clampPosition.x = Mathf.Clamp(clampPosition.x, -_maxMoveX, _maxMoveX);
            map.localPosition = clampPosition;
        }
    }
}