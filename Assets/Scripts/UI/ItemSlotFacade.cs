using Assets.Scripts.Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.UI
{
    public class ItemSlotFacade : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Canvas myCanvas = null;
        [SerializeField] private RectTransform rectTransform = null;

        private SignalBus signalBus;

        [Inject]
        public void Construct(SignalBus signalBus) => this.signalBus = signalBus;

        private void Awake() => myCanvas.worldCamera = Camera.main;

        public void OnDrop(PointerEventData eventData)
        {
            signalBus.Fire(new SpawnPlayerUnitSignal()
            {
                SpawnPos = rectTransform.position,
                UnitType = 1
            });
        }

        public void OnClickSlot() => signalBus.Fire(new SelectSlotSignal() { High = transform.position.y });
    }
}
