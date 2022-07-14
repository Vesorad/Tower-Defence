using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Units.Enemy.States
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
