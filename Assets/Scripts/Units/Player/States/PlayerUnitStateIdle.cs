using UnityEngine;

namespace Assets.Scripts.Units.Player.States
{
    public class PlayerUnitStateIdle : IUnitState
    {
        private readonly Transform transform;
        private readonly PlayerUnitBasicInstaller.Settings settings;
        private readonly PlayerUnitStateController playerUnitStateController;

        private Animation.AnimationsSymulation animationsSymulation = new();

        public PlayerUnitStateIdle(Transform transform, PlayerUnitBasicInstaller.Settings settings,
           PlayerUnitStateController playerUnitStateController)
        {
            this.transform = transform;
            this.settings = settings;
            this.playerUnitStateController = playerUnitStateController;
        }

        public void EnterState() { }

        public void FixedUpdate()
        {
            if (Physics2D.OverlapCircle(transform.position, settings.AttackRange, settings.EnemyLayer))
                playerUnitStateController.ChangeState(UnitStates.Attack);
        }

        public void Update()
        {
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp
                (settings.MinMaxSwing.x, settings.MinMaxSwing.y, animationsSymulation.LerpValue(settings.SpeedSwing)));
        }
        public void ExitState() { }
    }
}