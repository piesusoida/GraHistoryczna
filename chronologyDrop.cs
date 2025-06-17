using UnityEngine;
using UnityEngine.EventSystems;

public class ChronologyDrop : MonoBehaviour, IDropHandler
{
    [Header("Drag-Drop Settings")]
    [Tooltip("ID of the correct draggable object for this drop zone")]
    public string correctItemID;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"Drop attempted on {gameObject.name}");

        if (transform.childCount > 0)
        {
            Debug.Log("Slot already occupied!");
            return;
        }

        if (eventData.pointerDrag != null)
        {
            RectTransform draggedRect = eventData.pointerDrag.GetComponent<RectTransform>();

            if (draggedRect == null)
            {
                Debug.LogWarning("Dropped object does not have a RectTransform.");
                return;
            }

            // Set parent to this drop area
            draggedRect.SetParent(transform, worldPositionStays: true);

            draggedRect.anchoredPosition = Vector2.zero;
        }
    }

    public bool IsCorrectItemPlaced()
    {
        if (transform.childCount == 0)
        {
            Debug.Log($"{gameObject.name} is empty.");
            return false;
        }

        DragDrop item = transform.GetChild(0).GetComponent<DragDrop>();
        if (item == null)
        {
            Debug.LogWarning("Child does not have DragDrop component.");
            return false;
        }

        Debug.Log($"{gameObject.name} received item with ID: {item.itemID}");
        return item.itemID == correctItemID;
    }
}
