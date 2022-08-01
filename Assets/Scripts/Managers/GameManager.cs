using Tower;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : IInitializable
    {
        public Vector2 HighRoof { private set; get; }
        public Vector2 HighTower { private set; get; }

        private readonly TowerBuidlingController.Settings towerSettings;

        public GameManager(TowerBuidlingController.Settings towerSettings)
        {
            this.towerSettings = towerSettings;
        }

        public void Initialize()
        {
            HighRoof = towerSettings.StartPositionRoof;
            HighTower = towerSettings.StartPositionTower;
        }
        public void UpdateHighRoofGlobalParameter()
        {
            HighRoof += towerSettings.HighOnUpdateRoof;
            HighTower += towerSettings.HighOnUpdateTower;
        }

    }
}
