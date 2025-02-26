using UnityEngine;

public abstract class ArcadeGame : MonoBehaviour
{
    [SerializeField] private GameObject arcadeGameObject;
    protected ArcadeGameInput _arcadeGameInput;

    private void Awake()
    {
        _arcadeGameInput = GetComponent<ArcadeGameInput>();
    }

    public ArcadeGameInput GetInput() => _arcadeGameInput;

    public virtual void StartGame() 
    {
        arcadeGameObject.SetActive(true);
        _arcadeGameInput.EnableInput();
    }

    public virtual void EndGame()
    {
        arcadeGameObject.SetActive(false);
    }
}