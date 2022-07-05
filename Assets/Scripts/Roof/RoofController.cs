using UnityEngine;
using Zenject;

namespace Assets.Scripts.Roof
{
    public class RoofController
    {
        private readonly Transform transform;
        private readonly GameManager gameManager;

        public RoofController(Settings settings, Transform transform, GameManager gameManager)
        {
            this.transform = transform;
            this.gameManager = gameManager;
        }

        public void UpdatePosRoof() => transform.position = gameManager.HighRoof;

        [System.Serializable]
        public class Settings
        {
//TODO
        }
    }
}