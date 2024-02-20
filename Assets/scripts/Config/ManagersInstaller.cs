using Zenject;
using UnityEngine;
public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ConfigManager>().AsSingle();
    }
}
