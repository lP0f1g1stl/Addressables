using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private AssetReference playerConfig;
    [Space]
    [SerializeField] private float startingSpeed;
    private AsyncOperationHandle operationHandle;

    public float StartingSpeed { set => startingSpeed = value;}
    private void Start()
    {
        if (playerConfig.RuntimeKeyIsValid()) StartCoroutine(GetConfig());
    }
    private IEnumerator GetConfig() 
    {
        if (operationHandle.IsValid()) Addressables.Release(operationHandle);
        operationHandle = playerConfig.LoadAssetAsync<PlayerConfig>();
        yield return operationHandle;
        PlayerConfig config = (PlayerConfig)operationHandle.Result;
        startingSpeed = config.StartingSpeed;
    }

    private void Update()
    {
        transform.position += transform.forward * startingSpeed * Time.deltaTime;
    }
}
