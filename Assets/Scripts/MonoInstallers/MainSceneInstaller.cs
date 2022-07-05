using Assets.Scripts.Signals;
using Assets.Scripts.Zenject;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MonoInstallers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject] private GameFactores.Settings settings = null;

        private GameFactores gameFactores =new();

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            BindSignals();

            Transform poolsHolder = new GameObject("---POOLS---").transform;
            gameFactores.BindFactores(Container, settings, poolsHolder);
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<BuildTowerSignal>();
            Container.BindSignal<BuildTowerSignal>().ToMethod<GameManager>((x, s) => x.UpdateHighRoofGlobalParameter()).FromResolve();
        }
    }
}