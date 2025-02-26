using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArcadeGameInput : MonoBehaviour
{
    private GameInput _gameInput;
    public Action OnExit;
    public Action OnAction;
    [HideInInspector] public Vector2 Movement;

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    public void EnableInput()
    {
        _gameInput.Arcade.Enable();
        _gameInput.Arcade.Exit.performed += OnExitPerformed;
        _gameInput.Arcade.Action.performed += OnActionPerformed;
    }

    private void Update() => Movement = _gameInput.Arcade.Movement.ReadValue<Vector2>();
    private void OnActionPerformed(InputAction.CallbackContext context) => OnAction?.Invoke();
    
    private void OnExitPerformed(InputAction.CallbackContext context)
    {
        OnExit?.Invoke();
        _gameInput.Arcade.Exit.performed -= OnExitPerformed;
        _gameInput.Arcade.Action.performed -= OnActionPerformed;
        Movement = Vector2.zero;
        _gameInput.Arcade.Disable();
    }
}