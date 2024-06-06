using Zenject;

public class BootstrapSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IAssetProvider>()
            .To<AssetProvider>()
            .AsSingle();
    }
}
