using UnityEngine;
public class PlayerLoopState : IState
{
    private StateMachine stateMachine;

    private IInputHandler inputHandler;
    private PauseManager pauseManager;
    public PlayerLoopState(StateMachine stateMachine, IInputHandler inputHandler, PauseManager pauseManager)
    {
        this.stateMachine = stateMachine;
        this.inputHandler = inputHandler;
        this.pauseManager = pauseManager;
    }
    
    public void Enter()
    {
        inputHandler.IsPaused = false;
        pauseManager.FindAllPO();
        pauseManager.SetPauseState(false);
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
