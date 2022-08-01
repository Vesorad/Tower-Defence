using Zenject;

namespace Tower
{
    public class TowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TowerBuidlingController>().AsSingle();

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<MySignals.BuildTowerSignal>().ToMethod<TowerBuidlingController>((x, s) => x.AddNewPartTower()).FromResolve();
        }
    }
}