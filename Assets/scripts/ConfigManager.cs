using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ConfigManager : MonoBehaviour, IConfigManager
{

    public async Task<List<TConfigType>> GetConfig<TConfigType>(List<TConfigType> configs, string label)
    {
        AsyncOperationHandle<IList<TConfigType>> groupLoadHandle = Addressables.LoadAssetsAsync<TConfigType>(label, null);
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
        return configs;
    }
}
