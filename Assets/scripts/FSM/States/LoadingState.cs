public class LoadingState : IState
{
    private StateMachine stateMachine;

    private LoadingHandler loadingHandler;
    private IConfigManager configManager;
    private SceneLoadingManager sceneLoader;

    public LoadingState(StateMachine stateMachine, LoadingHandler loadingHandler, IConfigManager configManager, SceneLoadingManager sceneLoader)
    {
        this.stateMachine = stateMachine;
        this.loadingHandler = loadingHandler;
        this.configManager = configManager;
        this.sceneLoader = sceneLoader;

        AddListeners();
    }
    private void AddListeners() 
    {
        configManager.OnProgressChange += loadingHandler.ChangeProgress;
        sceneLoader.OnProgressChange += loadingHandler.ChangeProgress;

    }

    public async void Enter()
    {
        await configManager.LoadConfigs();
        await sceneLoader.LoadAsync((int)SceneType.Gameplay);
        stateMachine.EnterIn<PlayerLoopState>();
    }

    public void Exit()
    {

    }

    public void Tick()
    {
    }
}
