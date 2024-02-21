using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    private List<IPausable> pausableObjects = new List<IPausable>();

    public void FindAllPO() 
    {
        pausableObjects.Clear();
        pausableObjects.AddRange(FindObjectsOfType<MonoBehaviour>().OfType<IPausable>());
    }

    public void SetPauseState(bool isPaused) 
    {
        foreach(IPausable pausable in pausableObjects) 
        {
            pausable.IsPaused = isPaused;
        }
    }
}
