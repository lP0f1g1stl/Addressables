using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EntryPoint : MonoBehaviour
{
    void Awake()
    {
        GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
        new Injector(FindConfigUsers(roots), new ConfigManager());
    }

    private List<IConfigUser> FindConfigUsers(GameObject[] roots)
    {
        List<IConfigUser> configUsers = new List<IConfigUser>();
        foreach (GameObject root in roots)
        {
            configUsers.AddRange(root.GetComponentsInChildren<IConfigUser>(true));
        }
        return configUsers;
    }
}
