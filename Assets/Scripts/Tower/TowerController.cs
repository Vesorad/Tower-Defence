using UnityEngine;

namespace Assets.Scripts.Tower
{
    public class TowerController
    {
        private readonly Settings settings;
        private readonly TowerOneSlot.Factory towerOneSlotFactory;

        private Vector3 towerHigh = new Vector3(0, -3, 0);

        public TowerController(Settings settings, TowerOneSlot.Factory towerOneSlotFactory)
        {
            this.settings = settings;
            this.towerOneSlotFactory = towerOneSlotFactory;
        }

        public void AddNewPartTower() => towerOneSlotFactory.Create().transform.position = (towerHigh += settings.HighOnUpdate);

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(0)] public Vector3 HighOnUpdate { private set; get; } = new();
        }
    }
}
