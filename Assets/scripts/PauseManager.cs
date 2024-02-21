using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    private List<IPausable> pausableObjects = new List<IPausable>();

    private void Awake()
    {
        FindAllPO();
    }
    public void FindAllPO() 
    {
        pausableObjects.AddRange(FindObjectsOfType<MonoBehaviour>().OfType<IPausable>());
    }

    public void ClearPOList() 
    {
        pausableObjects.Clear();
    }

    public void SetPauseState(bool isPaused) 
    {
        foreach(IPausable pausable in pausableObjects) 
        {
            pausable.IsPaused = isPaused;
        }
    }
}
