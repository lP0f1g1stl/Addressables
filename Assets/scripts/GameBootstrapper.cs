using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] LoadingHandler loadingHandler;

    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    private IConfigManager configManager;

    [Inject]
    public void Construct(IInputHandler inputHandler, IConfigManager configManager)
    {
        this.inputHandler = inputHandler;
        this.configManager = configManager;
    }
    private void Awake()
    {
        stateMachine = new StateMachine(loadingHandler, inputHandler, configManager);
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
