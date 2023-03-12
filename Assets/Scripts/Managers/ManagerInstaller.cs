using Assets.Scripts.Systems;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Managers
{
    public class ManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EntityManager>().AsSingle();
            Container.Bind<TurnSystem>().AsSingle();
        }
    }
}