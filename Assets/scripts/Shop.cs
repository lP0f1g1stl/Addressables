using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<InAppPackageView> items;

    private void Start()
    {
        if (ConfigManager.instance != null) FindItems();
    }
    private void FindItems()
    {
        items.AddRange(FindObjectsOfType<InAppPackageView>());
        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].ShowPrice(ConfigManager.instance.InAppConfigs.configs[Random.Range(0, ConfigManager.instance.InAppConfigs.configs.Count)].Price);

            }
        }
    }
}
