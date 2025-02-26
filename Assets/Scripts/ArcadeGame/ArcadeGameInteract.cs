using UnityEngine;

public class ArcadeGameInteract : MonoBehaviour, ITriggered
{
    private bool _inTriggerZone;
    private PlayerInput _playerInput;
    private ArcadeGame _currentGame;

    private void Awake() => _playerInput = GetComponent<PlayerInput>();
    private void OnEnable() => _playerInput.OnActionPerformed += StartGame;
    private void OnDisable() => _playerInput.OnActionPerformed -= StartGame;

    public void OnEnter(MonoBehaviour triggerObject)
    {
        _inTriggerZone = true;
        if (triggerObject.TryGetComponent(out ArcadeGame arcadeGame))
            _currentGame = arcadeGame;
    } 
    public void OnExit() => _inTriggerZone = false;

    private void StartGame()
    {
        if (_currentGame == null || !_inTriggerZone)
            return;

        _playerInput.enabled = false;
        _currentGame.GetInput().OnExit += EndGame;
        _currentGame.StartGame();
    }

    private void EndGame()
    {
        _playerInput.enabled = true;
        _currentGame.GetInput().OnExit -= EndGame;
        _currentGame.EndGame();
    }
}