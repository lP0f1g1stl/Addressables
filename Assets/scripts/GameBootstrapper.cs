using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] LoadingHandler loadingHandler;

    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    private IConfigManager configManager;
    private PauseManager pauseManager;
    private SceneLoadingManager sceneLoader;

    [Inject]
    public void Construct(IInputHandler inputHandler, IConfigManager configManager, PauseManager pauseManager, SceneLoadingManager sceneLoader)
    {
        this.inputHandler = inputHandler;
        this.configManager = configManager;
        this.pauseManager = pauseManager;
        this.sceneLoader = sceneLoader;
    }
    private void Awake()
    {
        stateMachine = new StateMachine(loadingHandler, inputHandler, configManager, pauseManager, sceneLoader);
        DontDestroyOnLoad(gameObject);
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
