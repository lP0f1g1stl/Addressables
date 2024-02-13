using UnityEngine;
public class PauseState : IState
{
    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    public PauseState(StateMachine stateMachine, IInputHandler inputHandler)
    {
        this.stateMachine = stateMachine;
        this.inputHandler = inputHandler;
    }
    public void Enter()
    {
        inputHandler.IsPaused = true;
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
