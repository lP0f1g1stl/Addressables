using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Collections.Generic;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] private Configs<PlayerConfig> playerConfigs;
    [SerializeField] private Configs<InAppPackageConfig> inAppConfigs;

    public static ConfigManager instance;

    public event Action<int> OnLoadDone;

    public Configs<PlayerConfig> PlayerConfigs => playerConfigs;
    public Configs<InAppPackageConfig> InAppConfigs => inAppConfigs;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    private void Start()
    {
        GetConfig(playerConfigs, 0);
        GetConfig(inAppConfigs, 1);
    }

    private async void GetConfig<TConfigType>(Configs<TConfigType> assetGroup, int queueIndex)
    {
        AsyncOperationHandle<IList<TConfigType>> groupLoadHandle = Addressables.LoadAssetsAsync<TConfigType>(assetGroup.assetLabel, null);
        await groupLoadHandle.Task;
        if (groupLoadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            IList<TConfigType> assets = groupLoadHandle.Result;
            foreach (TConfigType asset in assets)
            {
                assetGroup.configs.Add(asset);
            }
            OnLoadDone?.Invoke(queueIndex);
        }
        Addressables.Release(groupLoadHandle);
    }
}
