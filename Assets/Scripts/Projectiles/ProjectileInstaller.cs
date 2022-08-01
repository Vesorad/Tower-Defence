using System;
using UnityEngine;
using Zenject;

namespace Projectiles
{
    public class ProjectileInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPreFab settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProjectileController>().AsSingle().WithArguments(settings.Transform);
        }

        [Serializable]
        public class SettingsPreFab
        {
            [field: SerializeField] public Transform Transform { private set; get; } = null;
        }
    }
}