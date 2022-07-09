using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Units.Enemy.States
{
    public class EnemyUnitStateController : IInitializable, ITickable, IFixedTickable
    {
        private UnitStates currentState;
        private IUnitState currentStateHandler;
        private List<IUnitState> states;

        public EnemyUnitStateController(EnemyUnitStateAttack attack, EnemyUnitStateFollow follow)
        {
            states = new List<IUnitState> { attack, follow };
            currentStateHandler = follow;
        }

        public void Initialize() => ChangeState(UnitStates.Follow);
        public void Tick() => currentStateHandler.Update();
        public void FixedTick() => currentStateHandler.FixedUpdate();
        public UnitStates CurrentState() => currentState;

        public void ChangeState(UnitStates state)
        {
            if (currentState == state)
                return;

            currentState = state;
            currentStateHandler.ExitState();

            currentStateHandler = states[(int)state];
            currentStateHandler.EnterState();
        }
    }
}