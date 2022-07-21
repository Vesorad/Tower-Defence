using Assets.Scripts.Signals;
using Assets.Scripts.Zenject;
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
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
            Container.Bind<PlayerUnitsController>().AsSingle();

            BindSignals();

            gameFactores.BindFactores(Container, settings);
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<BuildTowerSignal>();
            Container.DeclareSignal<SpawnEnemyUnitSignal>();
            Container.DeclareSignal<SpawnPlayerUnitSignal>();
            Container.DeclareSignal<EndGameSignal>();
            Container.DeclareSignal<HitRoofSignal>();

            Container.BindSignal<BuildTowerSignal>().ToMethod<GameManager>((x, s) => x.UpdateHighRoofGlobalParameter()).FromResolve();
            Container.BindSignal<SpawnPlayerUnitSignal>().ToMethod<PlayerUnitsController>((x, s) => x.SpawnUnitPlayer(s.SpawnPos)).FromResolve();
            Container.BindSignal<SpawnEnemyUnitSignal>().ToMethod<EnemySpawner>((x, s) => x.ChooseEnemyToSpawn(s.UnitNumber)).FromResolve();
        }
    }
}