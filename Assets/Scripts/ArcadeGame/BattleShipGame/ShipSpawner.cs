using System.Collections;
using UnityEngine;

namespace BattleShipGame
{
    public class ShipSpawner : MonoBehaviour
    {
        [SerializeField] private Ship prefabShip;
        [SerializeField] private ShipConfig[] shipConfigs;
        [SerializeField] private Transform startPosition, endPosition;
        private Coroutine _moveShipsCoroutine;

        public void StartMove() => _moveShipsCoroutine = StartCoroutine(MoveShips());
        public void StopMove() => StopCoroutine(_moveShipsCoroutine);

        public Ship GetShip() => prefabShip;

        private IEnumerator MoveShips()
        {
            while (true)
            {
                prefabShip.Init(shipConfigs[Random.Range(0, shipConfigs.Length)]);
                prefabShip.transform.localPosition = startPosition.localPosition;
                yield return new WaitUntil(() => (prefabShip.transform.localPosition - endPosition.localPosition).sqrMagnitude < 1f);
            }
        }
    }
}