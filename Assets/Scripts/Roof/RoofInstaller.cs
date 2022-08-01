using MySignals;
using Units;
using UnityEngine;
using Zenject;

namespace Roof
{
    public class RoofInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPreFab settingsPreFab = null;

        [Inject] private Settings settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RoofController>().AsSingle().WithArguments(settingsPreFab.MyTransform);
            Container.BindInterfacesAndSelfTo<HealthController>().AsSingle().WithArguments(settings.Health, settingsPreFab.Facade);

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<HitRoofSignal>().ToMethod<RoofController>((x, s) => x.HitRoof(s.Damage)).FromResolve();
            Container.BindSignal<BuildTowerSignal>().ToMethod<RoofController>((x, s) => x.UpdatePosRoof()).FromResolve();
        }

        [System.Serializable]
        public class SettingsPreFab
        {
            [field: SerializeField] public Transform MyTransform { private set; get; } = null;
            [field: SerializeField] public HealthBaseFacade Facade { private set; get; } = null;
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(1)] public int Health { private set; get; } = 1;
        }
    }
}