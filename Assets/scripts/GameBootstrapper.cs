using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] LoadingHandler loadingHandler;

    private StateMachine stateMachine;
    private IInputHandler inputHandler;

    [Inject]
    public void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }
    private void Awake()
    {
        stateMachine = new StateMachine(loadingHandler, inputHandler);
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        stateMachine.EnterIn<LoadingState>();
    }

    private void Update()
    {
        stateMachine.TickIn();
    }
}
