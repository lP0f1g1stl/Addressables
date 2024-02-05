using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Injector : MonoBehaviour
{
    private List<IConfigUser> configUsers = new List<IConfigUser>();
    private IConfigManager configManager;
    void Awake()
    {
        FindObjects();
        InjectData();
    }

    private void FindObjects() 
    {
        GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject root in roots) 
        {
            configUsers.AddRange(root.GetComponentsInChildren<IConfigUser>(true));
            configManager = root.GetComponentInChildren<IConfigManager>(true);
        }
    }

    private void InjectData() 
    {
        foreach(IConfigUser configUser in configUsers) 
        {
            configUser.Init(configManager);
        }
    }
}
