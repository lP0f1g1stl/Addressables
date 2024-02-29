using Zenject;
public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ConfigManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadingManager>().AsSingle();
    }
}
