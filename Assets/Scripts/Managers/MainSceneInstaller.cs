using Assets.Scripts.Signals;
using Assets.Scripts.Zenject;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Managers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject] private GameFactores.Settings settings = null;

        private GameFactores gameFactores = new();

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            BindSignals();

            gameFactores.BindFactores(Container, settings, new GameObject("---POOLS---").transform);
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<BuildTowerSignal>();
            Container.DeclareSignal<SpawnEnemySignal>();

            Container.BindSignal<BuildTowerSignal>().ToMethod<GameManager>((x, s) => x.UpdateHighRoofGlobalParameter()).FromResolve();
        }
    }
}