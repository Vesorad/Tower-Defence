using Assets.Scripts.Roof;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower
{
    public class TowerBuidlingController : IInitializable
    {
        private readonly Settings settings;
        private readonly RoofFacade.Factory roofFactory;
        private readonly TowerOneSlotFacade.Factory towerOneSlotFactory;

        private Vector2 towerHigh;

        public TowerBuidlingController(Settings settings, TowerOneSlotFacade.Factory towerOneSlotFactory, RoofFacade.Factory roofFactory)
        {
            this.settings = settings;
            this.towerOneSlotFactory = towerOneSlotFactory;
            this.roofFactory = roofFactory;
        }

        public void Initialize()
        {
            towerHigh = settings.StartPositionTower;

            roofFactory.Create().transform.position = settings.StartPositionRoof;
        }

        public void AddNewPartTower() => towerOneSlotFactory.Create().transform.position = (towerHigh += settings.HighOnUpdateTower);

        [System.Serializable]
        public class Settings
        {
            [field: Header("Start Parameters")]
            [field: SerializeField] public Vector2 StartPositionRoof { private set; get; } = new();
            [field: SerializeField] public Vector2 StartPositionTower { private set; get; } = new();

            [field: Header("Update Parameters")]
            [field: SerializeField, Min(0)] public Vector2 HighOnUpdateRoof { private set; get; } = new();
            [field: SerializeField, Min(0)] public Vector2 HighOnUpdateTower { private set; get; } = new();
        }
    }
}
