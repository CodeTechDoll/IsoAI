using Zenject;

namespace Assets.Scripts.Entities
{

    public class EntityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            _ = Container.Bind<IDGenerator>().AsSingle();
            _ = Container.Bind<Entity>().AsSingle();
        }
    }
}