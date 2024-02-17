using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/InAppViewConfig", order = 1)]
public class InAppPackageConfig : ScriptableObject, IConfig
{
    [SerializeField] private float price;

    public float Price
    {
        get => price;
        set => price = value;
    }
}
