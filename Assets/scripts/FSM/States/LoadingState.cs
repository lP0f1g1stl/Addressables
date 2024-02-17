public class LoadingState : IState
{
    private StateMachine stateMachine;

    private LoadingHandler loadingHandler;
    private IConfigManager configManager;

    public LoadingState(StateMachine stateMachine, LoadingHandler loadingHandler, IConfigManager configManager)
    {
        this.stateMachine = stateMachine;
        this.loadingHandler = loadingHandler;
        this.configManager = configManager;
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
