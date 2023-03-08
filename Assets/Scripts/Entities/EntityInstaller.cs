using Zenject;

namespace Assets.Scripts.Entities
{

    public class EntityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDGenerator>().AsSingle();
            Container.Bind<Entity>().AsSingle();
        }
    }
}