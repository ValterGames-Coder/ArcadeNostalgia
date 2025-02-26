using UnityEngine;
using UnityEngine.UI;

namespace BattleShipGame
{
    public class Ship : MonoBehaviour
    {
        private Image _spriteRenderer;
        private float _speed;
        private Vector3 _direction;

        public void Init(Sprite sprite, float speed, Vector3 direction)
        {
            _spriteRenderer = GetComponent<Image>();
            _speed = speed;
            _direction = direction;
            _spriteRenderer.sprite = sprite;
        }

        public void Update()
        {
            transform.Translate(_direction * _speed);
        }
    }
}