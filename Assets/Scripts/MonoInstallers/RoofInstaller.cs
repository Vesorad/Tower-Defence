using Assets.Scripts.Roof;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.MonoInstallers
{
    public class RoofInstaller : MonoInstaller
    {
        [SerializeField] private Transform myTransform = null;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(myTransform).AsSingle();
            Container.BindInterfacesAndSelfTo<RoofController>().AsSingle();

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<Signals.BuildTowerSignal>().ToMethod<RoofController>((x, s) => x.UpdatePosRoof()).FromResolve();
        }
    }
}