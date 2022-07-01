using Assets.Scripts.Tower;
using Zenject;

namespace Assets.Scripts.MonoInstallers
{
    public class TowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TowerController>().AsSingle();

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<Signals.BuildTowerSignal>().ToMethod<TowerController>((x, s) => x.AddNewPartTower()).FromResolve();
        }
    }
}