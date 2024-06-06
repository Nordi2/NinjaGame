using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Service;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IInputService>()
            .To<InputService>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container
            .Bind<IAssetProvider>()
            .To<AssetProvider>()
            .AsSingle();

        Container
            .Bind<IPlayerFactory>()
            .To<PlayerFactory>()
            .AsSingle();
    }
}
