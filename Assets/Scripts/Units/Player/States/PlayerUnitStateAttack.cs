
using UnityEngine;

namespace Assets.Scripts.Units.Player.States
{
    public class PlayerUnitStateAttack : IUnitState
    {
        private readonly Transform transform;
        private readonly PlayerUnitBasicInstaller.Settings settings;
        private readonly PlayerUnitStateController playerUnitStateController;

        private Transform target;

        public PlayerUnitStateAttack(Transform transform, PlayerUnitBasicInstaller.Settings settings,
            PlayerUnitStateController playerUnitStateController)
        {
            this.transform = transform;
            this.settings = settings;
            this.playerUnitStateController = playerUnitStateController;
        }

        public void EnterState() => FindTarget();

        public void FixedUpdate()
        {

        }

        public void Update()
        {
            if (target == null)
                playerUnitStateController.ChangeState(UnitStates.DefaultState);
        }

        public void ExitState()
        {

        }

        public void FindTarget()
        {
            target = Physics2D.OverlapCircle(transform.position, settings.AttackRange, settings.EnemyLayer).transform;
        }
    }
}