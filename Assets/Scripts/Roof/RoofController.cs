using Assets.Scripts.Managers;
using Assets.Scripts.Units;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Roof
{
    public class RoofController
    {
        private readonly Transform transform;
        private readonly GameManager gameManager;
        private readonly HealthController healthController;

        public RoofController(Transform transform, GameManager gameManager, HealthController healthController)
        {
            this.transform = transform;
            this.gameManager = gameManager;
            this.healthController = healthController;
        }
        

        public void HitRoof(int damage) => healthController.Hit(damage);
        public void UpdatePosRoof() => transform.position = gameManager.HighRoof;
    }
}