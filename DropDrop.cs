using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class DropDrop : MonoBehaviour, IDropHandler
{

    public string correctItemID;

    private void Awake()
    {
        if(gameObject.name == "DropPlace1")
        {
            correctItemID = "DragObj3";
        }
        else if (gameObject.name == "DropPlace2")
        {
            correctItemID = "DragObj2";
        }
        else
        {
            correctItemID = "DragObj1";
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("zrzut");

        if (transform.childCount > 0)
        {
            Debug.Log("Slot already occupied!");
            return;
        }
        if (eventData.pointerDrag != null)
        {
            RectTransform draggedRect = eventData.pointerDrag.GetComponent<RectTransform>();

            // Optional: Set the parent of the dragged object to the drop target
            draggedRect.SetParent(transform);

            // Reset position within new parent
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
        Debug.Log(item);
        if (item == null) return false;
        Debug.Log(item.itemID);
        return item.itemID == correctItemID;
    }


}
