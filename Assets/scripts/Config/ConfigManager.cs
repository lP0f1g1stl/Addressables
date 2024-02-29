using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;

public class ConfigManager : IConfigManager
{
    private Dictionary<ConfigType, List<IConfig>> configs;

    public Action<float> OnProgressChange { get; set; }

    public ConfigManager() 
    {
        configs = new Dictionary<ConfigType, List<IConfig>>();

        configs[ConfigType.Player] = new List<IConfig>();
        configs[ConfigType.InAppView] = new List<IConfig>();
    }

    public async UniTask LoadConfigs() 
    {
        await LoadConfig(configs[ConfigType.Player], ConfigType.Player);
        await LoadConfig(configs[ConfigType.InAppView], ConfigType.InAppView);
    }
    private async UniTask LoadConfig<TConfigType>(List<TConfigType> configs, ConfigType configType)
    {
        AsyncOperationHandle<IList<TConfigType>> groupLoadHandle = Addressables.LoadAssetsAsync<TConfigType>(configType.ToString(), null);
        await groupLoadHandle.Task;
        while (!groupLoadHandle.IsDone)
        {
            OnProgressChange?.Invoke(groupLoadHandle.PercentComplete);
            await UniTask.Yield();
        }
        if (groupLoadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            IList<TConfigType> assets = groupLoadHandle.Result;
            foreach (TConfigType asset in assets)
            {
                configs.Add(asset);
            }
        }
        Addressables.Release(groupLoadHandle);
    }

    public List<IConfig> GetConfig(ConfigType configType) 
    {
        return configs[configType];
    }
}
