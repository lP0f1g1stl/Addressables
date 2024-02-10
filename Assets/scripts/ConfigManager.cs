using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ConfigManager : MonoBehaviour, IConfigManager
{

    public async Task GetConfig<TConfigType>(List<TConfigType> configs, ConfigType configType)
    {
        AsyncOperationHandle<IList<TConfigType>> groupLoadHandle = Addressables.LoadAssetsAsync<TConfigType>(configType.ToString(), null);
        await groupLoadHandle.Task;
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
}
