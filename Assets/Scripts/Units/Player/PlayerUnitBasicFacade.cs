using Zenject;

namespace Assets.Scripts.Units.Player
{
    public class PlayerUnitBasicFacade : UnitFacade
    {
        public override void Die()
        {

        }

        public override void OnDespawned()
        {

        }

        public override void OnSpawned(IMemoryPool p1)
        {

        }

        public class Factory : PlaceholderFactory<PlayerUnitBasicFacade> { }
    }
}