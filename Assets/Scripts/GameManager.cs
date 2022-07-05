using Assets.Scripts.Tower;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GameManager : IInitializable
    {
        public Vector2 HighRoof { private set; get; }

        private readonly TowerBuidlingController.Settings towerSettings;

        public GameManager(TowerBuidlingController.Settings towerSettings)
        {
            this.towerSettings = towerSettings;
        }

        public void Initialize() => HighRoof = towerSettings.StartPositionRoof;
        public void UpdateHighRoofGlobalParameter() => HighRoof += towerSettings.HighOnUpdateRoof;

    }
}
