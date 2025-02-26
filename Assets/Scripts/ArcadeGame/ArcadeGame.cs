using System;
using UnityEngine;

public abstract class ArcadeGame : MonoBehaviour
{
    [SerializeField] private GameObject arcadeGameObject;
    protected ArcadeGameInput _arcadeGameInput;
    public Action OnExitPerformed;

    private void Awake()
    {
        _arcadeGameInput = GetComponent<ArcadeGameInput>();
    }

    public ArcadeGameInput GetInput() => _arcadeGameInput;

    public void StartGame() 
    {
        arcadeGameObject.SetActive(true);
        _arcadeGameInput.EnableInput();
    }

    public void EndGame()
    {
        arcadeGameObject.SetActive(false);
    }
}