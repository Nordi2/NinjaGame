using Assets.CodeBase.Service;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public InputService InputService;
    public override void InstallBindings()
    {
        Container
            .Bind<IInputService>()
            .To<InputService>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}
