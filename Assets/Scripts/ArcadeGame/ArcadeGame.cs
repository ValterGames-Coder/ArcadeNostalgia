using System;
using UnityEngine;

public abstract class ArcadeGame : MonoBehaviour
{
    [SerializeField] private GameObject arcadeGameObject;
    [SerializeField] private ArcadeGameHolder gameHolder;
    protected ArcadeGameInput _arcadeGameInput;
    public Action OnExitPerformed;

    private void Awake()
    {
        _arcadeGameInput = GetComponent<ArcadeGameInput>();
    }

    public ArcadeGameInput GetInput() => _arcadeGameInput;

    public void StartGame() 
    {
        gameHolder.Open(this);
        _arcadeGameInput.EnableInput();
    }

    public void EndGame()
    {
        gameHolder.Close(this);
    }
}