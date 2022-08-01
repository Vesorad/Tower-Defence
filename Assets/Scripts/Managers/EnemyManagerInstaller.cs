using Zenject;

namespace Managers
{
    public class EnemyManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<MySignals.SpawnEnemyUnitSignal>().ToMethod<EnemySpawner>
                ((x, s) => x.ChooseEnemyToSpawn(s.UnitNumber)).FromResolve();
        }
    }
}