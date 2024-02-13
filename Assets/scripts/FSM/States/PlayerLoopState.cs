using UnityEngine;
public class PlayerLoopState : IState
{
    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    public PlayerLoopState(StateMachine stateMachine, IInputHandler inputHandler)
    {
        this.stateMachine = stateMachine;
        this.inputHandler = inputHandler;
    }
    
    public void Enter()
    {
        inputHandler.IsPaused = false;
        inputHandler.OnEscBtnClick += stateMachine.EnterIn<PauseState>;
    }
    public void Exit()
    {
        inputHandler.OnEscBtnClick -= stateMachine.EnterIn<PauseState>;
    }
    public void Tick()
    {
        inputHandler.CheckInput();
    }
}
