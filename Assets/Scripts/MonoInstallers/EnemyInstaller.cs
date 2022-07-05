using Zenject;
using UnityEngine;
using Assets.Scripts.Enemies;

namespace Assets.Scripts.MonoInstallers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Enemy>().AsSingle().WithArguments(settings);
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public Transform MyTransform { private set; get; } = null;
            [field: SerializeField] public EnemyBasicFacade EnemyFacade { private set; get; } = null;
        }
    }
}