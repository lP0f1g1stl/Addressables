using System.Collections.Generic;

public class PauseManager
{
    private List<IPausable> pausableObjects = new List<IPausable>();

    public void AddPausable(IPausable pausable) 
    {
        pausableObjects.Add(pausable);
    }

    public void SetPauseState(bool isPaused) 
    {
        foreach(IPausable pausable in pausableObjects) 
        {
            pausable.IsPaused = isPaused;
        }
    }
}
