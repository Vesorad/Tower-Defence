using Zenject;

namespace Assets.Scripts.Managers
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
            Container.BindSignal<Signals.SpawnEnemyUnitSignal>().ToMethod<EnemySpawner>((x, s) => x.ChooseEnemyToSpawn(s.UnitNumber)).FromResolve();
        }
    }
}