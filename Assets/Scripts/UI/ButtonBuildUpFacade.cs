using UnityEngine;
using Zenject;

namespace UI
{
    public class ButtonBuildUpFacade : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = null;

        [Inject] private SignalBus signalBus;

        private void Awake() => canvas.worldCamera = UnityEngine.Camera.main;
        
        public void TriggerButton() => signalBus.Fire<MySignals.BuildTowerSignal>();
    }
}