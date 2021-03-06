using Assets.Scripts.Units;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Roof
{
    public class RoofFacade : HealthBaseFacade
    {
        private IMemoryPool pool;
        private SignalBus signalBus;

        [Inject]
        public void Construct(HealthController healthController, SignalBus signalBus)
        {
            HealthController = healthController;
            this.signalBus = signalBus;
        }

        public override void OnSpawned(Vector2 spawnPos, IMemoryPool pool)
        {
            transform.position = spawnPos;
            this.pool = pool;
        }

        public override void OnDespawned()
        {

        }

        public override void OnDeath()
        {
            signalBus.Fire<Signals.EndGameSignal>();
        }

        public class Factory : PlaceholderFactory<Vector2, RoofFacade> { }
    }
}