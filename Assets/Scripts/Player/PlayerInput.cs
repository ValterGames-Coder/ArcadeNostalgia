using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private GameInput _gameInput;
    public float MovementValue { private set; get; }
    public Action OnActionPerformed;
    
    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Player.Enable();
    }
    private void OnEnable() => _gameInput.Player.Action.performed += OnActionPerformedMethod;
    private void OnDisable()
    {
        _gameInput.Player.Action.performed -= OnActionPerformedMethod;
        MovementValue = 0;
    }
    private void FixedUpdate() => MovementValue = _gameInput.Player.Movement.ReadValue<float>();
    private void OnActionPerformedMethod(InputAction.CallbackContext callback)
        => OnActionPerformed?.Invoke();
}