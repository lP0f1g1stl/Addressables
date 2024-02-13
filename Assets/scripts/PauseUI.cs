using Zenject;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private IInputHandler inputHandler;

    [Inject]
    public void Construct(IInputHandler inputHandler) 
    {
        this.inputHandler = inputHandler;

        AddListener();
    }

    private void AddListener() 
    {
        inputHandler.OnEscBtnClick += ShowPause;
    }
    private void OnDestroy()
    {
        inputHandler.OnEscBtnClick -= ShowPause;
    }
    private void ShowPause() 
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
