using Assets.Scripts.Roof;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.MonoInstallers
{
    public class RoofInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RoofController>().AsSingle().WithArguments(settings.MyTransform);

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<Signals.BuildTowerSignal>().ToMethod<RoofController>((x, s) => x.UpdatePosRoof()).FromResolve();
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public Transform MyTransform { private set; get; } = null;
        }
    }
}