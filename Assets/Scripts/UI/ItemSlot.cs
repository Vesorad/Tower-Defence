using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*GameObject gameObject = eventData.pointerDrag.GetComponent<DragDropItemFacade>().test2;

        //INEJCT GAME GAMANER I DAC TUTAJ POZYCJE WIEZY
        var position = new Vector2();
        var rotation = GetComponent<RectTransform>().rotation;
        Instantiate(gameObject, position, rotation);*/
    }
}
