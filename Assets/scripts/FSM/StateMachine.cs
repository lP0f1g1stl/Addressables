using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, IState> states;
    private IState currentState;

    public StateMachine(LoadingHandler loadingHandler, IInputHandler inputHandler, IConfigManager configManager, PauseManager pauseManager, SceneLoadingManager sceneLoader)
    {
        states = new Dictionary<Type, IState>()
        {
            [typeof(LoadingState)] = new LoadingState(this, loadingHandler, configManager, sceneLoader),
            [typeof(PlayerLoopState)] = new PlayerLoopState(this, inputHandler, pauseManager),
            [typeof(PauseState)] = new PauseState(this, inputHandler, pauseManager)
        };
    }

    public void EnterIn<TState>() where TState : IState 
    { 
        if(states.TryGetValue(typeof(TState), out IState state)) 
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }
    }
    public void TickIn()
    {
        currentState?.Tick();
    }
}
