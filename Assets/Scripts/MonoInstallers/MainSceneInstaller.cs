using Zenject;

namespace Assets.Scripts.MonoInstallers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignals();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Signals.BuildTowerSignal>();
        }
    }
}