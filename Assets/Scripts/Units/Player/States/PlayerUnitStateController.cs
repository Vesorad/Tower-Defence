using System.Collections.Generic;
using Zenject;

namespace Units.Player.States
{
    public class PlayerUnitStateController : UnitStateController
    {
        [Inject]
        public void Construct(PlayerUnitStateAttack attack, PlayerUnitStateIdle defaultState)
        {
            States = new List<IUnitState> { attack, defaultState };
            CurrentStateHandler = defaultState;
        }
    }
}