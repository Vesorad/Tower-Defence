using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Units
{
    public abstract class UnitStateController : IInitializable, ITickable, IFixedTickable
    {
        protected IUnitState CurrentStateHandler;
        protected List<IUnitState> States;

        private UnitStates currentState;

        public void Initialize() => ChangeState(UnitStates.DefaultState);
        public void Tick() => CurrentStateHandler.Update();
        public void FixedTick() => CurrentStateHandler.FixedUpdate();
        public UnitStates CurrentState() => currentState;

        public void ChangeState(UnitStates state)
        {
            if (currentState == state)
                return;

            currentState = state;
            CurrentStateHandler.ExitState();

            CurrentStateHandler = States[(int)state];
            CurrentStateHandler.EnterState();
        }
    }
}