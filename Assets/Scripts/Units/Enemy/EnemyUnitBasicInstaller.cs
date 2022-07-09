using Zenject;
using UnityEngine;
using Assets.Scripts.Units.Enemy.States;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyUnitBasicInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPreFab settings = null;

        public override void InstallBindings()
        {
            Container.Bind<HealthController>().AsSingle();

            Container.Bind<EnemyUnitStateAttack>().AsSingle();
            Container.Bind<EnemyUnitStateFollow>().AsSingle().WithArguments(settings.MyTransform);
            Container.BindInterfacesAndSelfTo<EnemyUnitStateController>().AsSingle();
        }

        [System.Serializable]
        public class SettingsPreFab
        {
            [field: SerializeField] public Transform MyTransform { private set; get; } = null;
            [field: SerializeField] public EnemyUnitBasicFacade EnemyFacade { private set; get; } = null;
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(1)] public int Health { private set; get; } = 1;
            [field: SerializeField, Min(1)] public EnemyMovementTypes.EnemyMovementType MovementType { private set; get; } = null;
            [field: SerializeField, Min(0.1f)] public float Speed { private set; get; } = 0.1f;
            [field: SerializeField, Min(1)] public int DamageOnRoof { private set; get; } = 1;
        }
    }
}