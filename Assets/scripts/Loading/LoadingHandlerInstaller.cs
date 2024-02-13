using UnityEngine;
using Zenject;

public class LoadingHandlerInstaller : MonoInstaller
{
    [SerializeField] private LoadingHandler loadingHandler;
    public override void InstallBindings()
    {
        Container.Bind<LoadingHandler>().FromInstance(loadingHandler).AsSingle();
    }
}
