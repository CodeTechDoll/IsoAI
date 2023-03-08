using Zenject;

namespace Assets.Scripts.Systems
{
    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            _ = Container.Bind<SystemManager>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}