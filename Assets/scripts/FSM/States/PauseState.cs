using UnityEngine;
public class PauseState : IState
{
    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    private PauseManager pauseManager;
    public PauseState(StateMachine stateMachine, IInputHandler inputHandler, PauseManager pauseManager)
    {
        this.stateMachine = stateMachine;
        this.inputHandler = inputHandler;
        this.pauseManager = pauseManager;
    }
    public void Enter()
    {
        inputHandler.IsPaused = true;
        pauseManager.SetPauseState(true);
        inputHandler.OnEscBtnClick += stateMachine.EnterIn<PlayerLoopState>;
    }

    public void Exit()
    {
        inputHandler.OnEscBtnClick -= stateMachine.EnterIn<PlayerLoopState>;
    }

    public void Tick()
    {
        inputHandler.CheckInput();
    }
}
