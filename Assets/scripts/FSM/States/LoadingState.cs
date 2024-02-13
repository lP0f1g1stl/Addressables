public class LoadingState : IState
{
    private StateMachine stateMachine;

    private LoadingHandler loadingHandler;

        public LoadingState(StateMachine stateMachine, LoadingHandler loadingHandler)
    {
        this.stateMachine = stateMachine;
        this.loadingHandler = loadingHandler;
    }

    public async void Enter()
    {
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
