namespace Units
{
    public interface IUnitState
    {
        void EnterState();
        void Update();
        void FixedUpdate();
        void ExitState();
    }
}