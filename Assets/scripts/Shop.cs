using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour, IConfigUser
{
    [SerializeField] private ConfigType configType;

    private List<InAppPackageView> items = new List<InAppPackageView>();
    private List<InAppPackageConfig> configs = new List<InAppPackageConfig>();

    private IConfigManager manager;

    [Inject]
    public void Construct(IConfigManager manager)
    {
        this.manager = manager;

        FindItems();
        InstallConfig();
    }
    private void InstallConfig()
    {
        configs = manager.GetConfig(ConfigType.InAppView).ConvertAll(x => (InAppPackageConfig)x);
        SetData();
    }
    private void FindItems()
    {
        items.AddRange(FindObjectsOfType<InAppPackageView>(true));
    }
    private void SetData()
    {
        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].ShowPrice(configs[Random.Range(0, configs.Count)].Price);

            }
        }
    }
}
