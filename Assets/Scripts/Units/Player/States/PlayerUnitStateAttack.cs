using Assets.Scripts.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Units.Player.States
{
    public class PlayerUnitStateAttack : IUnitState
    {
        private readonly Transform transform;
        private readonly PlayerUnitBasicInstaller.Settings settings;
        private readonly PlayerUnitStateController playerUnitStateController;
        private readonly ProjectileFacade.Factory projectileFactory;

        private Collider2D target;
        private float timeToNextAttack;

        public PlayerUnitStateAttack(Transform transform, PlayerUnitBasicInstaller.Settings settings,
            PlayerUnitStateController playerUnitStateController, ProjectileFacade.Factory projectileFactory)
        {
            this.transform = transform;
            this.settings = settings;
            this.playerUnitStateController = playerUnitStateController;
            this.projectileFactory = projectileFactory;
        }

        public void EnterState() => FindTarget();
        public void FixedUpdate() { }

        public void Update()
        {
            transform.rotation = Animation.AnimationsSymulation.LookAtTarget(transform.position, target.transform.position);
            if (Time.time >= timeToNextAttack)
            {
                timeToNextAttack = Time.time + settings.CooldownAttack;
                projectileFactory.Create(transform.position, settings.ProjectileBase);
            }
            if (!target.gameObject.activeSelf)
                FindTarget();
        }

        public void ExitState() { }

        public void FindTarget()
        {
            if (target = Physics2D.OverlapCircle(transform.position, settings.AttackRange, settings.EnemyLayer))
                settings.ProjectileBase.SetTarget(target.transform);
            else
                playerUnitStateController.ChangeState(UnitStates.DefaultState);
        }
    }
}