using UnityEngine;
using UnityEngine.UI;

namespace BattleShipGame
{
    public class Ship : MonoBehaviour
    {
        private ShipConfig _shipConfig;
        private Image _imageRenderer;
        
        public void Init(ShipConfig shipConfig)
        {
            _imageRenderer ??= GetComponent<Image>();
            _shipConfig = shipConfig;
            _imageRenderer.sprite = _shipConfig.shipImage;
        }

        public void Update()
        {
            transform.Translate(Vector2.right * (_shipConfig.speed * Time.deltaTime));
        }
    }

    [System.Serializable]
    public struct ShipConfig
    {
        public float speed;
        public Sprite shipImage;
    }
}