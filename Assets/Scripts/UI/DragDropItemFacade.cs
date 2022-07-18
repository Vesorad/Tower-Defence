using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class DragDropItemFacade : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private RectTransform rectTransform = null;
        [SerializeField] private CanvasGroup canvasGroup = null;
        [SerializeField, Min(0)] private float alphaImage = 0;

        private Vector2 startPosition;

        private void Awake() => startPosition = rectTransform.anchoredPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData) => rectTransform.anchoredPosition += eventData.delta;

        public void OnEndDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition = startPosition;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
