using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager instance;

    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
}
