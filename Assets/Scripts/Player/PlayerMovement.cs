using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = 
            new Vector2(_playerInput.MovementValue * speed * Time.deltaTime, 
                        _rigidbody.velocity.y);
    }
}
