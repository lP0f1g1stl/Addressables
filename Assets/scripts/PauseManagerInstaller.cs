using Zenject;
using UnityEngine;

public class PauseManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PauseManager>().AsSingle();
    }
}
