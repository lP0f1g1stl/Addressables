public class LoadingState : IState
{
    private StateMachine stateMachine;

    private LoadingHandler loadingHandler;
    private IConfigManager configManager;
    private PauseManager pauseManager;

    public LoadingState(StateMachine stateMachine, LoadingHandler loadingHandler, IConfigManager configManager, PauseManager pauseManager)
    {
        this.stateMachine = stateMachine;
        this.loadingHandler = loadingHandler;
        this.configManager = configManager;
        this.pauseManager = pauseManager;
    }

    public async void Enter()
    {
        await configManager.LoadConfigs();
        await loadingHandler.LoadAsync((int)SceneType.Gameplay);
        stateMachine.EnterIn<PlayerLoopState>();
    }

    public void Exit()
    {

    }

    public void Tick()
    {
    }
}
