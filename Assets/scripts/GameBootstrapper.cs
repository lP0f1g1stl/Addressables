using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private LoadingHandler loadingHandler;

    private void Awake()
    {
        loadingHandler.Loading(1);
    }
}
