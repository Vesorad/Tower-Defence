using UnityEngine;

namespace Assets.Scripts.Roof
{
    public class RoofController
    {
        readonly Settings settings;
        readonly Transform transform;

        public RoofController(Settings settings, Transform transform)
        {
            this.settings = settings;
            this.transform = transform;
        }

        public void UpdatePosRoof() => transform.position += settings.HighOnUpdateRoof;

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(0)] public Vector3 HighOnUpdateRoof { private set; get; } = new();
        }
    }
}