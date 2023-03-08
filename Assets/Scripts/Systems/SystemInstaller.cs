using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Systems
{
    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SystemManager>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}