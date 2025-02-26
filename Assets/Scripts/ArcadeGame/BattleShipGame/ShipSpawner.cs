using System.Collections;
using UnityEngine;

namespace BattleShipGame
{
    public class ShipSpawner : MonoBehaviour
    {
        [SerializeField] private Ship prefabShip;
        [SerializeField] private Transform startPosition, endPosition;
        [SerializeField] private Sprite[] sprites;
        private Coroutine _moveShipsCoroutine;

        public void StartMove() => _moveShipsCoroutine = StartCoroutine(MoveShips());
        public void StopMove() => StopCoroutine(_moveShipsCoroutine);

        private IEnumerator MoveShips()
        {
            while (true)
            {
                prefabShip.Init(sprites[Random.Range(0, sprites.Length)], Random.Range(1f, 3f), Vector3.right);
                prefabShip.transform.localPosition = startPosition.localPosition;
                yield return new WaitUntil(() => (prefabShip.transform.localPosition - endPosition.localPosition).sqrMagnitude < 1f);
            }
        }
    }
}