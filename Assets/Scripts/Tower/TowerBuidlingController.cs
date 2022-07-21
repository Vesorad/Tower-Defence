using Assets.Scripts.Managers;
using Assets.Scripts.Roof;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower
{
    public class TowerBuidlingController : IInitializable
    {
        private readonly RoofFacade.Factory roofFactory;
        private readonly TowerOneSlotFacade.Factory towerOneSlotFactory;
        private readonly GameManager gameManager;

        public TowerBuidlingController(TowerOneSlotFacade.Factory towerOneSlotFactory, RoofFacade.Factory roofFactory,
            GameManager gameManager)
        {
            this.towerOneSlotFactory = towerOneSlotFactory;
            this.roofFactory = roofFactory;
            this.gameManager = gameManager;
        }

        public void Initialize() => roofFactory.Create(gameManager.HighRoof);

        public void AddNewPartTower() => towerOneSlotFactory.Create().transform.position = (gameManager.HighTower);

        [System.Serializable]
        public class Settings
        {
            [field: Header("Start Parameters")]
            [field: SerializeField] public Vector2 StartPositionRoof { private set; get; } = Vector2.zero;
            [field: SerializeField] public Vector2 StartPositionTower { private set; get; } = Vector2.zero;

            [field: Header("Update Parameters")]
            [field: SerializeField, Min(0)] public Vector2 HighOnUpdateRoof { private set; get; } = Vector2.zero;
            [field: SerializeField, Min(0)] public Vector2 HighOnUpdateTower { private set; get; } = Vector2.zero;
        }
    }
}
