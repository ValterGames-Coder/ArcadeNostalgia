using DG.Tweening;
using UnityEngine;

namespace BattleShipGame
{
    public class Torpedo : MonoBehaviour
    {
        private Ship _ship;
        [SerializeField] private Transform startPosition, endPosition;

        public void Init(Ship ship) => _ship = ship;

        public void Shoot()
        {
            if (_ship == null) 
                return;
            DOTween.Sequence()
                .Append(transform.DOMove(endPosition.position, 3f).SetEase(Ease.Linear))
                .AppendCallback(() => Debug.Log("Shoot"))
                .AppendCallback(() => transform.localPosition = startPosition.localPosition);
        }
    }
}