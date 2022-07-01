using Assets.Scripts.Tower;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MonoInstallers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject] private Settings settings = null;

        public override void InstallBindings()
        {
            BindSignals();
            BindFactores();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Signals.BuildTowerSignal>();
        }

        private void BindFactores()
        {
            Container.BindFactory<TowerOneSlot, TowerOneSlot.Factory>().FromPoolableMemoryPool<TowerOneSlot, TowerOneSlotPool>(poolBinder => poolBinder.WithInitialSize(settings.PartTowerOneSlot.PoolSize)
                  .FromComponentInNewPrefab(settings.PartTowerOneSlot.Prefab).UnderTransformGroup(settings.PartTowerOneSlot.NameFolder));
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public ObjectPool PartTowerOneSlot { private set; get; } = null;
        }

        private class TowerOneSlotPool : MonoPoolableMemoryPool<IMemoryPool, TowerOneSlot> { }
    }
}