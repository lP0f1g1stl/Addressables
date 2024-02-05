using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Shop : MonoBehaviour, IConfigUser
{
    [SerializeField] string label;

    private List<InAppPackageView> items = new List<InAppPackageView>();
    private List<InAppPackageConfig> configs = new List<InAppPackageConfig>();

    private IConfigManager manager;

    public void Init(IConfigManager manager)
    {
        this.manager = manager;
    }
    private void Start()
    {
        FindItems();
        InstalConfig();
    }

    private async void InstalConfig() 
    {
        Task<List<InAppPackageConfig>> task = manager.GetConfig(configs, label);
        await task;
        configs = task.Result;
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
                items[i].ShowPrice(configs[UnityEngine.Random.Range(0, configs.Count)].Price);

            }
        }
    }
}
