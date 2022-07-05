using Assets.Scripts.Enemies;
using Zenject;

namespace Assets.Scripts.MonoInstallers
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
            Container.BindSignal<Signals.BuildTowerSignal>().ToMethod<EnemySpawner>((x, s) => x.SpawnEnemy()).FromResolve();
        }
    }
}