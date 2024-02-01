using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public class InAppPackageView : MonoBehaviour
{
    [SerializeField] private AssetReference inAppPackageConfig;
    [Space]
    [SerializeField] private TextMeshProUGUI textMesh;

    private AsyncOperationHandle operationHandle;

    private void Start()
    {
        if (inAppPackageConfig.RuntimeKeyIsValid()) StartCoroutine(GetConfig());
    }
    public IEnumerator GetConfig( )
    {
        if (operationHandle.IsValid()) Addressables.Release(operationHandle);

        operationHandle = inAppPackageConfig.LoadAssetAsync<InAppPackageConfig>();
        yield return operationHandle;
        InAppPackageConfig config = (InAppPackageConfig)operationHandle.Result;
        ShowPrice(config.Price);
    }
    public void ShowPrice(float price)
    {
        textMesh.text = string.Format(textMesh.text, price.ToString());
    }
}
