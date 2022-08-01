using Units.Player;
using UnityEngine;

namespace Managers
{
    public class PlayerUnitsController
    {
        private readonly PlayerUnitBasicFacade.Factory playerUnitBasicFactory;

        public PlayerUnitsController(PlayerUnitBasicFacade.Factory playerUnitBasicFactory)
        {
            this.playerUnitBasicFactory = playerUnitBasicFactory;
        }

        public void SpawnUnitPlayer(Vector2 startPos)
        {
            playerUnitBasicFactory.Create(startPos);
        }
    }
}