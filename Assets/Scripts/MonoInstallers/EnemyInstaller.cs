using Zenject;
using UnityEngine;

namespace Assets.Scripts.MonoInstallers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Enemies.Enemy>().AsSingle().WithArguments(settings.MyTransform);
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public Transform MyTransform { private set; get; } = null;
        }
    }
}