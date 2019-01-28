using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, ISubmitHandler
{
    public Item item;

    public void OnSubmit(BaseEventData eventData)
    {
        item.SelectItem();
    }
    
}

