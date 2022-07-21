using Assets.Scripts.Signals;
using Assets.Scripts.Units.Player.States;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Player
{
    public class PlayerUnitBasicInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPreFab settingsPreFab = null;
        [Inject] private Settings settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HealthController>().AsSingle().WithArguments(settings.Health, settingsPreFab.playerUnitFacade);
            Container.BindInterfacesAndSelfTo<PlayerUnitStateController>().AsSingle();

            Container.Bind<PlayerUnitStateAttack>().AsSingle().WithArguments(settingsPreFab.transform, settings);
            Container.Bind<PlayerUnitStateIdle>().AsSingle().WithArguments(settingsPreFab.transform, settings);

            BindSignals();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<DealDamageUnitSignal>();
            Container.BindSignal<DealDamageUnitSignal>().ToMethod<HealthController>((x, s) => x.Hit(s.Damage)).FromResolve();
        }

        [Serializable]
        public class SettingsPreFab
        {
            [field: SerializeField] public Transform transform { private set; get; } = null;
            [field: SerializeField] public HealthBaseFacade playerUnitFacade { private set; get; } = null;
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField, Min(1)] public int Health { private set; get; } = 1;
            [field: SerializeField] public Projectiles.ProjectileBase ProjectileBase { private set; get; } = null;
            [field: SerializeField, Min(0.1f)] public float CooldownAttack { private set; get; } = 0.1f;
            [field: SerializeField, Min(0.1f)] public float AttackRange { private set; get; } = 0.1f;
            [field: SerializeField, Min(0.1f)] public LayerMask EnemyLayer { private set; get; } = default;
            [field: Header("Animation")]
            [field: SerializeField, Min(0)] public float SpeedSwing { private set; get; } = 0;
            [field: SerializeField] public Vector2 MinMaxSwing { private set; get; } = new Vector2(-20, 20);
        }
    }
}