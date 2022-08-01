using System.Collections.Generic;
using Zenject;

namespace Units.Enemy.States
{
    public class EnemyUnitStateController : UnitStateController
    {
        [Inject]
        public void Construct(EnemyUnitStateAttack attack, EnemyUnitStateDefault defaultState)
        {
            States = new List<IUnitState> { attack, defaultState };
            CurrentStateHandler = defaultState;
        }
    }
}
