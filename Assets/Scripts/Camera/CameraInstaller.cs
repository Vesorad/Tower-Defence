using Zenject;
using UnityEngine;
using Assets.Scripts.Signals;

namespace Assets.Scripts.CameraInGame
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle().WithArguments(settings.MultipleSpeedCameraOnBuildPart, settings.MyTransform);

            BindSignals();
        }

        private void BindSignals()
        {

            Container.BindSignal<BuildTowerSignal>().ToMethod<CameraController>((x, s) => x.UpdateMaxRangeCamera()).FromResolve();
            Container.BindSignal<SelectSlotSignal>().ToMethod<CameraController>((x, s) => x.ChangeHighCamera(s.High)).FromResolve();
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(0.1f)] public Transform MyTransform { private set; get; } = null;
            [field: SerializeField, Min(0.1f)] public float SpeedCameraOnScroll { private set; get; } = 0.1f;
            [field: SerializeField, Min(1f)] public float MultipleSpeedCameraOnBuildPart { private set; get; } = 1;
        }
    }
}